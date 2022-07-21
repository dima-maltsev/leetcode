using System;
using System.Collections.Generic;
using Xunit;

namespace LeetCode._2022
{
    // [Medium][String] https://leetcode.com/problems/longest-substring-without-repeating-characters/
    public class LongestSubstringWithoutRepeatingCharacters
    {
        int BruteForce(string s)
        {
            if (s.Length <= 1) return s.Length;
            
            var max = 1;
            
            for (var start = 0; start < s.Length - 1; start++)
            {
                var set = new HashSet<char> { s[start] };
                var end = start + 1;

                while (end < s.Length && set.Add(s[end]))
                    end++;

                max = Math.Max(max, end - start);
            }
            
            return max;
        }
        
        int Improved(string s)
        {
            if (s.Length <= 1) return s.Length;
            
            var max = 1;

            var set = new Dictionary<char, int>();
            
            for (var start = 0; start < s.Length - 1 && s.Length - start > max; start++)
            {
                set.Add(s[start], start);
                var end = start + 1;

                while (end < s.Length && set.TryAdd(s[end], end))
                    end++;
                
                max = Math.Max(max, end - start);
                
                if (end < s.Length)
                    start = set[s[end]];
                
                set.Clear();
            }
            
            return max;
        }

        int SlidingWindow(string s)
        {
            if (s.Length <= 1) return s.Length;
            
            var map = new Dictionary<char, int>();

            var max = 0;
            var start = 0;

            for (var end = 0; end < s.Length; end++)
            {
                if (map.ContainsKey(s[end]))
                {
                    start = Math.Max(start, map[s[end]] + 1);
                }
                
                map[s[end]] = end;
                
                max = Math.Max(max, end - start + 1);
            }
            
            return max;
        }
        
        int SlidingWindowArray(string s)
        {
            if (s.Length <= 1) return s.Length;
            
            var map = new int[256];

            var max = 0;
            var start = 0;

            for (var end = 0; end < s.Length; end++)
            {
                if (map[s[end]] > 0)
                {
                    start = Math.Max(start, map[s[end]]);
                }
                
                map[s[end]] = end + 1;
                
                max = Math.Max(max, end - start + 1);
            }
            
            return max;
        }


        [Theory]
        [InlineData("abcabcbb", 3)]
        [InlineData("bbbbb", 1)]
        [InlineData("pwwkew", 3)]
        [InlineData("a", 1)]
        [InlineData("", 0)]
        [InlineData("aa", 1)]
        [InlineData("ab", 2)]
        [InlineData("aab", 2)]
        [InlineData("dvdf", 3)]
        [InlineData("abba", 2)]
        public void Test(string input, int expected)
        {
            var actual = SlidingWindowArray(input);
            Assert.Equal(expected, actual);
        }
    }
}