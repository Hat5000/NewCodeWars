using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeWars
{
    public class Fractal
    {
        public static int Gcd(int number1, int number2)
        {
            Console.WriteLine($"{number1} {number2}");
            if(number1 == 0)
            {
                return number2;
            }
            else
            {
                return Gcd(number2 %  number1, number1);
            }
        }
        public int number { get; private set; }
        public int divisor { get; private set; }
        public Fractal(int _number) 
        {
            number = _number;
            divisor = 1;
        }
        public Fractal(int _number, int _divisor)
        {
            number = _number;
            divisor = _divisor;
        }
        public float ToFloat()
        {
            return number / divisor;
        }
        public void Add(int value)
        {
            number += divisor * value;
        }
        public void Add(Fractal value) 
        {
            
        }
        public void Multiply(int value)
        {
            number *= value;
        }
        public void Multiply (Fractal value)
        {

        }

    }
    public class LinearSystem
    {
        static public double[][] Decode(string input)
        {
            return input.Split("\r\n").Select(x=>x.Split(' ').Select(i => double.Parse(i)).ToArray()).ToArray();
        }
        public static void subtractLinear(double[] subtractedLine, double[]subtractLine,double times)
        {
            for(int i = 0; i < subtractedLine.Length; i++)
            {
                subtractedLine[i] -= times * subtractLine[i];
            }
        }
        public static void draw(double[][] stelsel)
        {
            foreach (double[] stelselLine in stelsel)
            {
                Console.Write(stelselLine[0]);
                foreach (double f in stelselLine.Skip(1))
                {
                    if(0 <= f)
                    {
                        Console.Write(' ');
                    }
                    Console.Write($" {f}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static public string Solve(string input)
        {
            //float array that represents the linear problem
            var linearSystem = Decode(input);
            //the row index that we are currently iterating on
            int currentRow = 0;
            foreach(var row in linearSystem)
            {
                bool zeroRow = true;
                for(int indexFirstNonZero = 0; indexFirstNonZero < row.Length - 1; indexFirstNonZero++)
                {
                    if (row[indexFirstNonZero] != 0)
                    {
                        zeroRow = false;
                        //makes the first non zero element in the list 1
                        double firstNonZero = row[indexFirstNonZero];
                        for (int i = 0; i < row.Length; i++)
                        {
                            row[i] /= firstNonZero;
                        }
                        //makes a nul kolom in the linear equation(except on the current row)
                        for (int i = 0; i< linearSystem.Length; i++)
                        {
                            if(i != currentRow)
                            {
                                subtractLinear(linearSystem[i], row, linearSystem[i][indexFirstNonZero]);
                            }
                        }
                        draw(linearSystem);
                        break;
                    }
                }
                //if al elements in a row are zero the linear equation has no solution
                if (zeroRow)
                {
                    return "SOLUTION=NONE";
                }
                currentRow++;
            }
            float[] results = new float[linearSystem[0].Length - 1];
            for(currentRow = 0;  currentRow < linearSystem.Length; currentRow++)
            {
                int i = 0;
                while (linearSystem[currentRow][i] == 0)
                {
                    i++;
                }
                results[i] = (float)linearSystem[currentRow].Last();
            }
            StringBuilder builder = new StringBuilder($"SOLUTION=({results[0].ToString()};");
            foreach (var f in results.Skip(1)) { builder.Append($" {f};"); };
            builder.Append(")");
            return builder.ToString();
        }
    }
}
