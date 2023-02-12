using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GALibrary
{
    public enum OptimizationType
    {
        Maximization,
        Minimization
    }
    public enum SelectionMode
    {
        Stochastic,
        Deterministic
    }
    public enum MutationMode
    {
        GeneNumberBased,
        PopulationSizeBased
    }
    public enum CutMode
    {
        OnePointCut,
        TwoPointCut,
        NPointCut
    }
    public enum PermutationCrossoverOperators
    {
        PartialMappedCrossover,
        OrderCrossover,
        PositionBasedCrossover,
        OrderBasedCrossover,
        CycleCrossover,
        SubtourExchangeCrossover
    }
    public enum PermutationMutationOperators
    {
        Inversion,
        Swapped,
        Insertion,
        Displacement,
        ReciprocalExchange
    }
}