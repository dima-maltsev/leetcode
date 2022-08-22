using System;
using System.Collections.Generic;
using Xunit;

namespace LeetCode.Easy;

// [Array] https://leetcode.com/problems/two-sum/
public class TwoSum
{
    int[] BruteForce(int[] nums, int target)
    {
        if (nums.Length == 2) return new[] { 0, 1 };

        for (var i = 0; i < nums.Length - 1; i++)
        for (var j = 1; j < nums.Length; j++)
            if (nums[i] + nums[j] == target)
                return new[] { i, j };

        throw new InvalidOperationException("Solution not found");
    }

    int[] Optimized(int[] nums, int target)
    {
        if (nums.Length == 2) return new[] { 0, 1 };

        var map = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            if (map.ContainsKey(nums[i]))
                return new[] { map[nums[i]], i };

            map[target - nums[i]] = i;
        }

        throw new NotImplementedException("Solution not found");
    }

    [Theory]
    [InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
    [InlineData(new[] { 3, 2, 4 }, 6, new[] { 1, 2 })]
    [InlineData(new[] { 3, 3 }, 6, new[] { 0, 1 })]
    public void Test(int[] nums, int target, int[] expected)
    {
        var actual = Optimized(nums, target);
        Assert.Equal(expected, actual);
    }
}