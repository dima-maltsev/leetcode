using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeetCode._2021
{
    // https://leetcode.com/explore/interview/card/top-interview-questions-easy/127/strings/881/
    public class FirstUniqueCharacter
    {
        public int FirstUniqChar(string s) => HashMapWithFixedArray(s);

        int HashMap(string s)
        {
            if (string.IsNullOrEmpty(s)) return -1;
            if (s.Length == 1) return 0;

            var map = new Dictionary<char, int>();

            foreach (var c in s)
            {
                if (map.ContainsKey(c))
                {
                    map[c]++;
                }
                else
                {
                    map[c] = 1;
                }
            }

            for (var i = 0; i < s.Length; i++)
            {
                if (map[s[i]] == 1)
                    return i;
            }

            return -1;
        }

        int GroupBy(string s)
        {
            if (string.IsNullOrEmpty(s)) return -1;
            if (s.Length == 1) return 0;

            var result = s
                .Select((c, index) => new { Char = c, Index = index })
                .GroupBy(p => p.Char)
                .FirstOrDefault(g => g.Count() == 1);

            return result == null ? -1 : result.First().Index;
        }

        int HashMapWithFixedArray(string s)
        {
            if (string.IsNullOrEmpty(s)) return -1;
            if (s.Length == 1) return 0;

            var map = new int[26];

            foreach (var c in s)
            {
                map[c - 'a']++;
            }

            for (var i = 0; i < s.Length; i++)
            {
                if (map[s[i] - 'a'] == 1)
                    return i;
            }

            return -1;
        }

        [Theory]
        [InlineData("leetcode", 0)]
        [InlineData("loveleetcode", 2)]
        [InlineData("aabb", -1)]
        [InlineData("aadadaad", -1)]
        public void Test(string s, int expected)
        {
            var actual = FirstUniqChar(s);
            Assert.Equal(expected, actual);
        }
    }
}