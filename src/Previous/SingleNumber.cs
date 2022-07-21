using System;
using System.Linq;
using Xunit;

namespace LeetCode.Previous;

// https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/549/
public class SingleNumber
{
    public int Solution(int[] nums)
    {
        return Xor(nums);
    }

    private int Xor(int[] nums)
    {
        if (nums.Length == 1) return nums[0];
        return nums.Aggregate(0, (a, t) => a ^ t);
    }

    private int SortedArray(int[] nums)
    {
        if (nums.Length == 1) return nums[0];

        Array.Sort(nums);

        var i = 0;
        while (i < nums.Length - 1)
        {
            if (nums[i] != nums[i + 1])
                return nums[i];

            i += 2;
        }

        return nums[i];
    }

    private int Linq(int[] nums)
    {
        if (nums.Length == 1) return nums[0];

        return nums
            .GroupBy(x => x)
            .First(g => g.Count() == 1)
            .First();
    }

    [Theory]
    [InlineData(new[] { 2, 2, 1 }, 1)]
    [InlineData(new[] { 4, 1, 2, 1, 2 }, 4)]
    [InlineData(new[] { 1 }, 1)]
    public void Test(int[] nums, int expected)
    {
        var actual = Solution(nums);
        Assert.Equal(expected, actual);
    }
}