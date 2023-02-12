using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace R11546004ACO
{
    public delegate double ObjectiveFunction(int[] solution);
    public enum OptimizationType
    {
        Minimization,
        Maximization
    }
    public class AntColonyOptimizier
    {

        protected double[,] pheromoneMatrix;
        protected double[,] heuristicMatrix;
        protected double dropAmount = 0.2;
        protected double pheromoneFactor = 1.0;
        protected double heuristicFactor = 3.0;
        protected int[] candidateCities;
        protected double[] fitness;
        protected int numberOfAnts = 20;
        protected int iterationLimit = 200;
        protected double initialPheromone = 0.1;
        protected int iterationCount = 0;
        protected int[][] solutions;
        protected int numberOfVariables = 10;
        protected int[] soFarTheBestSolution;
        protected double soFarTheBestObjective;
        protected double iterationObjectiveAverage;
        protected double iterationBestObj;
        protected OptimizationType optimizationMode = OptimizationType.Minimization;
        protected ObjectiveFunction objFunction;
        protected double[] objectives;
        protected Random randomizer = new Random();
        protected double evaporationRate = 0.1;

        protected double[] iterationObjectiveAverageArr;
        protected double[] iterationBestObjArr;
        protected double[] soFarTheBestObjArr;
        [Browsable(false)]
        public double[] Objectives { get => objectives; }
        [Browsable(false)]
        public int NumberOfVariables { get => numberOfVariables; }
        [Browsable(false)]
        public double[,] PheromoneMatrix { get => pheromoneMatrix; }
        [Browsable(false)]
        public int[][] Solutions { get => solutions; }
        [Browsable(false)]
        public double SoFarTheBestObj { get => soFarTheBestObjective; }
        [Browsable(false)]
        public double IterationObjectiveAverage { get => iterationObjectiveAverage; }
        [Browsable(false)]
        public double IterationBestObj { get => iterationBestObj; }
        [Browsable(false)]
        public double[] SoFarTheBestObjArr { get => soFarTheBestObjArr; }
        [Browsable(false)]
        public double[] IterationObjectiveAverageArr
        {
            get => iterationObjectiveAverageArr;
        }
        [Browsable(false)]
        public double[] IterationBestObjArr
        {
            get => iterationBestObjArr;
        }
        [Browsable(false)]
        public int[] SoFarTheBestSolution
        {
            get => soFarTheBestSolution;
        }
        [Category("Optimizier Settings")]
        [Description("The factor of Pheromone used to calculate fitness")]
        public double PheromoneFactor { get => pheromoneFactor; set { if (value > 0) pheromoneFactor = value; } }
        [Category("Optimizier Settings")]
        [Description("The factor of Heuristic used to calculate fitness")]
        public double HeuristicFactor { get => heuristicFactor; set { if (value > 0) heuristicFactor = value; } }
        [Category("Optimizier Settings")]
        [Description("Numbers of Ants in a iteration")]
        public int NumberOfAnts { get => numberOfAnts; set => numberOfAnts = value; }
        [Category("Execution")]
        [Description("Numbers of Iteration")]
        public int IterationLimit { get => iterationLimit; set { if (value > 0) { iterationLimit = value; } } }
        [Browsable(false)]
        public int IterationCount { get => iterationCount; set => iterationCount = value; }
        [Category("Optimizier Settings")]
        [Description("Initial Parameter for Pheromone")]
        public double InitialPheromone { get => initialPheromone; set { if (value > 0 && value < 1) { initialPheromone = value; } } }
        [Category("Optimizier Settings")]
        [Description("Pheromone Evaporation Rate after a iteration")]
        public double EvaporationRate
        {
            get => evaporationRate; set
            {
                if (value >= 0 && value < 1) { evaporationRate = value; }
            }
        }
        [Category("Optimizier Settings")]
        [Description("Amount of pheromone drop if an ants goes by")]
        public double DropAmount { get => dropAmount; set { if (value > 0) { dropAmount = value; } } }

        public AntColonyOptimizier(int numberOfVariables, OptimizationType opType, ObjectiveFunction objFun, double[,] heur)
        {
            this.numberOfVariables = numberOfVariables;
            this.optimizationMode = opType;
            this.objFunction = objFun;
            heuristicMatrix = heur;
            soFarTheBestSolution = new int[this.numberOfVariables];
            candidateCities = new int[numberOfVariables];
            fitness = new double[numberOfVariables];
            for (int c = 0; c < numberOfVariables; c++)
            {
                candidateCities[c] = c;
            }
        }
        void ShuffleToInitializeSolution(int r)
        {
            for (int c = 0; c < numberOfVariables; c++)
            {
                int i1 = randomizer.Next(numberOfVariables);
                int temp = solutions[r][c];
                solutions[r][c] = solutions[r][i1];
                solutions[r][i1] = temp;
            }
        }
        public void Reset()
        {
            InitializePheromoneMatrix();
            iterationCount = 0;

            solutions = new int[numberOfAnts][];
            for(int i = 0; i < numberOfAnts; i++)
            {
                solutions[i] = new int[numberOfVariables];
                for (int c = 0; c < numberOfVariables; c++)
                {
                    solutions[i][c] = c;
                }
                ShuffleToInitializeSolution(i);
            }
            objectives = new double[numberOfAnts];
            fitness = new double[numberOfAnts];
            EvaluteObjectiveAndUpdateSoFarTheBest();
            iterationObjectiveAverageArr = new double[iterationLimit];
            iterationBestObjArr = new double[iterationLimit];
            soFarTheBestObjArr = new double[iterationLimit];
        }

        protected virtual void InitializePheromoneMatrix()
        {
            pheromoneMatrix = new double[numberOfVariables, numberOfVariables];
            for (int i = 0; i < numberOfVariables; i++)
            {
                for (int j = 0; j < numberOfVariables; j++)
                {
                    pheromoneMatrix[i, j] = initialPheromone;
                }
            }
        }
        public void RunOneIteration()
        {
            AllAntCreateSolution();
            EvaluteObjectiveAndUpdateSoFarTheBest();
            UpdatePheromoneMatrix();
            iterationObjectiveAverageArr[iterationCount] = iterationObjectiveAverage;
            iterationBestObjArr[iterationCount] = iterationBestObj;
            soFarTheBestObjArr[iterationCount] = SoFarTheBestObj;
            iterationCount++;
        }
        public void RunToEnd()
        {
            do
            {
                RunOneIteration();
            } while (iterationCount < iterationLimit);
        }
        protected virtual void UpdatePheromoneMatrix()
        {
            throw new NotImplementedException();
        }

        protected virtual void EvaluteObjectiveAndUpdateSoFarTheBest()
        {
            // Find iteration Best
            int bestAntsIdx = 0;
            double bestObjective = double.MaxValue;
            if (optimizationMode == OptimizationType.Maximization) { bestObjective = double.MinValue; }
            for (int i = 0; i < numberOfAnts; i++)
            {
                objectives[i] = objFunction(solutions[i]);
                if (optimizationMode == OptimizationType.Maximization && bestObjective < objectives[i])
                {
                    bestObjective = objectives[i];
                    bestAntsIdx = i;
                }
                else if (optimizationMode == OptimizationType.Minimization && bestObjective > objectives[i])
                {
                    bestObjective = objectives[i];
                    bestAntsIdx = i;
                }
            }
            iterationBestObj = objectives[bestAntsIdx];
            //Update so far the best
            iterationObjectiveAverage = objectives.Average();
            if (iterationCount == 0)
            {
                soFarTheBestObjective = iterationBestObj;
                for (int i = 0; i < numberOfVariables; i++)
                {
                    soFarTheBestSolution[i] = solutions[bestAntsIdx][i];
                }
            }
            else if (iterationBestObj < soFarTheBestObjective&&optimizationMode == OptimizationType.Minimization)
            {
                soFarTheBestObjective = iterationBestObj;
                for(int i = 0; i < numberOfVariables; i++)
                {
                    soFarTheBestSolution[i] = solutions[bestAntsIdx][i];
                }
            }
            else if (iterationBestObj > soFarTheBestObjective && optimizationMode == OptimizationType.Maximization)
            {
                soFarTheBestObjective = iterationBestObj;
                for (int i = 0; i < numberOfVariables; i++)
                {
                    soFarTheBestSolution[i] = solutions[bestAntsIdx][i];
                }
            }
        }

        protected virtual void AllAntCreateSolution()
        {
            throw new NotImplementedException();
        }
    }
}