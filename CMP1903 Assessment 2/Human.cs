﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_Assessment_2
{
    public class Human : Player
    {
        public override string name { get; init; }
        public override int score { get; protected set; }
        public override Dice dice { get; init; }

        public Human(string name, Dice dice)
        {
            this.name = name;
            this.dice = dice;
        }

        // completes the players turn, updating their score
        public override void turn()
        {
            if (Input.askBool("Would you like to roll?"))
            {
                // roll the dice and output to screen
                dice.roll();
                Output.printDiceValues(dice);
                System.Threading.Thread.Sleep(1000);

                // get the score of the dice. if the score is -1 a reroll is allowed
                int turnScore = Analyse.score(dice);
                if (turnScore < 0)
                {
                    
                    if (Input.askBool("Would you like to re-roll?"))
                    {
                        List<int> reRollIndexs = Analyse.getReRollIndexs(dice);
                        dice.roll(reRollIndexs);
                        Output.printDiceValues(dice);
                        turnScore = Analyse.score(dice);
                    }
                    // ensure turn score can't be less than 0
                    turnScore = Math.Max(turnScore, 0);
                }

                // print the sscore for the turn and add the score to the players total score
                Output.turnScore(turnScore);
                score += turnScore;
            }
            else
            {
                Console.WriteLine("Turn skipped!");
            }
        }
    }
}
