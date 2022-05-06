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

        private Dice dice = new(1,1);
        private List<Player> players = new List<Player>();
        
        // runs the game
        public void play()
        {
            // set the settings of the game
            settings();
            foreach(Player player in players)
            {
                Output.printName(player);
                player.turn();
            }
            Output.roundScores(players);
        }

        // sets the settings of the game
        // ensuring the settings are valid options
        private void settings()
        {
            while (true)
            {
                try
                {
                    // set the number of dice and the number of sides
                    int numberOfDice = 5;
                    //int numberOfDice = Input.getNumber("Enter number of Dice:"); // change how score works to increase based on matches i.e 6 of a kind
                    int numberOfSides = 6;
                    //int numberOfSides = Input.getNumber("Enter the number of sides on each dice:");

                    dice = new Dice(numberOfDice, numberOfSides);    
                    
                    // create players
                    // human players
                    players.Add(new Human("Zak", dice));
                    // computer players


                    break;
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
            
        }
    }
}
