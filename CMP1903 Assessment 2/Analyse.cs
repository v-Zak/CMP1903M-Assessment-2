using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_Assessment_2
{
    public static class Analyse
    {
        public static int score(Dice dice)
        {
            // get the highest number of repeats
            int occurences = highestRepeat(dice).Count();

            // return score based on the number of occurences
            // if 2 repeats then return -1 to signify a reroll is allowed
            switch (occurences)
            {
                case < 2:
                    return 0;
                case 2:
                    return -1;
                case 3:
                    return 3;
                case 4:
                    return 6;
                case 5:
                    return 12;
            }

            return 0;



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


            var orderedNumbers = from n in dice.numbersRolled
                    group n by n into numberFrequencies
                    orderby numberFrequencies.Count() descending
                    select numberFrequencies;

            return orderedNumbers.First();
     

        }


    }
}
