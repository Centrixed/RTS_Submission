/**
 * Matt Underation
 * RTS Labs Submission
 * 11-6-2020
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS_Labs {
    class Program {
        static void Main(string[] args) {
            Program p = new Program();

            // Begin Example One
            p.ExampleOne();

            // Begin Example Two
            p.ExampleTwo();

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        /// Handles the console i/o and calculations for the first example:
        ///  Print the number of integers in the array that are above/below a given integer value
        /// </summary>
        private void ExampleOne() {
            int[] arrayInput = { 1, 5, 2, 1, 10, 4, 16, 9, 7 };
            int above, below, equal, numInput;
            above = below = equal = 0;

            // Try to receive and convert a integer input. If it is not an integer, alert the user and try again.
            try {
                Console.WriteLine("Example 1:\nEnter an integer value to compare to the array");
                numInput = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e) {
                Console.WriteLine("Error: the value you entered was not an integer. Please try again.\n\n");
                this.ExampleOne();
                return;
            }

            // Loop through the array, counting the numbers above, below, and equal to the inputted integer.
            foreach (int val in arrayInput) {
                if (numInput > val)
                    below++;
                else if (numInput < val)
                    above++;
                else
                    equal++;
            }

            // Output the results to the console
            Console.WriteLine("Results: above = " + above + ", below = " + below + ", equal = " + equal);
        }

        /// <summary>
        /// Handles the console i/o for the second example:
        ///  Rotate a given string based on an integer input
        /// </summary>
        private void ExampleTwo() {
            int num;

            // Prompt the user for a string value
            Console.WriteLine("\n\nExample 2:\nPlease enter any string value");
            string str = Console.ReadLine();

            // Try to receive and convert a integer input. If it is not an integer, alert the user and try again.
            try {
                Console.WriteLine("Enter a positive integer amount of chars to rotate");
                num = Convert.ToInt32(Console.ReadLine());

                // If a negative value, use the absolute value of it instead
                if (num < 0)
                    num = Math.Abs(num);
            }
            catch (Exception e) {
                Console.WriteLine("Error: the value you entered was not an integer. Please try again.\n\n");
                this.ExampleTwo();
                return;
            }

            // Call the rotate string method, sending it the user inputs
            this.RotateString(str, num);
        }

        /// <summary>
        /// Takes in a string value and an overflow count, and prints the rotated string.
        ///  Rotates the end of the string by x amount of overflow characters, and adds them to the beginning of the string.
        /// </summary>
        /// <param name="stringInput"> The inputted string that gets rotated </param>
        /// <param name="overFlow"> The number of characters to rotate the input by </param>
        private void RotateString(string stringInput, int overFlow) {
            // If the overflow is greater than the string's length, use the modulus of overflow/string length to get a new overflow value
            if (overFlow > stringInput.Length) {
                int tmp = overFlow % stringInput.Length;
                overFlow = tmp;
            }

            // Grab the part (substring) of the string that gets rotated
            string rotateStr = stringInput.Substring(stringInput.Length - overFlow);

            // Create a StringBuilder (.NET) object to modify the original string
            var sb = new StringBuilder(stringInput);
            sb.Remove(stringInput.Length - overFlow, overFlow);
            sb.Insert(0, rotateStr);
            string final = sb.ToString();

            // Output the result
            Console.WriteLine("Your rotated string is: " + final);

            return;
        }
    }
}
