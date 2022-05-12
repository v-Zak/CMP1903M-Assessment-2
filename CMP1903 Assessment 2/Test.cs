using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_Assessment_2
{
    public class Test
    {
        // runs basic tests on the program
        private Dice dice = new(5, 6);
        private List<int> totalNumbersRolled = new List<int>();
        public void runTests()
        {
            testDice();
            testScore();
        }

        // tests the frequncy of the dice
        public void testDice(int iterations = 100)
        {
            Output.printHighlight("Testing Dice:");

            for(int i = 0; i < iterations; i++)
            {
                dice.roll();
                List<int> rollNumbers = dice.numbersRolled;

                foreach (int number in rollNumbers)
                {
                    totalNumbersRolled.Add(number);
                }
            }

            Console.WriteLine($"Frequency of each side over {iterations * dice.numberOfDice} rolls");
            var frequency = Analyse.frequency(totalNumbersRolled);
            Output.printFrequency(frequency);
        }

        public void testScore()
        {
            // need to implement
        }
    }   
}
