using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeetCode.Medium;

// [Array] https://leetcode.com/problems/merge-intervals/
public class MergeIntervals
{
    int[][] Merge(int[][] intervals)
    {
        if (intervals.Length == 1)
            return intervals;
        
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        var result = new List<int[]>();
        
        var index = 1;
        var current = intervals[0];

        while (index < intervals.Length)
        {
            if (Overlap(current, intervals[index]))
            {
                current = Merge(current, intervals[index]);
            }
            else
            {
                result.Add(current);
                current = intervals[index];
            }

            index++;
        }
        
        result.Add(current);

        return result.ToArray();
    }

    bool Overlap(int[] a, int[] b)
    {
        return a[0] <= b[1] & b[0] <= a[1];
    }

    int[] Merge(int[] a, int[] b)
    {
        return new[] { Math.Min(a[0], b[0]), Math.Max(a[1], b[1]) };
    }

    int[][] Simplified(int[][] intervals)
    {
        if (intervals.Length == 1)
            return intervals;
        
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        var current = intervals[0];
        var result = new List<int[]> { current };

        foreach (var interval in intervals)
        {
            if (interval[0] <= current[1])
            {
                current[1] = Math.Max(interval[1], current[1]);
            }
            else
            {
                current = interval;
                result.Add(current);
            }
        }
        
        return result.ToArray();
    }

    [Theory]
    [InlineData(new[] { 1, 3, 2, 6, 8, 10, 15, 18 }, new[] { 1, 6, 8, 10, 15, 18 })]
    [InlineData(new[] { 1, 4, 4, 5 }, new[] { 1, 5 })]
    [InlineData(new[] { 1, 4, 2, 3 }, new[] { 1, 4 })]
    [InlineData(new[] { 2, 3, 4, 5, 6, 7, 8, 9, 1, 10 }, new[] { 1, 10 })]
    public void Test(int[] intervals, int[] expected)
    {
        var actual = Simplified(ToJagged(intervals));
        Assert.Equal(ToJagged(expected), actual);
    }

    int[][] ToJagged(int[] input, int chunkSize = 2)
    {
        return input.Chunk(chunkSize).ToArray();
    }
}