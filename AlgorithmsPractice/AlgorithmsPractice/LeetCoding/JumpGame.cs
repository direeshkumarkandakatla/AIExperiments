using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsPractice.Leet150
{
    public class JumpGame
    {
        public static void Execute()
        {
            int[] nums = [9, 3, 2, 1, 0, 2, 3, 3, 1, 0, 0];
            int l = 0;
            int r = 2;
            int x = int.MaxValue;

            //int? drrom = null;
            //if (drrom.HasValue)
            //    return drrom.Value

            //IList<IList<int>> x = new List<IList<int>>() { new List<int>() };

            Console.WriteLine(CanJump(nums));
        }

        private void xxx(int x, int y)
        {

        }

        private TreeNode InvertRecursive(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            queue.Dequeue();
            if (root == null)
                return root;

            var temp = InvertRecursive(root.left);
            root.left = InvertRecursive(root.right);
            root.right = temp;

            return root;
        }

        int max(int a, int b) => a > b ? a : b;

        private static int CanJump(int[] nums)
        {

            int?[] store = new int?[nums.Length];

            //int x = Math.Ceiling((double)(12 / 3));

            //store.OrderByDescending
            string s = string.Empty;
            
            return CanReachEnd(0, nums, store);
        }

        private static int CanReachEnd(int i, int[] nums, int?[] store)
        {
            

            if (store[i].HasValue)
                return store[i].Value;

            if (nums[i] == 0)
            {
                store[i] = 0;
                return 0;
            }

            if (i + nums[i] >= nums.Length - 1)
            {
                store[i] = 1;
                return 1;
            }

            var min = int.MaxValue;
            for (int j = 1; j <= nums[i]; j++)
            {
                var x = CanReachEnd(i + j, nums, store);
                if (x == 0)                
                    continue;                

                if (x < min)
                    min = x;
            }
            store[i] = min == int.MaxValue ? 0 : min + 1;

            return store[i].Value;
        }

    }


}
