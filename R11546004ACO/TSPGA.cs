using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GALibrary
{
    public class TSPGA : GeneticGASolver<int>
    {
        // Permutation Crossover
        protected int selectedValue;
        protected int i2;
        protected int i1;
        protected int i3;
        protected int temp;
        protected int num;
        protected int[] m; // mapping target for two-cut pmx crossover
        protected int v1;
        protected int v2;
        protected int[] rand;
        protected int[] P1Idx;
        protected int[] P2Idx;
        protected int[] usedValue;
        protected int shift = 0;
        protected int max;
        protected double min;
        protected int minValue;
        protected int len;
        protected int idx;
        protected double[,] fromToMat;
        protected int i2Pos;
        protected int c;
        protected int[][] neighbor;
        public TSPGA(int numberOfVariables, OptimizationType optimizationType, ObjectiveFunction<int> encodingFunction, double[,] fromToMat)
            : base(numberOfVariables, optimizationType, encodingFunction)
        {
            this.fromToMat = fromToMat;
            c = Math.Min(3, numberOfVariables);
            neighbor = new int[5][];
            for (int i = 0; i < 5; i++)
            {
                neighbor[i] = new int[numberOfVariables];
            }
        }
        void ShuffleToInitializeAChromosome(int r)
        {
            for (int c = 0; c < numberOfGenes; c++)
            {
                selectedValue = randomizer.Next(numberOfGenes);
                temp = chromosomes[r][c];
                chromosomes[r][c] = chromosomes[r][selectedValue];
                chromosomes[r][selectedValue] = temp;
            }
        }
        protected override void InitializePopulation()
        {

            P1Idx = new int[numberOfGenes];
            P2Idx = new int[numberOfGenes];
            rand = new int[numberOfGenes];
            m = new int[numberOfGenes];
            usedValue = new int[numberOfGenes];
            for (int r = 0; r < populationSize; r++)
            {
                for (int c = 0; c < numberOfGenes; c++)
                {
                    chromosomes[r][c] = c;
                }
                ShuffleToInitializeAChromosome(r);
            }
        }
        public override void GenerateAPairOfCrossover(int fatherIdx, int motherIdx, int child1Idx, int child2Idx)
        {

            HeurCrossOver(fatherIdx, motherIdx, child1Idx);
            HeurCrossOver(motherIdx, fatherIdx, child2Idx);
        }
        private void HeurCrossOver(int p1, int p2, int childIdx)
        {
            selectedValue = randomizer.Next(numberOfGenes); // choosen value
            for (int i = 0; i < numberOfGenes; i++)
            {
                P1Idx[chromosomes[p1][i]] = i; // Value to Index
                P2Idx[chromosomes[p2][i]] = i;
                usedValue[i] = 0; // indicating number i is used or not
            }
            chromosomes[childIdx][0] = selectedValue;
            usedValue[selectedValue] = 1;
            for (int i =1;i<numberOfGenes;i++)
            {
                min = double.MaxValue;
                if (P1Idx[selectedValue] > 0)
                {
                    num = chromosomes[p1][P1Idx[selectedValue] - 1];
                    if (usedValue[num] == 0 && fromToMat[P1Idx[selectedValue],num] < min)
                    {
                        min = fromToMat[P1Idx[selectedValue], num];
                        minValue = num;
                    }
                }
                if (P1Idx[selectedValue] < numberOfGenes-1)
                {
                    num = chromosomes[p1][P1Idx[selectedValue] + 1];
                    if (usedValue[num] == 0 && fromToMat[P1Idx[selectedValue], num] < min)
                    {
                        min = fromToMat[P1Idx[selectedValue], num];
                        minValue = num;
                    }
                }
                if (P2Idx[selectedValue] > 0)
                {
                    num = chromosomes[p2][P2Idx[selectedValue] - 1];
                    if (usedValue[num] == 0 && fromToMat[P2Idx[selectedValue], num] < min)
                    {
                        min = fromToMat[P2Idx[selectedValue], num];
                        minValue = num;
                    }
                }
                if (P2Idx[selectedValue] < numberOfGenes - 1)
                {
                    num = chromosomes[p2][P2Idx[selectedValue] + 1];
                    if (usedValue[num] == 0 && fromToMat[P2Idx[selectedValue], num] < min)
                    {
                        min = fromToMat[P2Idx[selectedValue], num];
                        minValue = num;
                    }
                }
                if (min == double.MaxValue)
                {
                    for(int j =0; j< numberOfGenes; j++)
                    {
                        if (usedValue[j] == 0)
                        {
                            chromosomes[childIdx][i] = j;
                            usedValue[j] = 1;
                            break;
                        }
                    }
                }
                else
                {
                    chromosomes[childIdx][i] = minValue;
                    usedValue[minValue] = 1;
                }
            }
        }
        public override void GenerateAMutatedChild(int parentIdx, int childIdx)
        {
            temp = randomizer.Next(2);
            if (c < 3||temp == 0)
            {
                PM(parentIdx, childIdx);
            }
            else
            {
                HeurMutation(parentIdx, childIdx);
            }
        }
        public void ArrSwap(int[] objectArray, int x, int y)
        {
            // swap index x and y
            temp = objectArray[x];
            objectArray[x] = objectArray[y];
            objectArray[y] = temp;
        }
        private void HeurMutation(int parentIdx, int childIdx)
        {
            i1 = i2 = i3 = 0;
            i1 = randomizer.Next(numberOfGenes);
            while (i1==i2) { i2 = randomizer.Next(numberOfGenes); }
            while (i3 == i2 || i3== i1) { i3 = randomizer.Next(numberOfGenes); }
            //Console.WriteLine(i1);
            //Console.WriteLine(i2);
            //Console.WriteLine(i3);

            if (i1 > i2) { temp = i1; i1 = i2; i2 = temp; }
            if (i1 > i3) { temp = i1; i1 = i3; i3 = temp; }
            if (i2 > i3) { temp = i3; i3 = i2; i2 = temp; }
            min = double.MaxValue;
            for(int i = 0; i < 5; i++)
            {
                for (int j = 0; j < numberOfGenes; j++)
                {
                    neighbor[i][j] = chromosomes[parentIdx][j];
                }
                if (i == 0)
                { ArrSwap(neighbor[i], i2, i3); }
                else if (i == 1)
                { ArrSwap(neighbor[i], i2, i3); ArrSwap(neighbor[i], i1, i3); }
                else if (i == 2)
                { ArrSwap(neighbor[i], i2, i1); }
                else if (i == 3)
                { ArrSwap(neighbor[i], i1, i3); }
                else if (i == 4)
                { ArrSwap(neighbor[i], i1, i3); ArrSwap(neighbor[i], i2, i3); }
                //Console.WriteLine("[{0}]", string.Join(", ", neighbor[i]));
                //Console.WriteLine(theObjectiveFunction(neighbor[i]));
                if (min > theObjectiveFunction(neighbor[i]))
                {
                    min = theObjectiveFunction(neighbor[i]);
                    idx = i;
                }
            }
            //Console.WriteLine(idx);
            for (int i = 0;i < numberOfGenes; i++)
            {
                chromosomes[childIdx][i] = neighbor[idx][i];
            }


        }
        private void PM(int parentIdx, int childIdx)
        {
            i1 = randomizer.Next(numberOfGenes);
            i2 = randomizer.Next(numberOfGenes);
            max = Math.Max(i1, i2);
            min = Math.Min(i1, i2);
            len = randomizer.Next(numberOfGenes - max - 1);
            len += 1;
            shift = -len;
            if (i2 >= i1)
            { shift = len; }

            for (int i = 0; i < numberOfGenes; i++)
            {
                if (i < min || i >= max + len)
                {
                    chromosomes[childIdx][i] = chromosomes[parentIdx][i];
                }
                else
                {
                    if (i >= i2 && i < i2 + len)
                    {
                        chromosomes[childIdx][i] = chromosomes[parentIdx][i1 + i - i2];
                    }
                    else
                    {
                        chromosomes[childIdx][i] = chromosomes[parentIdx][i + shift];
                    }
                }
            }

        }
    }
}