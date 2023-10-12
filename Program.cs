using System;
using System.Numerics;

namespace AFL_DevelopmentCodingExercise
{
    class Program
    {
        #region Class-scope objects

        static string codingExerciseDescription = "Write a C# .net console application that takes numerical value as an argument and writes " +
                "it out in words according to the following rules:\r\n\r\n\r\n" +
                "* The application must support positive numbers only\r\n\r\n" +
                "* Ignore any negative numbers\r\n\r\n" +
                "* The application should work for all numbers including the following test cases\r\n" +
                "o 255\r\n" +
                "o 128\r\n" +
                "o -128\r\n" +
                "o 32768\r\n" +
                "o -32768\r\n" +
                "o 4294967295\r\n" +
                "o 9223372036854775807\r\n" +
                "o 18446744073709551615\r\n\r\n" +
                "* An example of the program input and output\r\n" +
                "o Input =>; 12345678912345678912\r\n" +
                "o Output =>; twelve quintillion three hundred and forty-five quadrillion six hundred and\r\n" +
                "seventy-eight trillion nine hundred and twelve billion three hundred and forty-five million\r\n" +
                "six hundred and seventy-eight thousand nine hundred and twelve";

        static string[] units = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        static string[] teens = { "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        static string[] tens = { "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        static string[] thousandsGroups = { "", "Thousand", "Million", "Billion", "Trillion", "Quadrillion", "Quintillion", "Sextillion", "Septillion", "Octillion", "Nonillion", "Decillion" };

        #endregion Class-scope objects

        //-----------------------------------------------

        #region Main Class

        static void Main(string[] args)
        {
            Console.WriteLine(codingExerciseDescription);

            Console.WriteLine("\n==============================================================\n");

            while (true)
            {
                Console.WriteLine("Enter a positive number:");
                string input = Console.ReadLine();
                Console.WriteLine("--------------");

                // using BigInteger variable to accomodate very big numbers
                if (BigInteger.TryParse(input, out BigInteger number))
                {
                    string words = ConvertNumbersToWords(number);
                    Console.WriteLine("Input => " + number);
                    Console.WriteLine("Output => " + words);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid positive number.");
                }

                Console.WriteLine("==============================================================");
            }
        }

        #endregion Main Class

        //-----------------------------------------------

        #region Support Methods

        static string ConvertNumbersToWords(BigInteger number)
        {
            if (number == 0)
            {
                return units[0];
            }

            if (number < 0)
            {
                return "Invalid input. Please enter a valid positive number.";
            }

            string words = "";

            for (int i = 0; number > 0; i++)
            {
                if (number % 1000 != 0)
                {
                    words = ConvertNumbersToWords100s((int)(number % 1000)) + thousandsGroups[i] + " " + words;
                }
                // Divides the number by 1000 to process the next group of three digits
                number = number / 1000;
            }

            return words.Trim();
        }

        static string ConvertNumbersToWords100s(long number)
        {
            string words = "";

            if (number >= 100)
            {
                // Adds the hundreds place
                words += units[number / 100] + " Hundred ";
                // Removes the hundreds place from the number
                number = number % 100;
            }

            if (number >= 11 && number <= 19)
            {
                // Handles numbers between 11 and 19
                words += teens[number - 11] + " ";
            }

            else if (number == 10 || number >= 20)
            {
                // Handles tens place
                words += tens[number / 10 - 1] + " ";
                // Removes the tens place from the number
                number = number % 10;
            }

            if (number >= 1 && number <= 9)
            {
                // Handles units place
                words += units[number] + " ";
            }

            return words;
        }

        #endregion Support Methods

        //-----------------------------------------------
    }
}
