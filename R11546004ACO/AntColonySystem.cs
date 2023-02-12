using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace R11546004ACO
{
    public enum UpdateMode
    {
        Stepwise,
        Trailwise
    }
    public class AntColonySystem : AntColonyOptimizier
    {

        protected double threshold = 0.8;
        protected UpdateMode updateType = UpdateMode.Stepwise;

        [Category("Optimizier Settings")]
        [Description("Threshold deciding the probabilty using deterministic path solution")]
        public double Threshold { get => threshold; set { if (value >= 0 && value <= 1) threshold = value; } }
        [Category("Optimizier Settings")]
        [Description("Type of ways to update pheromone, per step or per trail")]
        public UpdateMode UpdateType { get => updateType; set => updateType = value; }

        public AntColonySystem(int numberOfVariables, OptimizationType opType, ObjectiveFunction objFun, double[,] heurMat) : base(numberOfVariables, opType, objFun, heurMat)
        {
            fitnessOfCandidate = new double[numberOfVariables];
        }
        protected override void UpdatePheromoneMatrix()
        {
            for (int i = 0; i < numberOfVariables; i++)
            {
                for (int j = 0; j < numberOfVariables; j++)
                {
                    pheromoneMatrix[i, j] *=  (1-evaporationRate);
                }
            }
        }
        protected int temp;
        public void ArrSwap(int[] objectArray, int x, int y)
        {
            // swap index x and y
            temp = objectArray[x];
            objectArray[x] = objectArray[y];
            objectArray[y] = temp;
        }
        protected int fromIdx;
        protected int toIdx;
        protected int ran;
        protected double[] fitnessOfCandidate;
        protected int fromCity;
        protected int toCity;
        protected double maxFitnessValue;
        protected int maxFitnessCityIdx;
        protected double sumOfFitness;
        protected double wheelRandom;
        protected override void AllAntCreateSolution()
        {

            for (int i = 0; i < numberOfAnts; i++)
            {
                for (int j = 0; j < numberOfVariables-1; j++)
                {
                    if (j == 0)
                    {
                        ran = randomizer.Next(numberOfVariables - j);
                        fromIdx = numberOfVariables - j - 1;
                        ArrSwap(candidateCities, ran, fromIdx);
                        fromCity = candidateCities[fromIdx];
                    }
                    else
                    {
                        fromIdx = numberOfVariables - j - 1;
                        fromCity = candidateCities[fromIdx];
                    }

                    if (randomizer.NextDouble() > threshold)
                    {
                        maxFitnessValue = double.MinValue;
                        // deterministic choose the smallest 
                        for (int k = 0; k < fromIdx; k++)
                        {
                            toCity = candidateCities[k];
                            fitnessOfCandidate[k] = Math.Pow(heuristicMatrix[fromCity, toCity], heuristicFactor) * Math.Pow(pheromoneMatrix[fromCity, toCity], PheromoneFactor);
                            if(fitnessOfCandidate[k] > maxFitnessValue)
                            {
                                maxFitnessValue = fitnessOfCandidate[k];
                                maxFitnessCityIdx = k;
                            }
                        }
                        ArrSwap(candidateCities, maxFitnessCityIdx, fromIdx - 1);
                    }
                    else
                    {
                        sumOfFitness = 0.0;
                        // 輪盤法
                        for (int k = 0; k < fromIdx; k++)
                        {
                            toCity = candidateCities[k];
                            sumOfFitness += Math.Pow(heuristicMatrix[fromCity, toCity], heuristicFactor) * Math.Pow(pheromoneMatrix[fromCity, toCity], PheromoneFactor);
                            fitnessOfCandidate[k] = sumOfFitness;
                        }
                        wheelRandom = randomizer.NextDouble() * sumOfFitness;
                        for (int k = 0; k < fromIdx; k++)
                        {
                            if (wheelRandom <= fitnessOfCandidate[k])
                            {
                                maxFitnessCityIdx = k;
                                break;
                            }
                        }
                        ArrSwap(candidateCities, maxFitnessCityIdx, fromIdx - 1);
                    }
                    if(updateType == UpdateMode.Stepwise)
                    {
                        UpdatePheromoneMatrixOnPosition_StepWise(fromCity, candidateCities[fromIdx - 1]);
                    }
                }

                for (int j = 0; j < numberOfVariables; j++)
                {
                    solutions[i][j] = candidateCities[numberOfVariables - j - 1];
                }
                if (updateType == UpdateMode.Trailwise)
                {
                    UpdatePheromoneMatrix_Trailwise(i);
                }
            }
        }

        private void UpdatePheromoneMatrix_Trailwise(int i)
        {
            for (int j = 0; j < numberOfVariables-1; j++)
            {
                UpdatePheromoneMatrixOnPosition_StepWise(solutions[i][j], solutions[i][j + 1]);
            }
        }

        private void UpdatePheromoneMatrixOnPosition_StepWise(int from_City, int to_City)
        {
            pheromoneMatrix[from_City, to_City] += dropAmount;
            pheromoneMatrix[to_City, from_City] += dropAmount;
        }
    }
}