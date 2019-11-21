using System;
using System.Collections.Generic;

namespace SumFactorsWithCarry
{
    class Program
    {
        static void Main(string[] args)
        {
            //what base the number is on
            int _base = int.Parse(args[1]);
            int number = ConvertToDecimal(args[0], _base);
            var pairs = GetPairs(number,_base);
            foreach (var item in pairs)
            {
                Console.WriteLine(string.Format("{0},{1}", item.Item1, item.Item2));
            }
        }

        //find number pairs
        private static List<Tuple<string, string>> GetPairs(int number,int _base)
        {
            List<Tuple<string, string>> pairs = new List<Tuple<string, string>>();

            for (int i = 1; i <= number / 2; i++)
            {
                if (CountCarry(ConvertDecimalToAnyBase(i,_base),
                    ConvertDecimalToAnyBase(number - i,_base),_base) <= 0)
                {
                    pairs.Add(new Tuple<string, string>(
                        ConvertDecimalToAnyBase(i,_base), 
                        ConvertDecimalToAnyBase( number - i,_base)
                        ));
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
        private static int CountCarry(string a, string b,int _base)
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


        private static int ConvertToDecimal(string number, int _base)
        {
            char[] chars = number.ToCharArray();
            int decTotal = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                decTotal += (chars[chars.Length-(i+1)] - '0') * (int)(Math.Pow(_base, i));
            }

            return decTotal;
        }

        private static string ConvertDecimalToAnyBase(int number, int _base)
        {
            Stack<int> result = new Stack<int>();
            do
            {
                result.Push((number % _base));
                number = number / _base;
            } while (number >= _base);

            result.Push(number);
            return string.Join("", result.ToArray());
        }
    }
}
