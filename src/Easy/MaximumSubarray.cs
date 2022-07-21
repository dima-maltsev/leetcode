using System;
using Xunit;

namespace LeetCode.Easy;

// [Array] https://leetcode.com/problems/maximum-subarray/
public class MaximumSubarray
{
    // https://medium.com/@rsinghal757/kadanes-algorithm-dynamic-programming-how-and-why-does-it-work-3fd8849ed73d
    int KadenesAlgorithm(int[] nums)
    {
        if (nums.Length == 1) return nums[0];

        var globalMax = nums[0];
        var localMax = nums[0];

        for (var i = 1; i < nums.Length; i++)
        {
            localMax = Math.Max(localMax + nums[i], nums[i]);
            globalMax = Math.Max(localMax, globalMax);
        }

        return globalMax;
    }

    int BruteForce(int[] nums)
    {
        if (nums.Length == 1) return nums[0];

        var max = int.MinValue;

        for (var i = 0; i < nums.Length; i++)
        {
            var current = nums[i];
            var currentMax = current;

            for (var j = i + 1; j < nums.Length; j++)
            {
                current += nums[j];
                currentMax = Math.Max(current, currentMax);
            }

            max = Math.Max(max, currentMax);
        }

        return max;
    }

    [Theory]
    [InlineData(new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6)]
    [InlineData(new[] { 1 }, 1)]
    [InlineData(new[] { 5, 4, -1, 7, 8 }, 23)]
    public void Test(int[] nums, int expected)
    {
        var actual = KadenesAlgorithm(nums);
        Assert.Equal(expected, actual);
    }
}