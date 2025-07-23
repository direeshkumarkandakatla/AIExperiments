using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsPractice.LeetCoding.BackTracking
{
    public static class BackTrackingSubSets
    {
        public static IList<IList<int>> Subsets(int[] nums)
        {

            IList<IList<int>> result = new List<IList<int>>();
            IList<int> current = new List<int>();

            if (nums.Length == 0)
            {
                result.Add(new List<int>());
                return result;
            }

            EvaluateSubSets(0, current, result, nums);

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
