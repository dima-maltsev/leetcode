using Xunit;

namespace LeetCode;

// [Easy][Array] https://leetcode.com/problems/majority-element/
public class MajorityElement
{
    int HashMap(int[] nums)
    {
        if (nums.Length == 1) return nums[0];

        var threshold = nums.Length / 2 + nums.Length % 2;

        var map = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            if (!map.ContainsKey(num))
                map.Add(num, 0);
            
            if (++map[num] == threshold)
                return num;
        }

        throw new InvalidOperationException();
    }

    int Linq(int[] nums)
    {
        return nums.GroupBy(x => x).MaxBy(g => g.Count())!.Key;
    }

    int Sorted(int[] nums)
    {
        if (nums.Length == 1) return nums[0];

        var threshold = nums.Length / 2 + nums.Length % 2;

        Array.Sort(nums);

        var num = nums[0];
        var max = 1;
        
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] == num)
            {
                max++;
                if (max == threshold)
                    return num;
            }
            else
            {
                num = nums[i];
            }
        }

        return num;
    }

    int SortedSimplified(int[] nums)
    {
        Array.Sort(nums);
        return nums[nums.Length / 2];
    }

    // https://leetcode.com/problems/majority-element/discuss/51613/O(n)-time-O(1)-space-fastest-solution
    int BoyerMoorMajorityVoteAlgorithm(int[] nums)
    {
        var major = nums[0];
        var count = 1;

        for (var i = 1; i < nums.Length; i++)
        {
            if (count == 0)
            {
                count++;
                major = nums[i];
            }
            else if (major == nums[i])
            {
                count++;
            }
            else
            {
                count--;
            }
        }

        return major;
    }

    [Theory]
    [InlineData(new[] { 3, 2, 3 }, 3)]
    [InlineData(new[] { 2, 2, 1, 1, 1, 2, 2 }, 2)]
    [InlineData(new[] { 2, 2 }, 2)]
    [InlineData(new[] { 3, 3, 4 }, 3)]
    public void Test(int[] nums, int expected)
    {
        var actual = SortedSimplified(nums);
        Assert.Equal(expected, actual);
    }
}