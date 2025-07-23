using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsPractice.LeetCoding.Graphs
{
    public static class GraphNumberOfIslands
    {
        public static IList<IList<int>> Subsets(int[] nums)
        {

            List<(int x, int y)> values = new List<(int x, int y)>();

            Queue<(int r, int c)> store = new Queue<(int r, int c)>();

            store.Enqueue((1, 1));
            var x = store.Dequeue();

            bool[][] visited = new bool[1][];

            IList<IList<int>> result = new List<IList<int>>();
            IList<int> current = new List<int>();

            if (nums.Length == 0)
            {
                result.Add(new List<int>());
                return result;
            }

            EvaluateSubSets(0, current, result, nums);


            //Stack some = new Stack();

            //some.Peek();
            //some.Pop();
            //some.Push(0)
            

            return result;
        }

        static void EvaluateSubSets(int i, IList<int> current, IList<IList<int>> result, int[] nums)
        {

            if (i == nums.Length)
            {
                result.Add(current);
                return;
            }
            var newList = new List<int>(current)
            {
                nums[i]
            };

            EvaluateSubSets(i + 1, newList, result, nums);
            EvaluateSubSets(i + 1, current, result, nums);

        }
    }
}
