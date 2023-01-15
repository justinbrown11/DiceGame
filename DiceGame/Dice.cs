using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    public class Dice
    {
        // Instatiate roll to 0
        public int rolledNum = 0;

        // Method that rolls (grabs random number between 1 and 6)
        public void rollDice()
        {
            // Generate random number and save to roll
            Random random = new Random();
            rolledNum = random.Next(1, 7);
        }
    }
}
