using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    public class FactorialTail
    { 
        public static List<int[]> Factorize(int number) {
            var list = new List<int[]>();
            int counter = 2;
            int numberOfTimes = 0;
            while (1 < number) 
            {
                if (number % counter == 0)
                {
                    numberOfTimes++;
                    number /= counter;
                }
                else
                {
                    if (numberOfTimes != 0)
                    {
                        list.Add(new int[] { counter, numberOfTimes });
                        numberOfTimes = 0;
                    }
                    counter++;
                }
            }
            if (numberOfTimes != 0)
            {
                list.Add(new int[] { counter, numberOfTimes });
                numberOfTimes = 0;
            }

            return list;
        }
        public static int factorialDivisibility(int factorial, int prime)
        {
            var result = 0;
            while(factorial > 1)
            {
                factorial /= prime;
                result += factorial;
            }
            return result;
        }
        public static int zeroes(int radix, int number)
        {
            var factors = Factorize(radix);
            int min = int.MaxValue;
            foreach (var factor in factors)
            {
                int numberOfZeros = factorialDivisibility(number, factor[0]) / factor[1];
                min = Math.Min(min, numberOfZeros);
            }
            return min;
        }
    }
}
