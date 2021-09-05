using System;
using Xunit;

namespace LeetCode
{
    // https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/646/
    public class RotateArray
    {
        public int[] Solution(int[] nums, int k) => Solution1(nums, k);

        int[] Solution1(int[] nums, int k)
        {
            if (k == 0 || k == nums.Length) return nums;
            return Array.Empty<int>();
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7 }, 1, new[] { 7, 1, 2, 3, 4, 5, 6 })]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7 }, 2, new[] { 6, 7, 1, 2, 3, 4, 5 })]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new[] { 5, 6, 7, 1, 2, 3, 4 })]
        [InlineData(new[] { -1, -100, 3, 99 }, 1, new[] { 99, -1, -100, 3 })]
        [InlineData(new[] { -1, -100, 3, 99 }, 2, new[] { 3, 99, -1, -100 })]
        public void Test(int[] nums, int k, int[] expected)
        {
            var actual = Solution(nums, k);
            Assert.Equal(expected, actual);
        }
    }
}