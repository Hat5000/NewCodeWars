using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeWars
{

    public class LinearSystem
    {
        static public float[][] Decode(string input)
        {
            return input.Split("\r\n").Select(x=>x.Split(' ').Select(i => float.Parse(i)).ToArray()).ToArray();
        }
        public static void subtractLinear(float[] subtractedLine, float[]subtractLine,float times)
        {
            for(int i = 0; i < subtractedLine.Length; i++)
            {
                subtractedLine[i] -= times * subtractLine[i];
            }
        }
        public static void draw(float[][] stelsel)
        {
            foreach (float[] stelselLine in stelsel)
            {
                Console.Write(stelselLine[0]);
                foreach (float f in stelselLine.Skip(1))
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
                        float firstNonZero = row[indexFirstNonZero];
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
                results[i] = linearSystem[currentRow].Last();
            }
            StringBuilder builder = new StringBuilder($"SOLUTION=({results[0].ToString()};");
            foreach (var f in results.Skip(1)) { builder.Append($" {f};"); };
            builder.Append(")");
            return builder.ToString();
        }
    }
}
