using System;
using Xunit;

namespace LeetCode.Previous;

// https://leetcode.com/explore/interview/card/top-interview-questions-easy/127/strings/879/
public class ReverseString
{
    public void Solution(char[] s)
    {
        Swap(s);
    }

    private void ArrayReverse(char[] s)
    {
        Array.Reverse(s);
    }

    private void Swap(char[] s)
    {
        var start = 0;
        var end = s.Length - 1;

        while (start < end)
        {
            (s[start], s[end]) = (s[end], s[start]);
            start++;
            end--;
        }
    }

    [Theory]
    [InlineData(new[] { 'h', 'e', 'l', 'l', 'o' }, new[] { 'o', 'l', 'l', 'e', 'h' })]
    [InlineData(new[] { 'H', 'a', 'n', 'n', 'a', 'h' }, new[] { 'h', 'a', 'n', 'n', 'a', 'H' })]
    public void Test(char[] s, char[] expected)
    {
        Solution(s);
        Assert.Equal(expected, s);
    }
}