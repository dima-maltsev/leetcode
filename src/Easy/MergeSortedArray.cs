using Xunit;

namespace LeetCode.Easy;

// [Array] https://leetcode.com/problems/merge-sorted-array/
public class MergeSortedArray
{
    void Merge(int[] nums1, int m, int[] nums2, int n) 
    {
        var j = 0;
        
        for (var i = 0; i < n; i++)
        {
            while (nums1[j] <= nums2[i] && j < m + i)
                j++;
            
            for (var k = m + i; k > j; k--)
            {
                nums1[k] = nums1[k - 1];
            }
            
            nums1[j] = nums2[i];
        }
    }

    void SimplerSolution(int[] nums1, int m, int[] nums2, int n)
    {
        while (n > 0)
        {
            if (m <=0 || nums2[n - 1] >= nums1[m - 1])
            {
                nums1[m + n - 1] = nums2[n - 1];
                n--;
            }
            else
            {
                nums1[m + n - 1] = nums1[m - 1];
                m--;
            }
        }
    }
    
    [Theory]
    [InlineData(new[] { 1, 2, 3, 0, 0, 0 }, 3, new[] { 2, 5, 6 }, 3, new[] { 1, 2, 2, 3, 5, 6 })]
    [InlineData(new[] { 1 }, 1, new int[0], 0, new[] { 1 })]
    [InlineData(new[] { 0 }, 0, new[] { 1 }, 1, new[] { 1 })]
    void Test(int[] nums1, int m, int[] nums2, int n, int[] expected)
    {
        SimplerSolution(nums1, m, nums2, n);
        
        Assert.Equal(nums1, expected);
    }
}