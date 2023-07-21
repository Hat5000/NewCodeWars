using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    internal class Immortal
    {
        public static long ElderAge(long length, long width, long loss, long modulo)
        {
            long x = length  * width - loss;

            return (x * (x-1) / 2 ) % modulo; // do it!
        }
    }
}
