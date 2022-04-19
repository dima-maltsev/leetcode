using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeetCode
{
    // [Medium][String] https://leetcode.com/problems/find-all-anagrams-in-a-string/
    public class FindAllAnagramsInASring
    {
        public IList<int> FindAnagrams(string s, string p)
        {
            if (p.Length > s.Length) return new List<int>();
            if (p == s) return new List<int> { 0 };

            var result = new List<int>();

            var template = new int[26];
            foreach (var c in p)
                template[c - 'a']++;

            var current = new int[26];
            for (var i = 0; i < p.Length; i++)
                current[s[i] - 'a']++;

            if (current.SequenceEqual(template))
                result.Add(0);

            for (int start = 0, end = p.Length; start < s.Length - p.Length; start++, end++)
            {
                current[s[start] - 'a']--;
                current[s[end] - 'a']++;

                if (current.SequenceEqual(template))
                    result.Add(start + 1);
            }

            return result;
        }

        public IList<int> OneHashmap(string s, string p)
        {
            if (p.Length > s.Length) return new List<int>();
            if (p == s) return new List<int> { 0 };

            var result = new List<int>();

            var map = new int[26];
            foreach (var c in p)
                map[c - 'a']++;

            for (var i = 0; i < p.Length; i++)
                map[s[i] - 'a']--;

            if (map.All(x => x == 0))
                result.Add(0);

            for (int start = 0, end = p.Length; start < s.Length - p.Length; start++, end++)
            {
                map[s[start] - 'a']--;
                map[s[end] - 'a']++;

                if (map.All(x => x == 0))
                    result.Add(start + 1);
            }

            return result;
        }

        [Theory]
        [InlineData("cbaebabacd", "abc", new[] {0, 6})]
        [InlineData("abab", "ab", new[] {0, 1, 2})]
        [InlineData("af", "be", new int[] {})]
        public void Test(string s, string p, int[] expected)
        {
            var actual = OneHashmap(s, p);
            Assert.Equal(expected, actual);
        }
    }
}