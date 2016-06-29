using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baseball
{
    class Program
    {
        static void Main(string[] args)
        {
            Statistics stats = new Statistics();
            FitnessCalc fitnesscalc = new FitnessCalc(stats);
            Population myPop = new Population(50, true, fitnesscalc);
            Algorithm algorithm = new Algorithm(fitnesscalc);

            var  generationCount = 0;
            while (myPop.GetFittest().GetFitness() < FitnessCalc.GetMaxFitness())
            {
                generationCount++;
                System.Diagnostics.Debug.WriteLine("Generation: " + generationCount + " Fittest: " + myPop.GetFittest().GetFitness());  
                myPop = algorithm.EvolvePopulation(myPop);
            }

            System.Diagnostics.Debug.WriteLine("Solution found!");
            System.Diagnostics.Debug.WriteLine("Generation: " + generationCount);
            System.Diagnostics.Debug.WriteLine("Genes:");
            System.Diagnostics.Debug.WriteLine(myPop.GetFittest());
        }
    }
}
