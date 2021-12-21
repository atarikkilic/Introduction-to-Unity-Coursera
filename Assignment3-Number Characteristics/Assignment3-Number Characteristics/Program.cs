using System;

namespace Assignment3_Number_Characteristics
{
    class Program
    {
        // number to classify
        static int number;

        /// <summary>
        /// Classifies numbers as even or odd and negative, 0, or positive
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            // loop while there's more input
            string input = Console.ReadLine();
            while (input[0] != 'q')
            {
                // extract number from string
                GetInputValueFromString(input);

                // Add your code between this comment
                // and the comment below. You can of
                // course add more space between the
                // comments as needed
                if (number > 0)
                {
                    if (number % 2 == 0)
                    {
                        Console.WriteLine("e " + number);
                    }
                    else
                    {
                        Console.WriteLine("o " + number);
                    }
                }
                else
                {
                    if (number % 2 == 0)
                    {
                        Console.WriteLine("e " + number);
                    }
                    else
                    {
                        Console.WriteLine("o " + number);
                    }
                }

                // Don't add or modify any code below
                // this comment
                input = Console.ReadLine();
            }


            /// <summary>
            /// Extracts the number from the given input string
            /// </summary>
            /// <param name="input">input string</param>
            static void GetInputValueFromString(string input)
            {
                number = int.Parse(input);
            }
        }
    }
}
