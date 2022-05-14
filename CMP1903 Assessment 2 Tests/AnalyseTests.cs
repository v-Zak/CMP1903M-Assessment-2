using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CMP1903_Assessment_2_Tests
{
    [TestClass]
    public class AnalyseTests
    {
        // compares the results of Analyse.Score with expected values
        // test will pass if they match
        [TestMethod]
        public void TestScore()
        {
            int[] expectedScores = { 0, -1, 3, 6, 12};
            int[][] startingNumbers = new int [5][];
            startingNumbers [0] = new int[] { 1, 2, 3, 4, 5};
            startingNumbers [1] = new int[] { 1, 1, 3, 4, 5 };
            startingNumbers [2] = new int[] { 1, 1, 1, 4, 5 };
            startingNumbers [3] = new int[] { 1, 1, 1, 1, 5 };
            startingNumbers [4] = new int[] { 1, 1, 1, 1, 1 };

            for (int i = 0; i < expectedScores.Length; i++)
            {
                CMP1903_Assessment_2.Dice dice = new(5, 6, startingNumbers[i]);

                int resultScore = CMP1903_Assessment_2.Analyse.score(dice);

                Assert.AreEqual(resultScore, expectedScores[i]);
            }    
        }

        // prints to the standard console the frequnecy of each letter
        // this test will always pasd
        // needs to be checked manually to see if frequencies seem random
        [TestMethod]
        public void TestDiceFrequency()
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

        // not done finsh testing///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // and comment ////////////////////////////////////
        // add for loop /////////////////////////////////

        [TestMethod]
        public void TestWinCondition()
        {
            bool[] expectedResult = {true, false};

            List<CMP1903_Assessment_2.Player> players = new List<CMP1903_Assessment_2.Player>();
            CMP1903_Assessment_2.Dice dice = new(5, 6);
            players.Add(new CMP1903_Assessment_2.Human("Test Human", dice, 10));

            CMP1903_Assessment_2.Game target = new CMP1903_Assessment_2.Game();
            PrivateObject gameManager = new PrivateObject(target);
            var checkWon = gameManager.Invoke("checkWon");
            checkWon(10, 10);

            Assert.AreEqual(expectedResult[0], returnVlaue);
        }
    }
}