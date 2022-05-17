using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_Assessment_2
{
    public static class Input
    {       
        // Handles all user input

        // ask the user a yes or no question, returning the answer
        public static bool getBool(string question)
        {
            // asks the user the question and get their response
            Console.WriteLine($"{question} y/n");
            string? input = Console.ReadLine();
            Console.WriteLine();

            // check if the response is valid
            if (String.IsNullOrEmpty(input))
            {
                Console.WriteLine("Nothing entered. Try again.");
                return getBool(question);
            }
            input = input.ToLower();
            if (input == "y")
            {
                return true;
            }
            else if (input == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again.");
                return getBool(question);
            }

        }

        // ask the user to enter a number, returning the number
        public static int getNumber(string question)
        {
            // asks the user the question and get their response
            Console.WriteLine(question);
            string? input = Console.ReadLine();
            // try turn the response into a number
            try
            {
                int number = Convert.ToInt32(input);

                return number;
            }
            catch (FormatException)
            {
                Console.WriteLine($"Choice must be an integer.");
                return getNumber(question);
            }
        }

        // ask the user to enter a string and return it
        public static string getString(string question)
        {
            // asks the user the question and gets their response
            Console.WriteLine(question);
            string? input = Console.ReadLine();
            // ensure the string isn't empty then return
            if (String.IsNullOrEmpty(input))
            {
                Console.WriteLine("Answer can't be nothing.");
                return getString(question);
            }
            return input;
        }

        // waits for the user to enter something before continuing
        public static void getContinue()
        {
            Console.WriteLine("Press enter to continue:");
            Console.ReadLine();
        }

    }

}
