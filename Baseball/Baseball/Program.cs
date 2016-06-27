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
            Population myPop = new Population(50, true);

            var  generationCount = 0;
            while (myPop.GetFittest().GetFitness() < FitnessCalc.GetMaxFitness())
            {
                generationCount++;
                Console.WriteLine("Generation: " + generationCount + " Fittest: " + myPop.GetFittest().GetFitness());
                myPop = Algorithm.EvolvePopulation(myPop);
            }

            Console.WriteLine("Solution found!");
            Console.WriteLine("Generation: " + generationCount);
            Console.WriteLine("Genes:");
            Console.WriteLine(myPop.GetFittest());
        }
    }
}
