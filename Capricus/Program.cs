using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capricus
{
    class Program
    {
        static void Main(string[] args)
        {
            //different variables to display results
            Console.Write("Enter a number please: ");
            string input = Console.ReadLine();
            long numInput = Convert.ToInt64(input);
            long[] inputArray = new long[input.Length - 1];
            string[] strArray = new string[input.Length - 1];

            //build the arrays to use in this program
            ArrayBuilder(input, inputArray, strArray);

            //display the output of the calculation
            Calculator(input, numInput, inputArray);

        }

        private static void Calculator(string input, long numInput, long[] inputArray)
        {
            //set up my index and victory variables
            int j = 0;
            int victory = 0;
            while (j < input.Length - 1)
            {
                //set up a counter to show which power to raise to
                int counter = 1;
                long result = inputArray[j];
                //my loop will run until the result is greater then the input
                while (result < numInput)
                {
                    //increment my counter to show proper exponential power
                    counter++;
                    //calculate the number by exponent, starting at 2 and going till satisfied
                    result *= inputArray[j];
                    if (result >= numInput)
                    {
                        if (result == numInput)
                        {
                            //output if Capricus is found which also increments victory variable
                            //to show that Capricus was found
                            victory++;
                            Console.WriteLine($"{victory}-Capricus since {inputArray[j]} to the power of {counter} = {numInput}");
                        }
                        //advance the array index and break out of loop to continnue with calculation
                        j++;
                        break;
                    }
                }
                //check to see if Capricus was found
                if (j == input.Length - 1 && victory == 0)
                {
                    //output to let user know no Capricus was found
                    Console.WriteLine($"Sorry {numInput} is not a Capricus.");
                }
            }
        }
        //method to build my arrays
        private static void ArrayBuilder(string input, long[] inputArray, string[] strArray)
        {
            for (int i = 1; i < input.Length; i++)
            {
                //separate input to get substrings of the original input
                //which will be used to check for a Capricus number
                input.Substring(input.Length - i, i);
                string temp = input.Substring(input.Length - i, i);
                strArray[i - 1] = temp;
            }

            for (int i = 0; i < strArray.Length; i++)
            {
                //taking those substrings and converting to int
                if ((i + 1) < input.Length)
                    inputArray[i] = Convert.ToInt64(strArray[i]);

            }
        }
    }
}