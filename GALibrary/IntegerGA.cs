using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GALibrary
{
    public class IntegerGA : GeneticGASolver<int>
    {
        public IntegerGA(int numberOfVariables, OptimizationType optimizationType, ObjectiveFunction<int> encodingFunction) : base(numberOfVariables, optimizationType, encodingFunction)
        {
        }
    }
}