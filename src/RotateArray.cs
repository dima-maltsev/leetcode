using System;
using Xunit;

namespace LeetCode
{
    // https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/646/
    public class RotateArray
    {
        public void Solution(int[] nums, int k) => Swap(nums, k);

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

        void Swap(int[] nums, int k)
        {
            if (k >= nums.Length) k %= nums.Length;
            if (k == 0 || nums.Length == 1) return;

            var index = 0;
            var count = 0;
            var tmp = nums[index];
            var odd = k > 1 && nums.Length % k == 0;

            while (count < nums.Length)
            {
                var source = tmp;

                var shift = odd && count == nums.Length / 2;
                if (shift)
                {
                    index++;
                    source = nums[index];
                }

                index += k;
                if (index >= nums.Length)
                    index %= nums.Length;

                tmp = nums[index];
                nums[index] = source;
                count++;
            }
        }

        [Theory]
        [InlineData(new[] { 1, 2 }, 5, new[] { 2, 1 })]
        [InlineData(new[] { 1, 2, 3 }, 2, new[] { 2, 3, 1 })]
        [InlineData(new[] { 1, 2, 3, 4 }, 2, new[] { 3, 4, 1, 2 })]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6 }, 3, new[] { 4, 5, 6, 1, 2, 3 })]
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