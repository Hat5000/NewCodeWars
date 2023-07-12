using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CodeWars
{
    public static class Kata
    {
        private static double GetFactor(char[] expression, ref int i)
        {
            if (expression[i] == '(')
            {
                var openParenthese = 1;
                var betweenParenthese = new StringBuilder();
                while (true)
                {
                    i++;
                    char current = expression[i];
                    if (current == '(')
                    {
                        openParenthese++;
                    }
                    if (current == ')')
                    {
                        openParenthese--;
                        if (openParenthese == 0)
                        {
                            break;
                        }
                    }
                    betweenParenthese.Append(current);
                }
                return calculate(betweenParenthese.ToString());
            }
            else
            {
                double number = Double.Parse(expression[i].ToString());
                double nextCifer;
                while (i + 1 < expression.Length && Double.TryParse(expression[i + 1].ToString(), out nextCifer))
                {
                    number = number * 10 + nextCifer;
                    i++;
                }
                if(i + 1 < expression.Length && expression[i + 1] == '.')
                {
                    i++;
                    double afterKomma = 0;
                    int counter = 1;
                    while (i + 1 < expression.Length && Double.TryParse(expression[i + 1].ToString(), out nextCifer))
                    {
                        afterKomma += nextCifer / Math.Pow(10, counter);
                        counter++;
                        i++;
                    }
                    number += afterKomma;
                }
                return number;
            }
        }
        private static (List<char>, List<Func<double, double, double>>)[] _orderOfOperations = new (List<char>, List<Func<double, double, double>>)[]{ (new List<char>() {'^'},new List<Func<double, double, double>>() {(x,y)=>Math.Pow(x,y)}),
                                                                                                                                                       (new List<char>() {'*','/'},new List<Func<double, double, double>>() {(x,y)=> x*y,(x,y)=> x/y }),
                                                                                                                                                       (new List<char>() {'+','-'},new List<Func<double, double, double>>() {(x,y)=>x+y,(x,y)=>x-y})};
        public static double calculate(string s)
        {
            char[] withoutSpaces = Regex.Replace(s, " ", "").ToCharArray();
            if (withoutSpaces.Length == 0)
            {
                return 0;
            }
            int i = 0;
            List<double> numbers = new List<double>() { GetFactor(withoutSpaces, ref i) };
            i++;
            List<char> operations = new List<char>();
            for (; i < withoutSpaces.Length - 1; i++)
            {
                operations.Add(withoutSpaces[i]);
                i++;
                numbers.Add(GetFactor(withoutSpaces, ref i));
            }
            //Console.WriteLine(withoutSpaces);
            //Console.WriteLine("Operations");
            //foreach (var operation in operations)
            //{

            //    Console.Write(operation.ToString());
            //}
            //Console.WriteLine("\nNumbers");
            //foreach (var number in numbers)
            //{
            //    Console.Write($"{number.ToString()} ");
            //}
            //Console.WriteLine("\n");
            foreach (var symbol in _orderOfOperations)
            {
                var possibleSymbols = symbol.Item1;
                for (i = 0; operations.Count > i;) {
                    if (possibleSymbols.Contains(operations[i]))
                    {
                        var operation = symbol.Item2[possibleSymbols.IndexOf(operations[i])];
                        numbers[i] = operation(numbers[i], numbers[i + 1]);
                        numbers.RemoveAt(i + 1);
                        operations.RemoveAt(i);
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            return numbers[0];
        }

    }
}
