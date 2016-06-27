using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baseball
{
    public class Individual
    {
        static Int32 defaultGeneLength = 64;
        private Byte[] genes { get; set; } = new Byte[defaultGeneLength];

        private Int32 fitness = 0;

        public void GenerateIndividual()
        {
            Random random = new Random();
            random.NextBytes(genes);
        }

        public Int32 GetFitness()
        {
            if (fitness == 0)
                fitness = FitnessCalc.getFitness(this);
            return fitness;
        }

        public int Size()
        {
            return genes.Length;
        }

        public void SetGene(int index, byte value)
        {
            genes[index] = value;
            fitness = 0;
        }

        public byte GetGene(int index)
        {
            return genes[index];
        }
    }
}
