using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baseball
{
    public class Population
    {
        Individual[] population;

        public Population(Int32 populationSize, Boolean initialize)
        {
            population = new Individual[populationSize];

            if (initialize)
            {
                for (var i = 0; i < Size(); i++)
                {
                    Individual newIndividual = new Individual();
                    newIndividual.GenerateIndividual();
                    SaveIndividual(i, newIndividual);
                }                
            }
        }

        public Int32 Size()
        {
            return population.Length;
        }

        public Individual GetIndividual(int index)
        {
            return population[index];
        }

        public void SaveIndividual(int index, Individual indiv)
        {
            population[index] = indiv;
        }

        public Individual GetFittest()
        {
            Individual fittest = population[0];
            for (int i = 0; i < Size(); i++)
            {
                if (fittest.GetFitness() <= population[i].GetFitness())
                {
                    fittest = population[i];
                }
            }
            return fittest;
        }
    }
}
