using Xunit;

namespace LeetCode;

// [Easy][Array] https://leetcode.com/problems/single-number/
public class SingleNumberSolved
{
    int Solution(int[] nums)
    {
        if (nums.Length == 1) return nums[0];

        var set = new HashSet<int>();

        foreach (var t in nums)
        {
            if (set.Contains(t))
            {
                set.Remove(t);
                continue;
            }

            set.Add(t);
        }

        return set.First();
    }

    int BitManipulation(int[] nums)
    {
        if (nums.Length == 1) return nums[0];

        var x = nums[0];
        for (var i = 1; i < nums.Length; i++)
            x ^= nums[i];

        return x;
    }

    int BitManipulationSimplified(int[] nums)
    {
        if (nums.Length == 1) return nums[0];
        return nums.Aggregate(0, (current, t) => current ^ t);
    }

    [Theory]
    [InlineData(new[] { 2, 2, 1 }, 1)]
    [InlineData(new[] { 4, 1, 2, 1, 2 }, 4)]
    [InlineData(new[] { 1 }, 1)]
    public void Test(int[] nums, int expected)
    {
        var actual = BitManipulationSimplified(nums);
        Assert.Equal(expected, actual);
    }
}