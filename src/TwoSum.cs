using System;
using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    // https://leetcode.com/problems/two-sum/
    public class TwoSum
    {
        public int[] Solution(int[] nums, int target) => Map(nums, target);

        public int[] Map(int[] nums, int target)
        {
            var map = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                var key = target - nums[i];
                if (map.ContainsKey(key))
                {
                    return new[] { map[key], i };
                }

                map[nums[i]] = i;
            }

            return Array.Empty<int>();
        }

        public int[] BruteForce(int[] nums, int target)
        {
            for (var i = 0; i < nums.Length - 1; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new[] { i, j };
                    }
                }
            }

            return Array.Empty<int>();
        }

        [Theory]
        [InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
        [InlineData(new[] { 3, 2, 4 }, 6, new[] { 1, 2 })]
        [InlineData(new[] { 3, 3 }, 6, new[] { 0, 1 })]
        public void Test(int[] nums, int target, int[] expected)
        {
            var actual = new TwoSum().Solution(nums, target);
            Assert.Equal(expected, actual);
        }
    }
}