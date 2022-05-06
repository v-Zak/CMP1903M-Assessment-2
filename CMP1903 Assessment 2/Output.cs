using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_Assessment_2
{
    public static class Output
    {
        // handles the programs output
        public static void printDiceValues(Dice dice)
        {
            Console.WriteLine("Dice Values:");
            foreach(Die die in dice)
            {
                Console.Write(die.number + " ");
            }
            Console.WriteLine();
        }

        public static void printName(Player player)
        {
            Console.WriteLine($"{player}'s turn:");
        }

        // tells them the points they scored in the round due to how many were matching
        public static void turnScore(int score)
        {
            if (score == 0)
            {
                Console.WriteLine("Unlucky. 0 points scored.");
            }
            else
            {
                Console.WriteLine($"Great! {score} points scored!");
            }
            

        }

        // dispays a players name and their score
        public static void playerScore(Player player)
        {
            Console.WriteLine($"{player.name}'s score: {player.score}");
        }

        // displays all the players score and their names
        public static void roundScores(List<Player> players)
        {
            Console.WriteLine("The total scores for this round are:");
            foreach (Player player in players)
            {
                playerScore(player);
            }
        }
    }
}
