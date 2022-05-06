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
        // a calls containing a collection of die


        public int numberOfDice { get; private set; }
        public List<Die> diceList { get; private set; }
        public List<int> numbersRolled { get; private set; }

        // instatiates the collection nesuring it is a valid set of dice
        public Dice(int numberOfDice, int numberOfSides)
        {
            diceList = new List<Die>();
            numbersRolled = new List<int>();

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
