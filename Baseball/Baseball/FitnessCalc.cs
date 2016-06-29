using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baseball
{
    public class FitnessCalc
    {
        private Statistics statistics;
        public FitnessCalc(Statistics statistics)
        {
            this.statistics = statistics;
        }

        public Int32 getFitness(Individual individual)
        {
            var fitness = 0;
            for (var team = 0; team < statistics.TeamNames.Length; team++)
            {
                for (var game = 0; game < statistics.TeamOpponents.GetLength(1); game++)
                {
                    if (game < 78)
                    {
                        var dateIndex = 0;
                        fitness = CalculateWin(individual, fitness, team, game, dateIndex);
                    }
                    else if (game < 112)
                    {
                        var dateIndex = 1;
                        fitness = CalculateWin(individual, fitness, team, game, dateIndex);
                    }
                    else if (game < 122)
                    {
                        var dateIndex = 2;
                        fitness = CalculateWin(individual, fitness, team, game, dateIndex);
                    }
                    else if (game < 129)
                    {
                        var dateIndex = 3;
                        fitness = CalculateWin(individual, fitness, team, game, dateIndex);
                    }
                    else if (game < 135)
                    {
                        var dateIndex = 4;
                        fitness = CalculateWin(individual, fitness, team, game, dateIndex);
                    }
                    else if (game < 137)
                    {
                        var dateIndex = 5;
                        fitness = CalculateWin(individual, fitness, team, game, dateIndex);
                    }
                    else if (game < 143)
                    {
                        var dateIndex = 6;
                        fitness = CalculateWin(individual, fitness, team, game, dateIndex);
                    }
                    else if (game < 151)
                    {
                        var dateIndex = 7;
                        fitness = CalculateWin(individual, fitness, team, game, dateIndex);
                    }
                    else if (game < 157)
                    {
                        var dateIndex = 8;
                        fitness = CalculateWin(individual, fitness, team, game, dateIndex);
                    }
                    else if (game < 160)
                    {
                        var dateIndex = 9;
                        fitness = CalculateWin(individual, fitness, team, game, dateIndex);
                    }


                }
            }




            return fitness;
        }

        private Int32 CalculateWin(Individual individual, int fitness, int team, int game, int dateIndex)
        {
            var teamScore = CalculateTeamScore(statistics.TeamStats[dateIndex][team], individual);

            var oppNumber = statistics.TeamNumbers[statistics.TeamOpponents[team, game]];
            var oppScore = CalculateTeamScore(statistics.TeamStats[dateIndex][oppNumber], individual);
            var diff = teamScore - oppScore;
            var win = statistics.TeamRecord[team, game];
            if ((win && diff > 0) || (!win && diff <= 0))
               fitness++;
            return fitness;
        }

        public static int GetMaxFitness()
        {
            return 4800;
        }

        private Double CalculateTeamScore(Double[] stats, Individual calc)
        {
            var score = 0.0;

            for (var i = 0; i < stats.Length; i++)
                score += stats[i] * (Int32)calc.GetGenes()[i];

            return score;
        }




    }
}
