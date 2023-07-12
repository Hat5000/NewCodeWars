using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    public class SumIntervals1
    {
        private static bool Overlapping((int,int)interval1, (int, int) interval2)
        {
            return ( interval2.Item1 <= interval1.Item2 || interval2.Item1 <= interval1.Item2 ) ?   true : false; ;
 
        }
        public static int SumIntervals((int, int)[] intervals)
        {
            var list = intervals.ToList();
            bool changed = true;
            while (changed)
            {
                changed = false;
                for (int i = 0; i < list.Count - 1; i++)
                {
                    var interval1 = intervals[i];
                    for (int j = i + 1; j < list.Count; j++)
                    {
                        var interval2 = intervals[j];
                        if (Overlapping(interval1, interval2))
                        {
                            list[i] = (Math.Min(interval1.Item1, interval2.Item1), Math.Max(interval1.Item2, interval2.Item2));
                            list.RemoveAt(j);
                            changed = true;
                        }

                    }
                }
            }

            return list.Sum(x => x.Item2 - x.Item1);
        }
    }
}
