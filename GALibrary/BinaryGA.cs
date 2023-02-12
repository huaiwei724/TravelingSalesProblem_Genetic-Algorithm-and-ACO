using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GALibrary
{
    public class BinaryGA : GeneticGASolver<byte>
    {
        int cutPos;
        int mutatePos;
        int max;
        int min;
        int cutPos1;
        int cutPos2;
        int[] cutpos;
        int n;

        [Category("Mutation Settings")]
        [Description("Type of Mutation")]
        public MutationMode MutationType
        {
            get => mutationType;
            set
            {
                mutationType = value;
                if (mutationType == MutationMode.GeneNumberBased) mutationRate = 0.05;
                else mutationRate = 0.3;
            }
        }

        [Category("Crossover Settings")]
        [Description("Method to perform Crossover Operation")]
        public CutMode CrossOverCut { set; get; } = CutMode.OnePointCut;

        public BinaryGA(int numberOfVariables, OptimizationType optimizationType, ObjectiveFunction<byte> encodingFunction)
            : base(numberOfVariables, optimizationType, encodingFunction)
        {
        }
        protected override void InitializePopulation()
        {
            for(int r = 0; r < populationSize; r++)
            {
                for(int c = 0; c< numberOfGenes; c++)
                {
                    chromosomes[r][c] = (byte)randomizer.Next(2);
                }
            }
            cutpos = new int[numberOfGenes];

        }

        public override void GenerateAPairOfCrossover(int fatherIdx, int motherIdx, int child1Idx, int child2Idx)
        {
            switch (CrossOverCut)
            {
                case CutMode.OnePointCut:
                    cutPos = randomizer.Next(numberOfGenes);
                    for (int c = 0; c < numberOfGenes; c++)
                    {
                        if (c < cutPos)
                        {
                            chromosomes[child1Idx][c] = chromosomes[fatherIdx][c];
                            chromosomes[child2Idx][c] = chromosomes[motherIdx][c];
                        }
                        else
                        {
                            chromosomes[child1Idx][c] = chromosomes[motherIdx][c];
                            chromosomes[child2Idx][c] = chromosomes[fatherIdx][c];
                        }
                    }


                    break;
                case CutMode.TwoPointCut:
                    cutPos1 = randomizer.Next(numberOfGenes);
                    cutPos2 = randomizer.Next(numberOfGenes);
                    min = Math.Min(cutPos1, cutPos2);
                    max = Math.Max(cutPos1, cutPos2);
                    for (int c = 0; c < numberOfGenes; c++)
                    {
                        if (c < min)
                        {
                            chromosomes[child1Idx][c] = chromosomes[fatherIdx][c];
                            chromosomes[child2Idx][c] = chromosomes[motherIdx][c];
                        }
                        else if (c <= max)
                        {
                            chromosomes[child1Idx][c] = chromosomes[motherIdx][c];
                            chromosomes[child2Idx][c] = chromosomes[fatherIdx][c];
                        }
                        else
                        {
                            chromosomes[child1Idx][c] = chromosomes[fatherIdx][c];
                            chromosomes[child2Idx][c] = chromosomes[motherIdx][c];
                        }
                    }
                    break;
                case CutMode.NPointCut:
                    n = 2 + randomizer.Next(numberOfGenes/4);
                    if (n < numberOfGenes) n = numberOfGenes - 3;
                    for (int i = 1; i< n; i++)
                    {
                        cutpos[i] = randomizer.Next(numberOfGenes);
                    }
                    Array.Sort(cutpos);
                    for (int c = 0; c < numberOfGenes; c++)
                    {
                        int count_smaller = 0;
                        for (int i =0; i < n; i++)
                        {
                            if (c < i) count_smaller++;
                            else break;
                        }

                        if (count_smaller%2==1)
                        {
                            chromosomes[child1Idx][c] = chromosomes[fatherIdx][c];
                            chromosomes[child2Idx][c] = chromosomes[motherIdx][c];
                        }
                        else if (count_smaller % 2 == 0)
                        {
                            chromosomes[child1Idx][c] = chromosomes[motherIdx][c];
                            chromosomes[child2Idx][c] = chromosomes[fatherIdx][c];
                        }
                    }

                    break;
            }
        }
        public override void GenerateAGeneBasedMutatedChild(int parentIdx, int childIdx, int FlagRow)
        {
            // refer to mutated Flag to mutate gene values

            for (int c = 0; c < numberOfGenes; c++)
            {
                chromosomes[childIdx][c] = chromosomes[parentIdx][c];

                if (mutatedFlags[FlagRow][c])
                {
                    if (chromosomes[childIdx][c] == 1) chromosomes[childIdx][c] = 0;
                    else chromosomes[childIdx][c] = 1;
                } 
            }
        }
        
        public override void GenerateAMutatedChild(int parentIdx, int childIdx)
        {
            mutatePos = randomizer.Next(numberOfGenes);
            for (int c = 0; c < numberOfGenes; c++)
            {
                chromosomes[childIdx][c] = chromosomes[parentIdx][c];
            }
            if (chromosomes[childIdx][mutatePos] == 1) chromosomes[childIdx][mutatePos] = 0;
            else chromosomes[childIdx][mutatePos] = 1;
        }

    }
}