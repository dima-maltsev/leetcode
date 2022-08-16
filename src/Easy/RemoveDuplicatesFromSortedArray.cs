using Xunit;

namespace LeetCode.Easy;

// [Array] https://leetcode.com/problems/remove-duplicates-from-sorted-array
public class RemoveDuplicatesFromSortedArray
{
    public int RemoveDuplicates(int[] nums) 
    {
        if (nums.Length == 1)
            return 1;
        
        var pos = 1;
        var prev = nums[0];
        
        for (var i = 1; i < nums.Length; i++)
        {
            var curr = nums[i];
            
            if (curr != prev)
            {
                if (pos != i)
                {
                    nums[pos] = nums[i];
                    nums[i] = int.MaxValue;
                }
                
                pos++;
            }
            
            prev = curr;
        }
        
        return pos;
    }

    public int ShorterCode(int[] nums) 
    {
        if (nums.Length == 1) return 1;
        
        var pos = 1;
        
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] != nums[i - 1])
            {
                nums[pos++] = nums[i];
            }
        }
        
        return pos;
    }

    [Theory]
    [InlineData(new[] { 1, 1, 2 }, new[] { 1, 2 })]
    [InlineData(new[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, new[] { 0, 1, 2, 3, 4 })]
    [InlineData(new[] { 1, 2 }, new[] { 1, 2 })]
    [InlineData(new[] { 1 }, new[] { 1 })]
    void Test(int[] nums, int[] expected)
    {
        var size = ShorterCode(nums);

        for (var i = 0; i < size; i++)
        {
            Assert.Equal(expected[i], nums[i]);
        }
    }
}