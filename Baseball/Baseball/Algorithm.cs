using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baseball
{
    class Algorithm
    {
        private static double uniformRate = 0.5;
        private static double mutationRate = 0.015;
        private static int tournamentSize = 5;
        private static Boolean elitism = true;

        public static Population EvolvePopulation(Population pop)
        {
            Population newPopulation = new Population(pop.Size(), false);

            if (elitism)
                newPopulation.SaveIndividual(0, pop.GetFittest());

            Int32 elitismOffset;
            if (elitism)
                elitismOffset = 1;
            else
                elitismOffset = 0;

            for (var i = elitismOffset; i < newPopulation.Size(); i++)
                Mutate(newPopulation.GetIndividual(i));

            return newPopulation;
        }

        private static Individual crossover(Individual indiv1, Individual indiv2)
        {
            Individual newSol = new Individual();
            // Loop through genes
            for (int i = 0; i < indiv1.Size(); i++)
            {
                Random random = new Random();
                // Crossover
                if (random.NextDouble() <= uniformRate)
                {
                    newSol.SetGene(i, indiv1.GetGene(i));
                }
                else
                {
                    newSol.SetGene(i, indiv2.GetGene(i));
                }
            }
            return newSol;
        }

        private static void Mutate(Individual indiv)
        {
            Random random = new Random();

            for (int i = 0; i < indiv.Size(); i++)
            {
                if (random.NextDouble() <= mutationRate)
                {
                    // Create random gene
                    byte gene = (byte)Math.Round(random.NextDouble());
                    indiv.SetGene(i, gene);
                }
            }
        }

        private static Individual TournamentSelection(Population pop)
        {
            Random random = new Random();
            // Create a tournament population
            Population tournament = new Population(tournamentSize, false);
            // For each place in the tournament get a random individual
            for (int i = 0; i < tournamentSize; i++)
            {
                int randomId = (int)(random.NextDouble() * pop.Size());
                tournament.SaveIndividual(i, pop.GetIndividual(randomId));
            }
            // Get the fittest
            Individual fittest = tournament.GetFittest();
            return fittest;
        }
    }
}
