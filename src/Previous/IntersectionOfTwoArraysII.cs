using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeetCode.Previous;

//https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/674/
public class IntersectionOfTwoArraysII
{
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        return Counts(nums1, nums2);
    }

    private int[] Linq(int[] nums1, int[] nums2)
    {
        var list = new List<int>(nums2);
        return nums1.Where(i => list.Remove(i)).ToArray();
    }

    private int[] BruteForce(int[] nums1, int[] nums2)
    {
        var result = new List<int>();
        var indices = new HashSet<int>();

        foreach (var nums1Val in nums1)
            for (var j = 0; j < nums2.Length; j++)
            {
                if (nums1Val != nums2[j] || indices.Contains(j)) continue;

                result.Add(nums2[j]);
                indices.Add(j);
                break;
            }

        return result.ToArray();
    }

    private int[] Sort(int[] nums1, int[] nums2)
    {
        var result = new List<int>();

        Array.Sort(nums1);
        Array.Sort(nums2);

        var i = 0;
        var j = 0;

        while (i < nums1.Length && j < nums2.Length)
            if (nums1[i] < nums2[j])
            {
                i++;
            }
            else if (nums1[i] > nums2[j])
            {
                j++;
            }
            else
            {
                result.Add(nums1[i]);
                i++;
                j++;
            }

        return result.ToArray();
    }

    private int[] Counts(int[] nums1, int[] nums2)
    {
        var result = new List<int>();
        var counts = new Dictionary<int, int>();

        foreach (var val in nums1)
            if (counts.ContainsKey(val))
                counts[val]++;
            else
                counts.Add(val, 1);

        foreach (var val in nums2)
            if (counts.ContainsKey(val) && counts[val] > 0)
            {
                result.Add(val);
                counts[val]--;
            }

        return result.ToArray();
    }

    [Theory]
    [InlineData(new[] { 1, 2, 2, 1 }, new[] { 2 }, new[] { 2 })]
    [InlineData(new[] { 1, 2, 2, 1 }, new[] { 2, 2 }, new[] { 2, 2 })]
    [InlineData(new[] { 4, 9, 5 }, new[] { 9, 4, 9, 8, 4 }, new[] { 4, 9 })]
    public void Test(int[] nums1, int[] nums2, int[] expected)
    {
        var actual = Intersect(nums1, nums2);
        Array.Sort(actual);
        Assert.Equal(expected, actual);
    }
}