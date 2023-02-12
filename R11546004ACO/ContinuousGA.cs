using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GALibrary
{
    public class ContinuousGA : GeneticGASolver<double>
    {
        public ContinuousGA(int numberOfVariables, OptimizationType optimizationType, ObjectiveFunction<double> encodingFunction) : base(numberOfVariables, optimizationType, encodingFunction)
        {
        }
    }
}