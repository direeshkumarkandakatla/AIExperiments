using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsPractice.LeetCoding
{
    public static class RemoveAndMerge
    {

        public static int RunForMax(int[] nums)
        {
            var maxTough = BackTrackMechanism(nums, 0, 0);

            return maxTough;
        }

        static int BackTrackMechanism(int[] nums, int prev, int l)
        {
            if (l == nums.Length - 1)
                return Max(prev, nums[l]);

            if (l >= nums.Length)
                return prev;

            var val1 = BackTrackMechanism(nums, prev + nums[l + 1], l + 2);
            var val2 = BackTrackMechanism(nums, nums[l], l + 1);

            return Max(val1, val2);
        }

        static int Max(int a, int b)
        {
            return a > b ? a : b;
        }
    }
    
}
