using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSPBenchmark;

namespace R11546004ACO
{
    public partial class Form_Main : Form
    {
        TSPProblem theProblem;
        int[] greedySolution = null;
        double best_Obj;
        dynamic mySolver;
        public Form_Main()
        {
            InitializeComponent();
        }

        private void btn_OpenTSPProblem_Click(object sender, EventArgs e)
        {
            int result = TSPBenchmarkProblem.ImportATSPFile(true,true);
            if (result< 0) { return; }
            greedySolution = TSPBenchmarkProblem.GetGreedyShortestRoute();
            tabPage_Cities.Refresh();
            
            theProblem = new TSPProblem(TSPBenchmarkProblem.Name, TSPBenchmarkProblem.NumberOfCities,TSPBenchmarkProblem.FromToDistanceMatrix);
            if(TSPBenchmarkProblem.GlobalShorestLength4TSP.ToString() == "0")
            {
                theProblem.shortestLength = "NAN";
            }
            else
            {
                theProblem.shortestLength = TSPBenchmarkProblem.GlobalShorestLength4TSP.ToString();
            }
            theProblem.GreedySolutionLength = TSPBenchmarkProblem.ComputeObjectiveValue(greedySolution).ToString();
            propertyGrid_Problem.SelectedObject = theProblem;
            btn_CreateACO.Enabled = button_CreateGASolver.Enabled = true;
            btn_Reset.Enabled = btn_RunOneIter.Enabled = btn_RunToEnd.Enabled = false ;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_OpenTSPProblem_Click(null, null);
        }

        private void tabPage_Cities_Paint(object sender, PaintEventArgs e)
        {
            if (greedySolution == null) return;
            TSPBenchmarkProblem.DrawCitiesOptimalRouteAndARoute(
                e.Graphics,e.ClipRectangle.Width,e.ClipRectangle.Height,greedySolution);
        }

        private void btn_CreateACO_Click(object sender, EventArgs e)
        {
            if (radioButton_ACS.Checked)
            {
                mySolver = new AntColonySystem(TSPBenchmarkProblem.NumberOfCities, OptimizationType.Minimization
                    , TSPBenchmarkProblem.ComputeObjectiveValue, theProblem.heurMat);

            }
            else
            {
                mySolver = new AntSystem(TSPBenchmarkProblem.NumberOfCities, OptimizationType.Minimization
                    , TSPBenchmarkProblem.ComputeObjectiveValue, theProblem.heurMat);
            }
            BindSolverToPropertyGrid();
            btn_Reset.Enabled = true;
            btn_RunOneIter.Enabled = btn_RunToEnd.Enabled = false;
        }
        private void BindSolverToPropertyGrid()
        {
            propertyGrid_Solver.SelectedObject = mySolver;
        }

        private void button_CreateGASolver_Click(object sender, EventArgs e)
        {
            if (radioButton_PermutationGA.Checked)
            {
                mySolver = new GALibrary.PermutationGA(TSPBenchmarkProblem.NumberOfCities, GALibrary.OptimizationType.Minimization
                    , TSPBenchmarkProblem.ComputeObjectiveValue);

            }
            else
            {
                mySolver = new GALibrary.TSPGA(TSPBenchmarkProblem.NumberOfCities, GALibrary.OptimizationType.Minimization
                    , TSPBenchmarkProblem.ComputeObjectiveValue, TSPBenchmarkProblem.FromToDistanceMatrix);
            }
            BindSolverToPropertyGrid();
            btn_Reset.Enabled = true;
            btn_RunOneIter.Enabled = btn_RunToEnd.Enabled = false;
        }
        private void UpdateIteration()
        {
            greedySolution = mySolver.SoFarTheBestSolution;
            best_Obj = mySolver.SoFarTheBestObj;

            richTextBox_BestObj.Clear();
            richTextBox_BestSolution.Clear();

            for (int c = 0; c < greedySolution.Length; c++)
            {
                richTextBox_BestSolution.AppendText(greedySolution[c].ToString() + " ");
            }
            richTextBox_BestObj.AppendText(best_Obj.ToString());
            richTextBox_BestSolution.Refresh();
            richTextBox_BestObj.Refresh();
            tabPage_Cities.Refresh();
            try
            {
                if (checkBox_ShowSolutions.Checked)
                {
                    richTextBox_Solutions.Clear();
                    for (int i = 0; i < mySolver.NumberOfAnts; i++)
                    {
                        richTextBox_Solutions.AppendText($"Ants{i}: ");
                        for (int j = 0; j < mySolver.NumberOfVariables; j++)
                        {
                            richTextBox_Solutions.AppendText(mySolver.Solutions[i][j].ToString() + " ");
                        }
                        richTextBox_Solutions.AppendText(mySolver.Objectives[i].ToString());
                        richTextBox_Solutions.AppendText("\n");
                    }
                }
                if (checkBox_ShowPeremone.Checked)
                {
                    richTextBox_Pheremone.Clear();
                    for (int i = 0; i < mySolver.NumberOfVariables; i++)
                    {
                        for (int j = 0; j < mySolver.NumberOfVariables; j++)
                        {
                            richTextBox_Pheremone.AppendText(mySolver.PheromoneMatrix[i,j].ToString("0.000") + " ");
                        }
                        richTextBox_Pheremone.AppendText("\n");
                    }
                }
            }
            catch { }
        }
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            mySolver.Reset();
            UpdateIteration();
            mainChart.Series[0].Points.Clear();
            mainChart.Series[1].Points.Clear();
            mainChart.Series[2].Points.Clear();
            btn_RunOneIter.Enabled = btn_RunToEnd.Enabled = true;
        }
        private void btn_RunOneIter_Click(object sender, EventArgs e)
        {
            if (mySolver.IterationCount == mySolver.IterationLimit) { return; }
            mySolver.RunOneIteration();
            UpdateIteration();
            mainChart.Series[0].Points.AddXY(mySolver.IterationCount, mySolver.IterationObjectiveAverage);
            mainChart.Series[1].Points.AddXY(mySolver.IterationCount, mySolver.IterationBestObj);
            mainChart.Series[2].Points.AddXY(mySolver.IterationCount, mySolver.SoFarTheBestObj);
            mainChart.Update();
        }
        private void btn_RunToEnd_Click(object sender, EventArgs e)
        {
            if (checkBox_ShowProgress.Checked)
            {
                do
                {
                    btn_RunOneIter_Click(null, null); ;
                } while (mySolver.IterationCount < mySolver.IterationLimit);
            }
            else {
                if (mySolver.IterationCount == mySolver.IterationLimit) { return; }
                mySolver.RunToEnd();
                UpdateIteration();
                mainChart.Series[0].Points.Clear();
                mainChart.Series[1].Points.Clear();
                mainChart.Series[2].Points.Clear();
                for (int i = 0; i < mySolver.IterationCount; i++)
                {
                    mainChart.Series[0].Points.AddXY(i, mySolver.IterationObjectiveAverageArr[i]);
                    mainChart.Series[1].Points.AddXY(i, mySolver.IterationBestObjArr[i]);
                    mainChart.Series[2].Points.AddXY(i, mySolver.SoFarTheBestObjArr[i]);
                }
            }
        }

        private void propertyGrid_Solver_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            btn_RunOneIter.Enabled = btn_RunToEnd.Enabled = false;
        }
    }
}
