using System;
using Xunit;

namespace LeetCode
{
    // https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/646/
    public class RotateArray
    {
        public void Solution(int[] nums, int k) => Swap2(nums, k);

        void NewArray(int[] nums, int k)
        {
            if (k >= nums.Length) k %= nums.Length;
            if (k == 0 || nums.Length == 1) return;

            var result = new int[nums.Length];

            for (var i = 0; i < nums.Length; i++)
            {
                var index = i + k;
                if (index >= nums.Length)
                    index %= nums.Length;

                result[index] = nums[i];
            }
        }

        void ArrayCopy(int[] nums, int k)
        {
            if (k >= nums.Length) k %= nums.Length;
            if (k == 0 || nums.Length == 1) return;

            var result = new int[nums.Length];
            Array.Copy(nums, nums.Length - k, result, 0, k);
            Array.Copy(nums, 0, result, k, nums.Length - k);
        }

        void SameArrayCopy(int[] nums, int k)
        {
            if (k >= nums.Length) k %= nums.Length;
            if (k == 0 || nums.Length == 1) return;

            var len = Math.Min(k, nums.Length - k);
            var tmp = new int[len];

            if (len == k)
            {
                Array.Copy(nums, nums.Length - k, tmp, 0, k);
                Array.Copy(nums, 0, nums, k, nums.Length - k);
                Array.Copy(tmp, 0, nums, 0, k);
            }
            else
            {
                Array.Copy(nums, 0, tmp, 0, len);
                Array.Copy(nums, len, nums, 0, k);
                Array.Copy(tmp, 0, nums, k, len);
            }
        }

        void ReverseSolution(int[] nums, int k)
        {
            k %= nums.Length;
            if (k == 0 || nums.Length == 1) return;

            ReverseArray(nums, 0, nums.Length - 1);
            ReverseArray(nums, 0, k - 1);
            ReverseArray(nums, k, nums.Length - 1);
        }

        void ReverseArray(int[] nums, int start, int end)
        {
            while (start < end)
            {
                (nums[start], nums[end]) = (nums[end], nums[start]);
                start++;
                end--;
            }
        }

        void Swap2(int[] nums, int k)
        {
            var len = nums.Length;
            k %= len;
            if (k == 0 || len == 1) return;

            var index = 0;
            var swapPos = k;

            for (var count = 0; count < len; count++)
            {
                if (swapPos == index)
                {
                    index++;
                    swapPos = (index + k) % len;
                    continue;
                }

                (nums[index], nums[swapPos]) = (nums[swapPos], nums[index]);
                swapPos = (swapPos + k) % len;
            }
        }

        [Theory]
        [InlineData(new[] { 1, 2 }, 5, new[] { 2, 1 })]
        [InlineData(new[] { 1, 2, 3 }, 2, new[] { 2, 3, 1 })]
        [InlineData(new[] { 1, 2, 3, 4 }, 2, new[] { 3, 4, 1, 2 })]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6 }, 2, new[] { 5, 6, 1, 2, 3, 4 })]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6 }, 3, new[] { 4, 5, 6, 1, 2, 3 })]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6 }, 4, new[] { 3, 4, 5, 6, 1, 2 })]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7 }, 1, new[] { 7, 1, 2, 3, 4, 5, 6 })]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7 }, 2, new[] { 6, 7, 1, 2, 3, 4, 5 })]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new[] { 5, 6, 7, 1, 2, 3, 4 })]
        [InlineData(new[] { -1, -100, 3, 99 }, 1, new[] { 99, -1, -100, 3 })]
        [InlineData(new[] { -1, -100, 3, 99 }, 2, new[] { 3, 99, -1, -100 })]
        public void Test(int[] nums, int k, int[] expected)
        {
            Solution(nums, k);
            Assert.Equal(expected, nums);
        }
    }
}