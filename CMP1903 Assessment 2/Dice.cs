using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;

namespace CMP1903_Assessment_2
{
   public class Dice : IEnumerable
    {
        // a class containing a collection of die

        public int numberOfDice { get; private set; }
        public List<Die> diceList { get; private set; }
        public List<int> numbersRolled { get; private set; }


        // basic constructor
        public Dice(int numberOfDice, int numberOfSides)
        {
            diceList = new List<Die>();
            numbersRolled = new List<int>();

            // check the function inputs are valid
            if (numberOfDice == 0)
            {
                throw new ZeroDiceException();
            }
            if (numberOfSides == 0)
            {
                throw new ZeroSideException();
            }
            this.numberOfDice = numberOfDice;

            for (int i = 0; i < numberOfDice; i++)
            {
                diceList.Add(new Die(numberOfSides));
                numbersRolled.Add(1);
            }
        }

        // constructor which also allows setting the dice starting numbers
        public Dice(int numberOfDice, int numberOfSides, int[] startingNumbers) : this(numberOfDice, numberOfSides)
        {

            // set starting numbers of dice, useful for testing
            if (startingNumbers.Length == numberOfDice)
            {
                diceList = new List<Die>();
                for (int i = 0; i < numberOfDice; i++)
                {
                    diceList.Add(new Die(numberOfSides, startingNumbers[i]));
                    
                }
                numbersRolled = startingNumbers.ToList();
            }       

        }

        // rolls all the dice returning their values
        public List<int> roll()
        {
            numbersRolled = new List<int>();

            foreach (Die die in diceList)
            {
                int number = die.roll();
                numbersRolled.Add(number);
            }
            return numbersRolled;
        }

        // rolls only the specified dice returning all dice values
        public List<int> roll(List<int> indexsToRoll)
        {
            foreach (int index in indexsToRoll)
            {
                int number = diceList[index].roll();
                numbersRolled[index] = number;
            }
            return numbersRolled;
        }

        // allow use of ForEach on Dice class by looping through diceList
        IEnumerator IEnumerable.GetEnumerator()
        {
            return diceList.GetEnumerator();
        }

    }
}
