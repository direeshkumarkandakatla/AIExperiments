using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsPractice
{
    public class MetaPractice
    {


        public IList<IList<int>> VerticalOrder(TreeNode root)
        {
            if (root == null)
                return new List<IList<int>>();

            
            Queue<(TreeNode, int)> que = new Queue<(TreeNode, int)>();
            que.Enqueue((root, 0));
            
            Dictionary<int, IList<int>> verticalLists = new Dictionary<int, IList<int>>();

            while(que.Count > 0)
            {
                var (node, columnNumber) = que.Dequeue();                

                if (!verticalLists.ContainsKey(columnNumber))
                    verticalLists.Add(columnNumber, new List<int>());

                verticalLists[columnNumber].Add(node.val);

                if (node.left != null)
                    que.Enqueue((node.left, columnNumber - 1));

                if (node.right != null)
                    que.Enqueue((node.right, columnNumber + 1));
            }

            return verticalLists.OrderBy(v => v.Key).Select(v => v.Value).ToList();
        }

        public void MinRemoveToMakeValid(string s)
        {
            Stack<int> stack = new Stack<int>();
            
            List<int> ints = new List<int>();
            
                        
            stack.Select(s => s).ToList();
        }

        public int LongestPath(TreeNode root)
        {
            int lh = GetHeight(root.left);
            int rh = GetHeight(root.right);

            return lh + rh + 1;
        }

        int GetHeight(TreeNode node)
        {
            if (node == null) return 1;

            int lh = GetHeight(node.left);
            int rh = GetHeight(node.right);

            return lh > rh ? lh : rh + 1;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class RandomMaxNumber
    {
        public int[] store;
        public RandomMaxNumber(int[] input)
        {
            store = input;
        }

        public int Get()
        {
            Dictionary<int, List<int>> numberToIndexes = new Dictionary<int, List<int>>();

            int maxNumber = store[0];

            for(int i = 0; i < store.Length; i++)
            {
                if (store[i] >= maxNumber)
                {
                    maxNumber = store[i];
                    if (!numberToIndexes.ContainsKey(maxNumber))
                        numberToIndexes.Add(maxNumber, new List<int>());
                    
                    numberToIndexes[maxNumber].Add(i);
                }
            }

            Random rnd = new Random();
            return numberToIndexes[maxNumber][rnd.Next(0, numberToIndexes[maxNumber].Count - 1)];
        }
    }
}














