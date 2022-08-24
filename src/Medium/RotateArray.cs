using Xunit;

namespace LeetCode.Medium;

// [Array] https://leetcode.com/problems/rotate-array/
public class RotateArray
{
    void InPlace(int[] nums, int k) 
    {
        var n = nums.Length;
        k %= n;
        
        if (k == 0 || n == 1)
            return;
        
        var index = 0;
        var memo = nums[0];
        var start = 0;

        for (var moves = 0; moves < n; moves++)
        {
            var next = (index + k) % n;
            
            (nums[next], memo) = (memo, nums[next]);

            index = next;

            if (index == start)
            {
                start++;
                index = start;
                memo = nums[index];
            }
        }
    }

    void Glue(int[] nums, int k)
    {
        var n = nums.Length;
        k %= n;
        
        if (k == 0 || n == 1)
            return;

        var tmp = nums[(n - k)..n];

        for (var i = n - k - 1; i >= 0; i--)
        {
            nums[i + k] = nums[i];
        }

        for (var j = 0; j < k; j++)
        {
            nums[j] = tmp[j];
        }
    }

    // https://leetcode.com/problems/rotate-array/discuss/54250/Easy-to-read-Java-solution
    void Reversal(int[] nums, int k)
    {
        var n = nums.Length;
        k %= n;
        
        if (k == 0 || n == 1)
            return;

        Reverse(nums, 0, n - 1);
        Reverse(nums, 0, k - 1);
        Reverse(nums, k, n - 1);
    }

    void Reverse(int[] nums, int start, int end)
    {
        while (start < end)
        {
            (nums[start], nums[end]) = (nums[end], nums[start]);
            
            start++;
            end--;
        }
    }

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new[] { 5, 6, 7, 1, 2, 3, 4 })]
    [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7 }, 1, new[] { 7, 1, 2, 3, 4, 5, 6 })]
    [InlineData(new[] { -1, -100, 3, 99 }, 2, new[] { 3, 99, -1, -100 })]
    [InlineData(new[] { 1, 2, 3, 4, 5, 6 }, 2, new[] { 5, 6, 1, 2, 3, 4 })]
    [InlineData(new[] { 1, 2, 3, 4, 5, 6 }, 3, new[] { 4, 5, 6, 1, 2, 3 })]
    public void Test(int[] nums, int k, int[] expected)
    {
        InPlace(nums, k);
        Assert.Equal(expected, nums);
    }
}