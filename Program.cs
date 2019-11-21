using System;
using System.Collections.Generic;

namespace SumFactorsWithCarry
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(args[0]);
            var pairs = GetPairs(number);
            foreach (var item in pairs)
            {
                Console.WriteLine(string.Format("{0},{1}", item.Item1, item.Item2));
            }
        }

        private static List<Tuple<int, int>> GetPairs(int number)
        {
            List<Tuple<int, int>> pairs = new List<Tuple<int, int>>();

            for (int i = 1; i <= number / 2; i++)
            {
                if (CountCarry(i.ToString(), (number - i).ToString()) <= 0)
                {
                    pairs.Add(new Tuple<int, int>(i, number - i));
                }
            }

            return pairs;
        }


        /// <summary>
        /// Check how many carries occur when adding two numbers
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <param name="_base">BASE system used in your number. Decimal , Binary , HEX etc</param>
        /// <returns></returns>
        private static int CountCarry(string a, string b,int _base = 10)
        {
            // Initialise the value of carry to 0 
            int carry = 0;

            // Counts the number of carry operations 
            int count = 0;

            // Initialise len_a and len_b with the sizes of strings 
            int len_a = a.Length, len_b = b.Length;

            while (len_a != 0 || len_b != 0)
            {

                // Assigning the ascii value of the character 
                int x = 0, y = 0;
                if (len_a > 0)
                {
                    x = a[len_a - 1] - '0';
                    len_a--;
                }
                if (len_b > 0)
                {
                    y = b[len_b - 1] - '0';
                    len_b--;
                }

                // Add both numbers/digits 
                int sum = x + y + carry;

                // If sum > 0, icrement count 
                // and set carry to 1 
                if (sum >= _base)
                {
                    carry = 1;
                    count++;
                }

                // Else, set carry to 0 
                else
                    carry = 0;
            }

            return count;
        }
    }
}
