using System;

namespace DiceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare and instatiate needed variables
            int[] combinationsRolled = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}; // Array to track # of times combinations are rolled
            int rolls = 0; // The number of rolls that will be entered by user
            bool inputValid = false; // Bool to stay in loop till input is valid
            string histogram = ""; // Final histogram to print

            // Welcome message
            Console.WriteLine("Welcome to the dice rolling simulator!\n");

            // Prompt user and gather desired number of rolls
            Console.Write("You have two dice. How many times do you want to roll? (please enter a whole number): ");

            // Gather user input, loop until input is correct
            while (inputValid == false)
            {
                try
                {
                    // Grab input and convert to integer
                    rolls = Convert.ToInt32(Console.ReadLine());

                    // Update variable to exit loop
                    inputValid = true;
                }
                catch
                {
                    Console.Write("Error: invalid input. Please enter a valid number: ");
                }
            }

            // Notify user of simulation
            Console.WriteLine("");
            Console.WriteLine("Rolling...patience young padowan...");

            // Create two dice objects
            Dice dice1 = new Dice();
            Dice dice2 = new Dice();

            // For the amount of rolls input by user, roll
            for (int i = 0; i < rolls; i++)
            {
                // Roll both dice
                dice1.rollDice();
                dice2.rollDice();

                // Save combination
                int combination = dice1.rolledNum + dice2.rolledNum;

                // Calculate index for combination for array
                int index = combination - 2;

                // Add to count for current combination in array
                combinationsRolled[index]++;
            }

            // Create histogram with combination counts from array
            for (int i = 0; i < combinationsRolled.Length; i++)
            {
                histogram += $"{i + 2}: ";

                // Convert count to percentage of total rolls and round
                double percent = Math.Round(Convert.ToDouble((combinationsRolled[i] * 100.0 / rolls)), 0);

                // Add number of asteriks to rounded percent
                for (int i2 = 0; i2 < Convert.ToInt32(percent); i2++)
                {
                    histogram += $"*";
                }

                // Add new line
                histogram += "\n";
            }

            // Print final histogram
            Console.WriteLine($"\nDICE ROLLING RESULTS\nEach '*' represents 1% of the total number of rolls for that combination.\nTotal number of rolls = {rolls}.\n");
            Console.WriteLine(histogram);
            Console.Write("Thank you for playing...goodbye and roll on!\n");
        }
    }
}