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
        private static double mutationRate = 0.4;
        private static int tournamentSize = 5;
        private static Boolean elitism = true;
        private FitnessCalc fitnessCalc;

        public Algorithm(FitnessCalc fitnessCalc)
        {
            this.fitnessCalc = fitnessCalc;
        }
        public Population EvolvePopulation(Population pop)
        {
            Population newPopulation = new Population(pop.Size(), false, fitnessCalc);

            if (elitism)
                newPopulation.SaveIndividual(0, pop.GetFittest());

            Int32 elitismOffset;
            if (elitism)
                elitismOffset = 1;
            else
                elitismOffset = 0;

            for (var i = elitismOffset; i < pop.Size(); i++)
            {
                Individual indiv1 = this.TournamentSelection(pop);
                Individual indiv2 = this.TournamentSelection(pop);
                Individual newIndiv = crossover(indiv1, indiv2);
                newPopulation.SaveIndividual(i, newIndiv);
            }

            for (var i = elitismOffset; i < newPopulation.Size(); i++)
                Mutate(newPopulation.GetIndividual(i));

            return newPopulation;
        }

        private Individual crossover(Individual indiv1, Individual indiv2)
        {
            Individual newSol = new Individual(fitnessCalc);
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

        private void Mutate(Individual indiv)
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

        private Individual TournamentSelection(Population pop)
        {
            Random random = new Random();
            // Create a tournament population
            Population tournament = new Population(tournamentSize, false, fitnessCalc);
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
