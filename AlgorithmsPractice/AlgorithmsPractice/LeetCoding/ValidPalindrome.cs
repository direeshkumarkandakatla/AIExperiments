using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsPractice.Leet150
{
    public class ValidPalindrome
    {
        public static void Execute()
        {
            string s = "0P";
            Console.WriteLine(IsPalindrome(s));
        }

        public static bool IsPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(s.Trim()))
                return true;

            for (int i = 0, j = s.Length - 1; i <= j;)
            {
                Console.WriteLine(i + " " + j);
                int val1;
                int val2;

                if (!isAlphaBet(s[i], out val1))
                {
                    i++;
                    continue;
                }

                if (!isAlphaBet(s[j], out val2))
                {
                    j--;
                    continue;
                }
                Console.WriteLine(val1 + " " + val2);
                if (val1 != val2)
                    return false;
                i++;
                j--;
                Console.WriteLine(i + " " + j);
            }
            return true;
        }

        private static bool isAlphaBet(char c, out int val)
        {
            if ((c >= 'a' && c <= 'z'))
            {
                val = c - 'a';
                return true;
            }

            if (c >= 'A' && c <= 'Z')
            {
                val = c - 'A';
                return true;
            }
            val = -1;
            return false;
        }
    }
}
