using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace CMP1903_Assessment_2_Tests
{
    [TestClass]
    public class Tests
    {
        // compares the results form the programs functions with expected values
        // test will pass if they match

        // for user inout testing refer to the submitted report

        // tests the Analyse.score method
        [TestMethod]
        public void testScore()
        {
            int[] expectedScores = { 0, -1, 3, 6, 12};
            int[][] startingNumbers = new int [5][];
            startingNumbers [0] = new int[] { 1, 2, 3, 4, 5};
            startingNumbers [1] = new int[] { 1, 1, 3, 4, 5 };
            startingNumbers [2] = new int[] { 1, 1, 1, 4, 5 };
            startingNumbers [3] = new int[] { 1, 1, 1, 1, 5 };
            startingNumbers [4] = new int[] { 1, 1, 1, 1, 1 };

            // run the starting numbers through the function and check if they are as expected
            for (int i = 0; i < expectedScores.Length; i++)
            {
                CMP1903_Assessment_2.Dice dice = new(5, 6, startingNumbers[i]);

                int resultScore = CMP1903_Assessment_2.Analyse.score(dice);

                Assert.AreEqual(resultScore, expectedScores[i]);
            }    
        }

        // prints to the standard console the frequnecy of each letter
        // this test will always pass
        // needs to be checked manually to see if frequencies seem random
        [TestMethod]
        public void testDiceFrequency()
        {
            CMP1903_Assessment_2.Output.printHighlight("Testing Dice:");

            CMP1903_Assessment_2.Dice dice = new(5, 6);
            List<int> totalNumbersRolled = new List<int>();

            int iterations = 100;
            for(int i = 0; i< iterations; i++)
            {
                dice.roll();
                List<int> rollNumbers = dice.numbersRolled;

                foreach (int number in rollNumbers)
                {
                    totalNumbersRolled.Add(number);
                }
            }

            Console.WriteLine($"Frequency of each side over {iterations * dice.numberOfDice} rolls");
            var frequency = CMP1903_Assessment_2.Analyse.frequency(totalNumbersRolled);
            CMP1903_Assessment_2.Output.printFrequency(frequency);
        }

        // tests the win condition
        [TestMethod]
        public void testWinCondition()
        {
            bool[] expectedResult = {true, false};

            List<CMP1903_Assessment_2.Player> players = new List<CMP1903_Assessment_2.Player>();
            CMP1903_Assessment_2.Dice dice = new(5, 6);

            // add players with preset scores
            players.Add(new CMP1903_Assessment_2.Human("Test Human", dice, 10));
            players.Add(new CMP1903_Assessment_2.Human("Test Human", dice, 5));
            players.Add(new CMP1903_Assessment_2.Human("Test Human", dice, 7));

            CMP1903_Assessment_2.Game target = new CMP1903_Assessment_2.Game();
            CMP1903_Assessment_2.Game gameManager = new();
            bool returnValue = gameManager.checkWon(10, players);

            Assert.AreEqual(expectedResult[0], returnValue);

            // test for a return of false

            players = new List<CMP1903_Assessment_2.Player>();
            players.Add(new CMP1903_Assessment_2.Human("Test Human", dice, 9));
            players.Add(new CMP1903_Assessment_2.Human("Test Human", dice, 5));
            players.Add(new CMP1903_Assessment_2.Human("Test Human", dice, 7));

            returnValue = gameManager.checkWon(10, players);

            Assert.AreEqual(expectedResult[1], returnValue);                       
        }
    }
}