using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R11546004ACO
{
    public class TSPProblem
    {
        public string title;
        public int numberOfCities;
        public string shortestLength;
        public int[] optimalSolution;
        public string comment;
        public double[,] heurMat;

        [Browsable(false)]
        public double PointXY { get; set; }

        [Category("Problem")]
        [Description("Name of Benchmark Problem")]
        public string Title { get { return title; } }
        [Category("Problem")]
        [Description("Numbers of Cities to travel")]
        public int NumberOfCities { get { return numberOfCities; }}
        [Category("Solution")]
        [Description("Shortest Length traveling through all cities")]
        public string ShortestLength
        {
            get { return shortestLength; }
        }
        [Category("Solution")]
        [Description("Greedy Solution Length")]
        public string GreedySolutionLength
        { get; set; }


        public TSPProblem(string title, int numberOfCities, double[,] distanceMat)
        {
            this.title = title;
            this.numberOfCities = numberOfCities;
            heurMat = new double[numberOfCities, numberOfCities];
            for (int i = 0; i < numberOfCities; i++)
            {
                for(int j = 0; j< numberOfCities; j++)
                {
                    heurMat[i,j] = 1.0 / distanceMat[i,j];
                }
            }
        }

    }
}
