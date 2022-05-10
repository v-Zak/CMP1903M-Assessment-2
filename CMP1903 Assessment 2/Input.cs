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
        public static bool askBool(string question)
        {
            Console.WriteLine($"{question} y/n");
            string? input = Console.ReadLine();
            Console.WriteLine();
            if (String.IsNullOrEmpty(input))
            {
                Console.WriteLine("Nothing entered. Try again.");
                return askBool(question);
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
                return askBool(question);
            }

        }

        // ask the user to enter a number, returning the number
        public static int getNumber(string question)
        {
            Console.WriteLine(question);
            string? input = Console.ReadLine();
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
            Console.WriteLine(question);
            string? input = Console.ReadLine();
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

        // returns the index of the choice chosen by the user
        public static int getChoice(string[] choices)
        {
            Console.WriteLine("Choices available:");
            for (int i = 0; i < choices.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {choices[i]}");
            }
            Console.WriteLine($"Enter the corresponding number to the choice wanted i.e 1 = {choices[0]}:");
            string? input = Console.ReadLine();
            try
            {
                int index = Convert.ToInt32(input) - 1;
                if (index >= 0 && index < choices.Length)
                {
                    Console.WriteLine();
                    return index;
                }
                else
                {
                    Console.WriteLine($"Choice must be between 1 and {choices.Length}.");
                    return getChoice(choices);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine($"Choice must be an integer.");
                return getChoice(choices);
            }
        }

    }

}
