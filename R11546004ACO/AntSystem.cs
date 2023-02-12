using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace R11546004ACO
{
    public class AntSystem : AntColonyOptimizier
    {
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
        protected double updatePheromoneConst = 100;
        [Category("Optimizier Settings")]
        [Description("The constants Q that effects how much pheromone is drop when its update.")]
        public double UpdatePheromoneConst { get => updatePheromoneConst; set => updatePheromoneConst = value; }

        public AntSystem(int numberOfVariables, OptimizationType opType, ObjectiveFunction objFun, double[,] heur) : base(numberOfVariables, opType, objFun, heur)
        {
            fitnessOfCandidate = new double[numberOfVariables];
        }
        protected override void UpdatePheromoneMatrix()
        {
            // evaporate
            for (int i = 0; i < numberOfVariables; i++)
            {
                for (int j = 0; j < numberOfVariables; j++)
                {
                    pheromoneMatrix[i, j] *= (1 - evaporationRate);
                }
            }
            // update base on the distance each ants goes
            for (int i = 0; i < numberOfAnts; i++)
            {
                for (int j = 0; j < numberOfVariables-1; j++)
                {
                    pheromoneMatrix[solutions[i][j], solutions[i][j + 1]] += updatePheromoneConst/objectives[i];
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
        protected override void AllAntCreateSolution()
        {

            for (int i = 0; i < numberOfAnts; i++)
            {
                for (int j = 0; j < numberOfVariables - 1; j++)
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

                for (int j = 0; j < numberOfVariables; j++)
                {
                    solutions[i][j] = candidateCities[numberOfVariables - j - 1];
                }
            }
        }
    }
}