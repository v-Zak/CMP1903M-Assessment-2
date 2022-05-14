using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_Assessment_2
{
    public class Game
    {
        // Runs and manages the game

        private Dice dice = new (1,1);
        private List<Player> players = new List<Player>();
        private int winScore;
        private Player? highestPlayer;

        // runs the game
        public void play()
        {
            

            // print title
            Output.printHighlight("Dice Game\n");

            // set the settings of the game
            settings();            

            // loop each round until win condition met
            while (true)
            {              
                // loop through each player and play their turn
                foreach (Player player in players)
                {
                    // clear the terminal
                    Output.clearScreen();
                    // print the players name
                    Output.printName(player);
                    System.Threading.Thread.Sleep(1000);
                    // excecute the players turn
                    player.turn();
                    System.Threading.Thread.Sleep(2000);
                }

                // clear the terminal
                Output.clearScreen();
                // output the scores of every player at the end of the round
                Output.roundScores(players);
                // let the user read the scores before continuing
                Input.getContinue();

                // check if a player is above the win score if so break
                if (checkWon(winScore, players))
                {
                    break;
                }

            }
            Console.WriteLine(highestPlayer.name + " wins!");
            Console.WriteLine($"with a score of {highestPlayer.score}.");


        }

        // sets the settings of the game
        // ensuring the settings are valid options
        private void settings()
        {
            Output.printHighlight("Game Settings:");
            try
            {
                // set the number of dice and the number of sides
                int numberOfDice = 5;
                int numberOfSides = 6;

                dice = new Dice(numberOfDice, numberOfSides);

                // ask the score to play till
                winScore = Input.getNumber("What score would you like to play until?");

                // create players
                addPLayers();
            }
            catch (ZeroDiceException)
            {
                Console.WriteLine("The number of dice must not be 0.");
            }
            catch (ZeroSideException)
            {
                Console.WriteLine("The number of sides must not be 0.");
            }      
        }

        // adds players to a list of players
        // each player can either be a human or a computer as per the users input
        private void addPLayers()
        {
            do
            {
                string playerName = Input.getString("Enter the name of the player:");
                if(Input.askBool($"is {playerName} a human?"))
                {
                    addPLayer(playerName, true);
                }
                else
                {
                    addPLayer(playerName + " (computer)", false);
                }

                Output.printPlayers(players);

            } while (Input.askBool("Would you like to add another player?"));

            if (players.Count == 0)
            {
                Console.WriteLine("Must have at least one player.");
                addPLayers();
            }
        }

        // adds player to a list of players
        // player can be a human or a computer
        private void addPLayer(string name, bool human = true)
        {
            if (human)
            {
                players.Add(new Human(name, dice));
            }
            else
            {
                players.Add(new Computer(name, dice));
            }
            
        }
        

        // finds the highest scorer and checks if they have a score above the win condition
        private bool checkWon(int winScore, List<Player> players)
        {
            highestPlayer = Analyse.highestScore(players);
            if (highestPlayer.score >= winScore)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
