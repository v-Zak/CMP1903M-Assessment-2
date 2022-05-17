using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_Assessment_2
{
    public static class Analyse
    {
        // performs analysis on any inputs


        // gets the score of the dice based on number matching
        public static int score(Dice dice)
        {
            // get the highest number of repeats
            int occurences = highestRepeat(dice).Count();

            // return score based on the number of occurences
            // if 2 repeats then return -1 to signify a reroll is allowed
            switch (occurences)
            {
                case < 2:
                    Console.WriteLine("0 matching.");
                    return 0;
                case 2:
                    Console.WriteLine("2 matching.");
                    return -1;
                case 3:
                    Console.WriteLine("3 matching.");
                    return 3;
                case 4:
                    Console.WriteLine("4 matching.");
                    return 6;
                case 5:
                    Console.WriteLine("5 matching.");
                    return 12;
                case > 5:
                    throw new Exception("Error: Scoring not implemented for above 5 matches.");
            }
        }

        // return indexs to be rerolled
        public static List<int> getReRollIndexs(Dice dice)
        {
            List<int> repeatIndexs = new List<int>();
            // get the number with the highest amount of occurences
            int number = highestRepeat(dice).Key;
            // get a list of indexs for the number
            for(int i = 0; i < dice.numbersRolled.Count(); i++)
            {
                if(dice.numbersRolled[i] != number)
                {
                    repeatIndexs.Add(i);
                } 
            }
            return repeatIndexs;
        }

        // sort dice values by highest number of repeats
        private static IGrouping<int,int> highestRepeat(Dice dice) {
            
            var orderedNumbers = frequency(dice.numbersRolled);

            // return the highest element
            return orderedNumbers.First();
     

        }

        // return the player with the highest score
        public static Player highestScore(List<Player> players)
        {
            Player highestPlayer = players[0];
            int highestScore = players[0].score;

            for(int playerIndex = 1; playerIndex < players.Count; playerIndex++)
            {
                Player player = players[playerIndex];
                if(player.score > highestScore)
                {
                    highestPlayer = player;
                    highestScore = player.score;
                }
            }

            return highestPlayer;
        }

        // return ordered enumerable using frequency from highest to lowest
        public static IOrderedEnumerable<IGrouping<int, int>> frequency(List<int> numbersRolled)
        {
            // sort by frequency highest to lowest
            var frequency = from n in numbersRolled
                    group n by n into numberFrequencies
                    orderby numberFrequencies.Count() descending
                    select numberFrequencies;

            return frequency;
        }
    }
}
