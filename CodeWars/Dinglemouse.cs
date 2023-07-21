using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeWars
{
    internal class Dinglemouse
    {
        public static string Siegfried(int week, string str)
        {
            string result = Regex.Replace(Regex.Replace(Regex.Replace(str, "ci", "si"), "ce", "se"), "c", "k");
            return result;
        }
    }
}
