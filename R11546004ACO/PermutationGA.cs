using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GALibrary
{
    public class PermutationGA : GeneticGASolver<int>
    {
        // Permutation Crossover
        protected int i1;
        protected int i2;
        protected int temp;
        protected int[] m; // mapping target for two-cut pmx crossover
        protected int v1;
        protected int v2;
        protected int[] rand;
        protected int[] P1Idx;
        protected int[] P2Idx;
        protected int[] subtourIdx;
        int shift = 0;
        int max;
        int min;
        int len;
        int idx;

        [Category("Crossover Settings")]
        [Description("Method to perform Crossover Operation")]
        public PermutationCrossoverOperators CrossoverOperator { set; get; } = PermutationCrossoverOperators.PartialMappedCrossover;
        
        [Category("Mutation Settings")]
        [Description("Type of Mutation")]
        public PermutationMutationOperators MutationOperator { set; get; } = PermutationMutationOperators.Swapped;
        public PermutationGA(int numberOfVariables, OptimizationType optimizationType, ObjectiveFunction<int> encodingFunction)
            : base(numberOfVariables, optimizationType, encodingFunction)
        {
        }
        void ShuffleToInitializeAChromosome(int r)
        {
            for(int c = 0; c < numberOfGenes; c++)
            {
                i1 = randomizer.Next(numberOfGenes);
                temp = chromosomes[r][c];
                chromosomes[r][c] = chromosomes[r][i1];
                chromosomes[r][i1] = temp;
            }
        }
        protected override void InitializePopulation()
        {
            
            P1Idx = new int[numberOfGenes];
            P2Idx = new int[numberOfGenes];
            rand = new int[numberOfGenes];
            m = new int[numberOfGenes];
            subtourIdx = new int[numberOfGenes];
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
            switch (CrossoverOperator)
            {
                case PermutationCrossoverOperators.PartialMappedCrossover:
                    PMX(fatherIdx, motherIdx, child1Idx, child2Idx);
                    break;
                case PermutationCrossoverOperators.OrderCrossover:
                    OX(fatherIdx, motherIdx, child1Idx, child2Idx);
                    break;
                case PermutationCrossoverOperators.CycleCrossover:
                    CX(fatherIdx, motherIdx, child1Idx, child2Idx);
                    break;
                case PermutationCrossoverOperators.OrderBasedCrossover:
                    ObX(fatherIdx, motherIdx, child1Idx, child2Idx);
                    break;
                case PermutationCrossoverOperators.SubtourExchangeCrossover:
                    SX(fatherIdx, motherIdx, child1Idx, child2Idx);
                    break;
                case PermutationCrossoverOperators.PositionBasedCrossover:
                    PbX(fatherIdx, motherIdx, child1Idx, child2Idx);
                    break;
            }
        }
        public override void GenerateAMutatedChild(int parentIdx, int childIdx)
        {
            switch (MutationOperator)
            {
                case PermutationMutationOperators.Displacement:
                    PM(parentIdx, childIdx);
                    break;
                case PermutationMutationOperators.Insertion:
                    InsertM(parentIdx, childIdx);
                    break;
                case PermutationMutationOperators.Inversion:
                    InversionM(parentIdx, childIdx);
                    break;
                case PermutationMutationOperators.ReciprocalExchange:
                    REM(parentIdx, childIdx);
                    break;
                case PermutationMutationOperators.Swapped:
                    REM(parentIdx, childIdx);
                    break;
            }
        }
        private void REM(int parentIdx, int childIdx)
        {
            i1 = randomizer.Next(numberOfGenes);
            i2 = randomizer.Next(numberOfGenes);

            for(int i = 0; i < numberOfGenes; i++)
            {
                chromosomes[childIdx][i] = chromosomes[parentIdx][i];
            }
            chromosomes[childIdx][i1] = chromosomes[parentIdx][i2];
            chromosomes[childIdx][i2] = chromosomes[parentIdx][i1];
        }

        private void InversionM(int parentIdx, int childIdx)
        {
            i1 = randomizer.Next(numberOfGenes);
            i2 = randomizer.Next(numberOfGenes);

            for (int i = 0; i < numberOfGenes; i++)
            {
                if(i>=i1 && i <= i2)
                {
                    chromosomes[childIdx][i] = chromosomes[parentIdx][i2-i+i1];
                }
                else
                    chromosomes[childIdx][i] = chromosomes[parentIdx][i];
            }
        }

        private void InsertM(int parentIdx, int childIdx)
        {
            i1 = randomizer.Next(numberOfGenes);
            i2 = randomizer.Next(numberOfGenes);
            shift = 0;
            if (i2 >= i1)
            {
                for (int i = 0; i < numberOfGenes; i++)
                {
                    if (i < i1 || i >i2)
                    {
                        chromosomes[childIdx][i] = chromosomes[parentIdx][i];
                    }
                    else
                    {
                        if (i == i2)
                        {
                            chromosomes[childIdx][i] = chromosomes[parentIdx][i1];
                        }
                        else
                        {
                            chromosomes[childIdx][i] = chromosomes[parentIdx][i+1];
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < numberOfGenes; i++)
                {
                    if (i > i1 || i < i2)
                    {
                        chromosomes[childIdx][i] = chromosomes[parentIdx][i];
                    }
                    else
                    {
                        if (i == i2)
                        {
                            chromosomes[childIdx][i] = chromosomes[parentIdx][i1];
                        }
                        else
                        {
                            chromosomes[childIdx][i] = chromosomes[parentIdx][i - 1];
                        }
                    }
                }
            }
        }

        private void PM(int parentIdx, int childIdx)
        {
            i1 = randomizer.Next(numberOfGenes);
            i2 = randomizer.Next(numberOfGenes);
            max = Math.Max(i1, i2);
            min = Math.Min(i1, i2);
            len = randomizer.Next(numberOfGenes-max-1);
            len += 1;
            shift =  -len;
            if (i2 >= i1)
            { shift = len; }

            for (int i = 0; i < numberOfGenes; i++)
            {
                if (i < min || i >= max+len)
                {
                    chromosomes[childIdx][i] = chromosomes[parentIdx][i];
                }
                else
                {
                    if (i >= i2 && i < i2 +len)
                    {
                        chromosomes[childIdx][i] = chromosomes[parentIdx][i1+i-i2];
                    }
                    else
                    {
                        chromosomes[childIdx][i] = chromosomes[parentIdx][i + shift];
                    }
                }
            }
            
        }

        public void OX(int p1, int p2, int c1, int c2)
        {
            i1 = randomizer.Next(numberOfGenes);
            i2 = randomizer.Next(numberOfGenes);
            if (i1 > i2)
            {
                temp = i1;
                i1 = i2;
                i2 = temp;
            }
            HalfOX(p1, p2, c1);
            HalfOX(p2, p1, c2);
        }
        public void HalfOX(int p1,int p2,int c1)
        {
            for (int i = 0; i < numberOfGenes; i++)
            {
                m[i] = -1;
            }
            for (int i = i1; i < i2; i++)
            {
                m[chromosomes[p1][i]] = 0;
            }
            idx = 0;
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (i>=i1&&i<i2)
                {
                    chromosomes[c1][i] = chromosomes[p1][i];
                }
                else
                {
                    while(true)
                    {
                        if (m[chromosomes[p2][idx]] == 0)
                        {
                            idx++;
                        }
                        else { break; }
                    }
                    chromosomes[c1][i] = chromosomes[p2][idx];
                    idx++;
                }
            }
        }
        public void PbX(int p1, int p2, int c1, int c2)
        {
            for (int i = 0; i < numberOfGenes; i++)
            {
                rand[i] = 0;
            }
            i1 = randomizer.Next(numberOfGenes);
            for (int i = 0; i < i1; i++)
            {
                rand[randomizer.Next(numberOfGenes)] = 1;
            }
            HalfPbX(p1, p2, c1);
            HalfPbX(p2, p1, c2);
        }
        public void HalfPbX(int p1, int p2, int c1)
        {
            for (int i = 0; i < numberOfGenes; i++)
            {
                m[i] = -1; // numbers not selected in p1
            }
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (rand[i] == 1)
                {
                    m[chromosomes[p1][i]] = 0; // numbers selected in p1
                }
            }
            idx = 0;
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (rand[i] == 1) // if position is selected, insert from p1
                {
                    chromosomes[c1][i] = chromosomes[p1][i]; 
                }
                else // else find the first p2 that is not insert yet
                {
                    while (true)
                    {
                        if (m[chromosomes[p2][idx]] == 0)
                        {
                            idx++;
                        }
                        else { break; }
                    }
                    chromosomes[c1][i] = chromosomes[p2][idx];
                    idx++;
                }
            }
        }
        public void ObX(int p1, int p2, int c1, int c2)
        {
            for (int i = 0; i < numberOfGenes; i++)
            {
                rand[i] = 0;
            }
            i1 = randomizer.Next(numberOfGenes);
            for (int i = 0; i < i1; i++)
            {
                rand[randomizer.Next(numberOfGenes)] = 1;
            }
            HalfObX(p1, p2, c1);
            HalfObX(p2, p1, c2);
        }
        public void HalfObX(int p1, int p2, int c1)
        {
            for (int i = 0; i < numberOfGenes; i++)
            {
                m[i] = -1; // numbers not selected in p1
            }
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (rand[i] == 1)
                {
                    m[chromosomes[p1][i]] = 0; // numbers selected in p1
                }
            }
            idx = 0;
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (m[chromosomes[p2][i]] == -1) // if position is selected, insert from p1
                {
                    chromosomes[c1][i] = chromosomes[p2][i];
                }
                else // else find the first p2 that is not insert yet
                {
                    while (true)
                    {
                        if (m[chromosomes[p1][idx]] == -1)
                        {
                            idx++;
                        }
                        else { break; }
                    }
                    chromosomes[c1][i] = chromosomes[p1][idx];
                    idx++;
                }
            }
        }
        public void CX(int p1, int p2, int c1, int c2)
        {
            i1 = randomizer.Next(numberOfGenes); // find cycle starting in i1
            for (int i = 0; i < numberOfGenes; i++)
            {
                P1Idx[chromosomes[p1][i]] = i; // Value to Index
                P2Idx[chromosomes[p2][i]] = i;
                m[i] = 0; 
            }
            idx = i1;
            while (true)
            {
                if (m[idx] == 0) // still not a cycle
                {
                    m[idx] = 1;
                    idx = P2Idx[chromosomes[p1][idx]];
                }
                else // cycle finded 
                {
                    break;
                }
            }
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (m[i] == 0)
                {
                    chromosomes[c1][i] = chromosomes[p1][i];
                    chromosomes[c2][i] = chromosomes[p2][i];
                }
                else
                {
                    chromosomes[c1][i] = chromosomes[p2][i];
                    chromosomes[c2][i] = chromosomes[p1][i];
                }
            }
        }
        public void SX(int p1, int p2, int c1, int c2, int candidateLenOfSubtour = 4)
        {

            if (candidateLenOfSubtour > numberOfGenes) { 
                candidateLenOfSubtour = Math.Min(4, (int)(numberOfGenes / 2)); }

            for (int i = 0; i < numberOfGenes; i++)
            {
                P2Idx[chromosomes[p2][i]] = i;
                subtourIdx[i] = int.MaxValue;
            }
            v2 = 0;
            for (int i = 0; i < numberOfGenes - candidateLenOfSubtour; i++)
            {
                idx = 0;
                for(int j = i; j < i + candidateLenOfSubtour; j++)
                {
                    subtourIdx[idx] = P2Idx[chromosomes[p1][j]];
                    idx++;
                }
                Array.Sort(subtourIdx);
                v1 = 0;
                for (int j = 0; j < candidateLenOfSubtour-1; j++)
                {
                    if (subtourIdx[j] + 1 == subtourIdx[j+1])
                    {
                        v1 += 1;
                    }
                    else { break; }
                }
                if (v1 == candidateLenOfSubtour-1)
                {
                    DoExchange(p1,p2,c1,c2,i,candidateLenOfSubtour);
                    return;
                }
            }
            if (v2 == 0)
            {
                candidateLenOfSubtour -= 1;
                SX(p1, p2, c1, c2, candidateLenOfSubtour);
            }
        }
        public void DoExchange(int p1, int p2, int c1, int c2, int start, int lenOfSubtour)
        {
            int startOfP2 = subtourIdx.Min();
            // c1
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (i >= start && i < start + lenOfSubtour)
                {
                    chromosomes[c1][i] = chromosomes[p2][startOfP2 + i -start];
                }
                else{
                    chromosomes[c1][i] = chromosomes[p1][i];
                }
            }
            // c2
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (i >= startOfP2 && i < startOfP2 + lenOfSubtour)
                {
                    chromosomes[c2][i] = chromosomes[p1][start+i- startOfP2];
                }
                else
                {
                    chromosomes[c2][i] = chromosomes[p2][i];
                }
            }
        }
        public void PMX(int p1, int p2, int c1, int c2)
        {
            i1 = randomizer.Next(numberOfGenes);
            i2 = randomizer.Next(numberOfGenes);
            if (i1 > i2)
            {
                temp = i1;
                i1 = i2;
                i2 = temp;
            }
            for (int i = 0; i < numberOfGenes; i++)
            {
                m[i] = -1;
            }

            for (int i = i1; i < i2; i++)
            {
                v1 = chromosomes[p1][i];
                v2 = chromosomes[p2][i];
                if (v1 == v2) { continue; }
                if (m[v1] == -1 && m[v2] == -1)
                {
                    m[v1] = v2; m[v2] = v1;
                }
                else if (m[v1] == -1)
                {
                    m[v1] = m[v2];m[m[v2]] = v1; m[v2] = -2;
                }
                else if (m[v2] == -1)
                {
                    m[v2] = m[v1]; m[m[v1]] = v2; m[v1] = -2;
                }
                else
                {
                    m[m[v2]] = m[v1]; m[m[v1]] = m[v2];
                    m[v1] = -3; m[v2] = -3;
                }
            }
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (i1 <= i && i < i2)
                {
                    chromosomes[c1][i] = chromosomes[p2][i];
                    chromosomes[c2][i] = chromosomes[p1][i];
                }
                else
                {
                    if (m[chromosomes[p1][i]] < 0)
                    {
                        chromosomes[c1][i] = chromosomes[p1][i];
                    }
                    else
                    {
                        chromosomes[c1][i] = m[chromosomes[p1][i]];
                    }
                    if (m[chromosomes[p2][i]] < 0)
                    {
                        chromosomes[c2][i] = chromosomes[p2][i];
                    }
                    else
                    {
                        chromosomes[c2][i] = m[chromosomes[p2][i]];
                    }
                }
            }
        }
    }
}