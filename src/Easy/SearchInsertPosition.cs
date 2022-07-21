using Xunit;

namespace LeetCode.Easy;

// [Array] https://leetcode.com/problems/search-insert-position/
public class SearchInsertPosition
{
    int SearchInsert(int[] nums, int target)
    {
        var size = nums.Length;

        if (target <= nums[0]) return 0;
        if (target > nums[size - 1]) return size;
        if (target == nums[size - 1]) return size - 1;

        var start = 0;
        var end = size - 1;

        while (end - start > 0)
        {
            var index = start + (end - start) / 2;

            if (nums[index] == target) return index;

            if (nums[index] < target)
                start = index + 1;
            else
                end = index;
        }

        return start;
    }

    [Theory]
    [InlineData(new[] { 1, 3, 5, 6 }, 5, 2)]
    [InlineData(new[] { 1, 3, 5, 6 }, 2, 1)]
    [InlineData(new[] { 1, 3, 5, 6 }, 7, 4)]
    [InlineData(new[] { 1, 3, 5, 6 }, 4, 2)]
    [InlineData(new[] { -5, -3, 0, 2, 7, 14 }, -7, 0)]
    [InlineData(new[] { -5, -3, 0, 2, 7, 14 }, -5, 0)]
    [InlineData(new[] { -5, -3, 0, 2, 7, 14 }, 14, 5)]
    [InlineData(new[] { -5, -3, 0, 2, 7, 14 }, 18, 6)]
    [InlineData(new[] { -5, -3, 0, 2, 7, 14 }, 0, 2)]
    [InlineData(new[] { -5, -3, 0, 2, 7, 14 }, -2, 2)]
    [InlineData(new[] { -5, -3, 0, 2, 7, 14 }, 1, 3)]
    [InlineData(new[] { -5, -3, 0, 2, 7, 14 }, 4, 4)]
    [InlineData(new[] { -5, -3, 0, 2, 7, 14 }, 8, 5)]
    public void Test(int[] nums, int target, int expected)
    {
        var actual = SearchInsert(nums, target);
        Assert.Equal(expected, actual);
    }
}