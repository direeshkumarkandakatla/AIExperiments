using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsPractice.LeetCoding
{
    public static class ParanthesisBalance
    {
        public static string BalanceString(string s) 
        {
            if (string.IsNullOrEmpty(s)) return s;

            string retVal = string.Empty;
            Stack<Item> store = new Stack<Item>();

            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(' || s[i] == ')')
                {
                    if (store.Count == 0 || s[i] == '(')
                        store.Push(new Item(s[i], i));
                    else
                    {
                        if (store.Peek().character == '(')
                            store.Pop();
                        else
                            store.Push(new Item(s[i], i));
                    }
                }
            }

            for(int i = s.Length - 1; i >= 0; i--)
            {
                if (store.Count > 0 && store.Peek().index == i) {
                    store.Pop();
                    continue;
                }
                retVal = s[i] + retVal;
            }

            return retVal;
        }
    }

    public class Item
    {
        public Item(char character, int index)
        {
            this.character = character;
            this.index = index;
        }

        public char character { get; set; }
        public int index { get; set; }
    }
}
