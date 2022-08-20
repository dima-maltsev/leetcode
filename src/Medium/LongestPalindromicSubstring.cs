using System;
using Xunit;

namespace LeetCode.Medium;

// [String] https://leetcode.com/problems/longest-palindromic-substring/
public class LongestPalindromicSubstring
{
    string Greedy(string s)
    {
        if (s.Length == 1)
            return s;

        var result = s[0].ToString();

        for (var start = 0; start < s.Length - 1; start++)
        {
            if (s.Length - start <= result.Length)
                return result;
            
            for (var end = s.Length - 1; end > start; end--)
            {
                if (IsPalindrome(s, start, end))
                {
                    if (end - start >= result.Length)
                    {
                        result = s.Substring(start, end - start + 1);
                    }
                    
                    break;
                }
            }
        }

        return result;
    }
    
    bool IsPalindrome(string s, int start, int end)
    {
        while (start < end)
        {
            if (s[start] != s[end])
                return false;
            
            start++;
            end--;
        }

        return true;
    }

    string Expand(string s)
    {
        if (s.Length == 1)
            return s;

        var start = 0;
        var end = 0;

        for (var i = 0; i < s.Length; i++)
        {
            var len1 = ExpandAroundCenter(s, i, i);
            var len2 = ExpandAroundCenter(s, i, i + 1);

            var len = Math.Max(len1, len2);
            if (len > end - start)
            {
                start = i - (len - 1) / 2;
                end = i + len / 2;
            }
        }

        return s.Substring(start, end - start + 1);
    }

    int ExpandAroundCenter(string s, int left, int right)
    {
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            left--;
            right++;
        }

        return right - left - 1;
    }

    // https://leetcode.com/problems/longest-palindromic-substring/discuss/2921/Share-my-Java-solution-using-dynamic-programming
    string DynamicProgramming(string s)
    {
        var n = s.Length;
        var result = "";
        
        var dp = new bool[n, n];

        for (var end = n - 1; end >= 0; end--)
        {
            for (var start = end; start < n; start++)
            {
                dp[end, start] = s[end] == s[start] && (start - end < 3 || dp[end + 1, start - 1]);

                if (dp[end, start] && start - end + 1 > result.Length)
                {
                    result = s.Substring(end, start - end + 1);
                }
            }
        }

        return result;
    }
    
    [Theory]
    [InlineData("abba", "abba")]
    [InlineData("abcd", "a")]
    [InlineData("a", "a")]
    [InlineData("bb", "bb")]
    [InlineData("abcba", "abcba")]
    [InlineData("ababad", "ababa")]
    public void Test(string s, string expected)
    {
        var actual = DynamicProgramming(s);
        Assert.Equal(expected, actual);
    }
}