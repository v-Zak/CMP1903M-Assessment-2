﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_Assessment_2
{
    public class Die : IRoll
    {
        // a class that imitates a real life die by using a psuedo random number generator


        private Random random = new Random();
        public int numberOfSides { get; private set; }
        public int number { get; private set; }


        // instantiates the die ensuring it has at least 1 side
        public Die(int numberOfSides, int startingNumber = 1)
        {
            if (numberOfSides == 0)
            {
                throw new ZeroSideException();
            }
            this.numberOfSides = numberOfSides;
            this.number = startingNumber;
        }

        // returns a new random value between 1 and the number of sides
        public int roll()
        {
            number = random.Next(1, numberOfSides + 1);
            return number;
        }
    }
}
