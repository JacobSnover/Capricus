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

            ArrayBuilder(input, inputArray, strArray);
            Calculator(input, numInput, inputArray);

        }

        private static void Calculator(string input, long numInput, long[] inputArray)
        {
            int j = 0;
            int victory = 0;
            while (j < input.Length - 1)
            {
                int counter = 1;
                long result = inputArray[j];
                while (result < numInput)
                {
                    counter++;
                    result *= inputArray[j];
                    if (result >= numInput)
                    {
                        if (result == numInput)
                        {
                            victory++;
                            Console.WriteLine($"{victory}-Capricus since {inputArray[j]} to the power of {counter} = {numInput}");
                        }
                        j++;
                        break;
                    }
                }
                if (j == input.Length - 1 && victory == 0)
                {
                    Console.WriteLine($"Sorry {numInput} is not a Capricus.");
                }
            }
        }

        private static void ArrayBuilder(string input, long[] inputArray, string[] strArray)
        {
            for (int i = 1; i < input.Length; i++)
            {
                input.Substring(input.Length - i, i);
                string temp = input.Substring(input.Length - i, i);
                strArray[i - 1] = temp;
            }

            for (int i = 0; i < strArray.Length; i++)
            {
                if ((i + 1) < input.Length)
                    inputArray[i] = Convert.ToInt64(strArray[i]);

            }
        }
    }
}