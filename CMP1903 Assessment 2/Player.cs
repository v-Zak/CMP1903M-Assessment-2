using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_Assessment_2
{
    public abstract class Player
    {
        // abstract class that represents a generic player
        public abstract string name { get; init; }
        public abstract int score { get; protected set; }
        public abstract Dice dice { get; init; }
        public abstract void turn();
    }
}
