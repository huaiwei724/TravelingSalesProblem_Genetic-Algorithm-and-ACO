using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GALibrary
{
    public class GeneticGASolver<T>
    {
        // data fields
        OptimizationType optimizationMode;
        ObjectiveFunction<T> theObjectiveFunction;
        protected int numberOfGenes;
        protected int populationSize = 10;
        protected T[][] chromosomes;
        protected double[] objectiveValue;
       // protected double[] AbsoluteObjValues;
        protected double[] fitnessValues;

        protected T[] soFarTheBestSolution;
        protected double soFarTheBestObj;
        protected double[] soFarTheBestObjArr;

        protected double iterationObjectiveAverage;
        protected double iterationBestObj;
        
        protected double[] iterationObjectiveAverageArr;
        protected double[] iterationBestObjArr;

        protected int numberOfCrossoveredChildren;
        protected int numberOfMutatedChildren;

        protected double crossoverRate = 0.8;
        protected double mutationRate = 0.3;
        protected MutationMode mutationType = MutationMode.PopulationSizeBased;

        protected int[] indices;

        protected int[] populationGenesIndex;
        protected int[] emptyGenesIndex; 

        protected double leastFitnessFraction = 0.3;

        protected int iterationLimit = 100;
        protected int iterationCount = 0;

        protected bool[] nextGenerationFlag;

        protected Random randomizer = new Random();

        //[Browsable(false)]
        //public virtual CutMode CrossOverCut { set; get; } = CutMode.OnePointCut;
        
        protected bool[][] mutatedFlags; // to set mutated gene in gene-number based mutation
        SelectionMode selectionType = SelectionMode.Deterministic;

        protected int numberAll = 0;

        protected Series average;
        protected Series iterBest;
        protected Series soFarBest;
        protected Chart chart;

        /*[Browsable(false)]
        public virtual MutationMode MutationType 
        {
            get => mutationType; 
            set { 
                mutationType = value;
                if (mutationType == MutationMode.GeneNumberBased) mutationRate = 0.05;
                else mutationRate = 0.3;
            } }*/
        [Category("Crossover Settings")]
        [Description("Percentage of Population to do Crossover")]
        public double CrossoverRate
        {
            get => crossoverRate;
            // Crossover 0.5~1
            set { if (value <= 1.0 && value >= 0.5) { crossoverRate = value; } }
        }
        [Category("Mutation Settings")]
        [Description("Percentage of Population or Gene Numbers to do Mutation")]
        public double MutationRate
        {
            get => mutationRate;
            set { if (value <= 1.0) { mutationRate = value; } }
        }
        [Category("Fitness Calculation")]
        [Description("The Lower Bound of Fitness value")]
        public double LeastFitnessFraction 
        { 
            get => leastFitnessFraction;
            set { if (value <= 1.0) { leastFitnessFraction = value; } } 
        }
        [Category("Evolution Settings")]
        [Description("Total numbers of iterations to run")]
        public int IterationLimit 
        {
            get => iterationLimit;
            set { if (value >= 0 ) { iterationLimit = value; } }
        }
        [Category("Evolution Settings")]
        [Description("Size of population")]
        public int PopulationSize
        {
            get => populationSize;
            set { if (value >= 2) populationSize = value; }
        }
        [Category("Evolution Settings")]
        [Description("Method used to select who survived to next generation")]
        public SelectionMode SelectionType { get => selectionType; set => selectionType = value; }
        [Browsable(false)]
        public int NumberAll { get => numberAll; }
        [Browsable(false)]
        public T[] SoFarTheBestSolution { get => soFarTheBestSolution; }
        [Browsable(false)]
        public double SoFarTheBestObjective { get => soFarTheBestObj; }
        [Browsable(false)]
        public T[][] Chromosomes { get => chromosomes; }
        [Browsable(false)]
        public int NumberOfGenes { get => numberOfGenes; set => numberOfGenes = value; }
        [Browsable(false)]
        public double[] ObjectiveValue { get => objectiveValue; }
        [Browsable(false)]
        public double[] FitnessValues { get => fitnessValues; }
        [Browsable(false)]
        public double IterationObjectiveAverage { get => iterationObjectiveAverage;}
        [Browsable(false)]
        public double IterationBestObjective { get => iterationBestObj;}
        [Browsable(false)]
        protected int IterationCount { get => iterationCount; set => iterationCount = value; }

        public GeneticGASolver(int numberOfVariables, OptimizationType optimizationType
            , ObjectiveFunction<T> encodingFunction)
        {
            numberOfGenes = numberOfVariables;
            soFarTheBestSolution = new T[numberOfGenes];
            optimizationMode = optimizationType;
            theObjectiveFunction = encodingFunction;

        }
        void SetFitnessFromObjectives()
        {
            numberAll = populationSize + numberOfCrossoveredChildren + numberOfMutatedChildren;

            double o_min = double.MaxValue;
            double o_max = double.MinValue;

            for (int i = 0; i < numberAll; i++)
            {
                if (o_min > objectiveValue[indices[i]]) o_min = objectiveValue[indices[i]];
                if (o_max < objectiveValue[indices[i]]) o_max = objectiveValue[indices[i]];
            }
            double b = Math.Max(leastFitnessFraction*(o_max-o_min), Math.Pow(10,-5));
            switch (optimizationMode)
            {
                case OptimizationType.Maximization:
                    for (int i = 0; i < numberAll; i++)
                    {
                        fitnessValues[i] = b + objectiveValue[indices[i]] - o_min;
                    }

                    break;
                case OptimizationType.Minimization:
                    for (int i = 0; i < numberAll; i++)
                    {
                        fitnessValues[i] = b - objectiveValue[indices[i]] + o_max;
                    }
                    break;
            }
        }

        void UpdateIterationBestAverageAndSoFarTheBest()
        {
            numberAll = populationSize + numberOfCrossoveredChildren + numberOfMutatedChildren;
            // calculate the iteration best, iteration average
            iterationObjectiveAverage = 0;
            iterationBestObj = double.MinValue;
            int inverse = 1;
            if (optimizationMode == OptimizationType.Minimization) 
            { inverse = -1; iterationBestObj = double.MaxValue; }
            int iterationBestIndex = 0;
            double obj = 0.0;
            for (int i = 0; i < numberAll; i++)
            {
                obj = objectiveValue[GetChromosomesIndexFromRow(i)];
                iterationObjectiveAverage += obj;
                if (inverse*iterationBestObj < obj* inverse)
                {
                    iterationBestObj = obj;
                    iterationBestIndex = i;
                }
            }
            iterationObjectiveAverage = iterationObjectiveAverage / numberAll;
            // check whether the iteration best can replace the so far the best
            // if iteration best is better than the so-far-the-best, update the best obj and solution
            // solution update must be done gene-wisely
            if (inverse*iterationBestObj > inverse*soFarTheBestObj || iterationCount == 0)
            {
                soFarTheBestObj = iterationBestObj;
                for (int i = 0; i < numberOfGenes; i++)
                {
                    soFarTheBestSolution[i] = chromosomes[indices[iterationBestIndex]][i];
                }
            }

        }
        void PerformSelectionOperation()
        {
            indices = populationGenesIndex.Concat(emptyGenesIndex).ToArray();

            //calculate fitness
            SetFitnessFromObjectives();
            UpdateIterationBestAverageAndSoFarTheBest();
            int ThreeSize = 3 * populationSize;


            switch (SelectionType)
            {
                case SelectionMode.Deterministic:

                    Array.Sort(fitnessValues, indices,0,numberAll);
                    Array.Reverse(indices, 0, numberAll);

                    populationGenesIndex = indices.Take(populationSize).ToArray();
                    emptyGenesIndex = indices.Skip(populationSize).ToArray();
                    
                    break;
                    
                case SelectionMode.Stochastic:
                    double wholeRange = 0;
                    for(int i = 0; i < numberAll; i++)
                    {
                        wholeRange += fitnessValues[GetChromosomesIndexFromRow(i)];
                    }
                    // cumulated fitness assignment
                    // perform populationSize stochastic selection
                    for(int j = 0; j < populationSize; j++)
                    {
                        double hitValue = randomizer.NextDouble() * wholeRange;
                        double cumulateValue = 0.0;
                        for (int i = 0; i < numberAll; i++)
                        {
                            double fitVal = fitnessValues[i];
                            if (hitValue <= cumulateValue + fitVal)
                            {
                                populationGenesIndex[j] = GetChromosomesIndexFromRow(i);
                                break;
                            }
                            cumulateValue += fitVal;
                        }
                    }
                    for (int i = 0; i < ThreeSize; i++)
                    {
                        nextGenerationFlag[i] = false;
                    }
                    for (int i = 0; i < populationSize; i++)
                    {
                        nextGenerationFlag[populationGenesIndex[i]] = true;
                    }
                    int idx = 0;
                    for (int i = 0; i < populationSize * 3; i++)
                    {
                        if (!nextGenerationFlag[i])
                        {
                            emptyGenesIndex[idx] = i;
                            idx++;
                        }
                        if (idx == populationSize * 2)
                        {
                            break;
                        }
                    }
                    break;
            }
        }
        public void ReallocateMemory()
        {
            int ThreeSize = 3 * populationSize;
            // Array to store population index 
            populationGenesIndex = new int[populationSize];
            emptyGenesIndex = new int[ThreeSize - populationSize];
            // Reallocate memory if populationsize is changed
            chromosomes = new T[ThreeSize][];
            objectiveValue = new double[ThreeSize];
            //AbsoluteObjValues = new double[ThreeSize];
            fitnessValues = new double[ThreeSize];
            nextGenerationFlag = new bool[ThreeSize];

            int idx = 0;
            indices = new int[ThreeSize];
            for (int i = 0; i < ThreeSize; i++)
            {
                indices[i] = i;
                chromosomes[i] = new T[numberOfGenes];
                if (i < populationSize) populationGenesIndex[i] = i;
                else { emptyGenesIndex[idx] = i; idx++; }
            }


            mutatedFlags = new bool[populationSize][];
            for (int i = 0; i < populationSize; i++)
            {
                mutatedFlags[i] = new bool[numberOfGenes];
            }
        }
        public void Reset()
        {
            if (populationGenesIndex == null)
            {
                ReallocateMemory();
            }
            else if (populationGenesIndex.Length != populationSize)
            {
                ReallocateMemory();
            }
            else 
            {
                // Array to store population index 
                int idx = 0;
                int ThreeSize = 3 * populationSize;
                for (int i = 0; i < ThreeSize; i++)
                {
                    if (i < populationSize) populationGenesIndex[i] = i;
                    else { emptyGenesIndex[idx] = i; idx++; }
                }
            }
            //numberOfCrossoveredChildren = numberOfMutatedChildren = 0;
            soFarTheBestObjArr = new double[iterationLimit + 1];
            iterationObjectiveAverageArr = new double[iterationLimit + 1];
            iterationBestObjArr = new double[iterationLimit + 1];
            iterationCount = 0;
            // initialize initial population
            InitializePopulation();
            // evaluate initial population
            for (int i = 0; i < populationSize; i++)
            {
                objectiveValue[i] = theObjectiveFunction(chromosomes[i]);
            }
        }

        protected virtual void InitializePopulation()
        {
            throw new NotImplementedException();
        }

        public void RunOneIteration(RichTextBox rtb = null, bool isAll = true)
        {
            
            PerformCrossoverOperation();
            PerformMutationOperation();

            numberAll = populationSize + numberOfCrossoveredChildren + numberOfMutatedChildren;
            if (rtb != null)
            {
                WriteProcessToRichTextBoxMain(rtb, isAll);
            }

            PerformSelectionOperation();

            soFarTheBestObjArr[iterationCount] = soFarTheBestObj;
            iterationBestObjArr[iterationCount] = iterationBestObj;
            iterationObjectiveAverageArr[iterationCount] = iterationObjectiveAverage;
            iterationCount++;
        }

        private void PerformMutationOperation()
        {
            int childIdx;
            switch (mutationType)
            {
                case MutationMode.PopulationSizeBased:
                    numberOfMutatedChildren = (int) (mutationRate * populationSize);
                    ShuffleIndiciesArray(populationGenesIndex);
                    for (int i = 0; i <numberOfMutatedChildren; i++)
                    {
                        childIdx = emptyGenesIndex[i+numberOfCrossoveredChildren];
                        GenerateAMutatedChild(populationGenesIndex[i], childIdx);
                        objectiveValue[childIdx] = theObjectiveFunction(chromosomes[childIdx]);
                    }
                    break;
                case MutationMode.GeneNumberBased:
                    numberOfMutatedChildren = 0;
                    int limit = numberOfGenes * populationSize;
                    int numberOfMutatedGenes = (int)(mutationRate * limit);
                    foreach (bool[] ary in mutatedFlags)
                    {
                        for (int i = 0; i < numberOfGenes; i++)
                        {
                            ary[i] = false;
                        }
                    }
                    int rand; int rowIdx; int colIdx;
                    for (int i = 0; i < numberOfMutatedGenes; i++)
                    {
                        rand = randomizer.Next(limit);
                        rowIdx = rand / numberOfGenes;
                        colIdx = rand % numberOfGenes;
                        mutatedFlags[rowIdx][colIdx] = true;
                    }

                    for (int r = 0; r < populationSize; r++)
                    {
                        bool hit = false;
                        for (int c = 0;c<numberOfGenes;c++)
                        {
                            if (mutatedFlags[r][c])
                            {
                                hit = true;
                                break;
                            }
                        }
                        if (hit)
                        {
                            childIdx = emptyGenesIndex[numberOfMutatedChildren + numberOfCrossoveredChildren];
                            GenerateAGeneBasedMutatedChild(populationGenesIndex[r], childIdx, r);
                            objectiveValue[childIdx] = theObjectiveFunction(chromosomes[childIdx]);
                            numberOfMutatedChildren++;
                        }
                    }
                    break;

            }
        }

        public virtual void GenerateAGeneBasedMutatedChild(int parentIdx, int childIdx, int FlagRow)
        {
            // refer to mutated flags for gene value mutation
            throw new NotImplementedException();
        }

        public virtual void GenerateAMutatedChild(int parentIdx, int childIdx)
        {
            throw new NotImplementedException();
        }

        private void PerformCrossoverOperation()
        {
            // Shuffle indicies arry to arrange parent IDs
            ShuffleIndiciesArray(populationGenesIndex);
            numberOfCrossoveredChildren = (int)( crossoverRate * populationSize);
            if (numberOfCrossoveredChildren % 2 == 1) { numberOfCrossoveredChildren ++; }
            if (numberOfCrossoveredChildren > populationSize) { numberOfCrossoveredChildren-=2; }
            int child1Idx, child2Idx;
            for (int i=0;i< numberOfCrossoveredChildren; i+=2)
            {
                child1Idx = emptyGenesIndex[i];
                child2Idx = emptyGenesIndex[i+1];
                GenerateAPairOfCrossover(populationGenesIndex[i], populationGenesIndex[i + 1]
                    , child1Idx, child2Idx);
                //compute obj value of child 1 and 2
                objectiveValue[child1Idx] = theObjectiveFunction(chromosomes[child1Idx]);
                objectiveValue[child2Idx] = theObjectiveFunction(chromosomes[child2Idx]);
            }
        }

        public virtual void GenerateAPairOfCrossover(int fatherIdx, int motherIdx, int child1Idx, int child2Idx)
        {
            //throw new NotImplementedException();
        }
        public void RunToEnd(RichTextBox rtb, int r)
        {
            if (r == 0)
            {
                int start = iterationCount;
                do
                {
                    RunOneIteration();
                } while (iterationCount < iterationLimit);
                for (int i = start; i < iterationCount; i++)
                {
                    average.Points.AddXY(i,iterationObjectiveAverageArr[i]);
                    iterBest.Points.AddXY(i,iterationBestObjArr[i]);
                    soFarBest.Points.AddXY(i, soFarTheBestObjArr[i]);
                }
                return;
            }
            do
            {
                RunOneIteration();
                if (iterationCount % r == 0)
                {
                    rtb.AppendText($"-----Iteration{iterationCount}--------------------\n");
                    WriteProcessToRichTextBoxMain(rtb, true);
                    rtb.ScrollToCaret();
                    DrawProgressToChart();
                    if (chart != null) chart.Update();
                }
            } while (iterationCount < iterationLimit);
        }
        protected void ShuffleIndiciesArray(int[] array)
        {
            int n = array.Length;
            int k;
            int temp;
            while (n > 1)
            {
                k = randomizer.Next(n--);
                temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
        public int GetChromosomesIndexFromRow(int r)
        {
            if (r < populationGenesIndex.Length)
            {
                return populationGenesIndex[r];
            }
            else
            {
                return emptyGenesIndex[r - populationGenesIndex.Length];
            }
        }
        public T[] GetChromosomesFromRow(int r)
        {
            return chromosomes[GetChromosomesIndexFromRow(r)];
        }
        public double GetObjFromRow(int r)
        {
            return objectiveValue[GetChromosomesIndexFromRow(r)];
        }
        public void WriteProcessToRichTextBoxMain(RichTextBox rtb, bool isAll)
        {
            int EndRow = NumberAll;
            if (isAll == false) EndRow = populationSize;
            for (int r = 0; r < EndRow; r++)
            {
                if (r < PopulationSize)
                    rtb.AppendText("P" + r.ToString("000") + "  ");
                else if (r < PopulationSize+numberOfCrossoveredChildren)
                    rtb.AppendText("C" + r.ToString("000") + "  ");
                else if (r < NumberAll)
                    rtb.AppendText("M" + r.ToString("000") + "  ");

                for (int c = 0; c < NumberOfGenes; c++)
                {
                    rtb.AppendText(GetChromosomesFromRow(r)[c].ToString() + " ");
                }

                rtb.AppendText($" obj = {GetObjFromRow(r)}");
                rtb.AppendText("\n");
            }
        }
        public void WriteBestToRichTextBox(RichTextBox rtb, bool ShowLine = true)
        {
            if(ShowLine)
                rtb.AppendText("====================\n");
            for (int c = 0; c < NumberOfGenes; c++)
            {
                rtb.AppendText(SoFarTheBestSolution[c].ToString() + " ");
            }
            rtb.AppendText($" best obj = {SoFarTheBestObjective}");
        }
        public void DrawProgressToChart()
        {
            if (average != null)
                average.Points.AddXY(iterationCount, iterationObjectiveAverage);
            if (iterBest != null)
                iterBest.Points.AddXY(iterationCount, iterationBestObj);
            if (soFarBest != null)
                soFarBest.Points.AddXY(iterationCount, soFarTheBestObj);
        }
        public void SetUpChart(Series average, Series iterBest, Series soFarBest, Chart chart)
        {
            this.average = average;
            this.iterBest = iterBest;
            this.soFarBest = soFarBest;
            this.chart = chart;
        }
    }
}
