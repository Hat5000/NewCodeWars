using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    public class Anagrams
    {
        public static long Fibonnacci(int number)
        {
            long result = 1;
            for(; 1 < number;number-- )
            {
                result *= number;
            }
            return result;  
        }
        private static int charToIndex(char chr)
        {
            return chr - 'A';
        }
        public static long newPosibilities(long prevPossibilities, int countLetter, int lengthWord)
        {
            return prevPossibilities * countLetter/lengthWord;
        }
        public static long ListPosition(string value)
        {
            //intializeren
            var lettersCount = new int[26];
            foreach(var chr in value)
            {
                lettersCount[charToIndex(chr)]++;
            }
            long possibilities = Fibonnacci(value.Length);
            foreach(var letterCount in lettersCount)
            {
                possibilities /= Fibonnacci(letterCount);
            }


            //Calculating
            long result = 1;
            int lengthWord = value.Length;
            foreach(var chr in value)
            {
                foreach (var item in lettersCount)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
                Console.WriteLine($"Current possibilities {possibilities}");
                int index = 0;
                foreach(var letterCount in lettersCount)
                {
                    if(letterCount != 0)
                    {
                        if (index == charToIndex(chr))
                        {
                            break;
                        }
                        Console.WriteLine($"Char: {Convert.ToChar(index +'A')} Count: {letterCount} Plus:{newPosibilities(possibilities, letterCount, lengthWord)}");
                        result += newPosibilities(possibilities, letterCount, lengthWord);
                    }
                    index++;
                }
                possibilities = newPosibilities(possibilities, lettersCount[charToIndex(chr)], lengthWord);
                lettersCount[charToIndex(chr)]--;
                lengthWord--;
            }
            return result;
        }
    }
}
