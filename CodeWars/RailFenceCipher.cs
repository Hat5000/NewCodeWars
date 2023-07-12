using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    public class RailFenceCipher
    {
        public static string Encode(string s, int n)
        {           
            StringBuilder[] stringBuilders = new StringBuilder[n];
            for (int i = 0; i < n; i++)
            {
                stringBuilders[i] = new StringBuilder();
            }
            int currentStringbuilder = 0;
            int ascendingDescending = 1;
            foreach (char c in s)
            {
                stringBuilders[currentStringbuilder].Append(c);
                if(currentStringbuilder == 0)
                {
                    ascendingDescending = 1;
                }
                if(currentStringbuilder == n - 1)
                {
                    ascendingDescending = -1;
                }
                currentStringbuilder += ascendingDescending;
            }
            foreach(var stringbuilder in stringBuilders.Skip(1))
            {
                stringBuilders[0].Append(stringbuilder);
            }
            return stringBuilders[0].ToString();
        }
        public static string Decode(string s, int n) {
            int[] lengts = new int[n];
            lengts[0] = (s.Length - 1) / (2 * n - 2) + 1;
            lengts[n - 1] = (s.Length + 1) / (2 * n - 2);
            if (2 < n)
            {
                int middle = s.Length - lengts[0] - lengts[n - 1];
                int rest = middle % (n - 2);
            }
            return null;
        }
    }
}
