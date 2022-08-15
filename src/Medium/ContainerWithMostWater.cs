using System;
using Xunit;

namespace LeetCode.Medium;

// [Array] https://leetcode.com/problems/container-with-most-water/
public class ContainerWithMostWater
{
    // https://leetcode.com/problems/container-with-most-water/discuss/6100/Simple-and-clear-proofexplanation
    int TwoPointer(int[] height)
    {
        var left = 0;
        var right = height.Length - 1;
        var maxArea = 0;

        while (left < right)
        {
            maxArea = Math.Max(maxArea, (right - left) * Math.Min(height[left], height[right]));

            if (height[left] < height[right])
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return maxArea;
    }
    
    int Greedy(int[] height)
    {
        var maxArea = 0;
        var maxHeight = 0;
        
        for (var i = 0; i < height.Length - 1; i++)
        {
            while (height[i] <= maxHeight && i < height.Length - 1)
            {
                i++;
            }

            maxHeight = height[i];
            
            for (var j = i + 1; j < height.Length; j++)
            {
                var area = (j - i) * Math.Min(height[i], height[j]);
                maxArea = Math.Max(area, maxArea);
            }
        }

        return maxArea;
    }

    [Theory]
    [InlineData(new[] { 1, 3, 2, 5, 25, 24, 5 }, 24)]
    [InlineData(new[] { 3, 9, 3, 4, 7, 2, 12, 6 }, 45)]
    [InlineData(new[] { 2, 3, 4, 5, 18, 17, 6 }, 17)]
    [InlineData(new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
    [InlineData(new[] { 1, 1 }, 1)]
    public void Test(int[] input, int expected)
    {
        var actual = TwoPointer(input);
        Assert.Equal(expected, actual);
    }
}