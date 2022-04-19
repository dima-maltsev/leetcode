using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeetCode
{
    // [Medium][String] https://leetcode.com/problems/group-anagrams/
    public class GroupAnagrams
    {
        IList<IList<string>> Group(string[] strs)
        {
            if (strs.Length == 1) return new List<IList<string>> { strs };

            var groups = new List<IList<string>>();
            
            foreach (var current in strs)
            {
                var group = groups.FirstOrDefault(g => AreAnagrams(g[0], current));
                if (group == null)
                {
                    group = new List<string>();
                    groups.Add(group);
                }
                
                group.Add(current);
            }

            return groups;
        }

        bool AreAnagrams(string left, string right)
        {
            var map = new char[26];
            
            foreach (var c in left)
                map[c - 'a']++;

            foreach (var c in right)
                map[c - 'a']--;

            return map.All(x => x == 0);
        }

        IList<IList<string>> DictionaryGroup(string[] strs)
        {
            if (strs.Length == 1) return new List<IList<string>> { strs };

            var map = new Dictionary<string, IList<string>>();
            
            foreach (var str in strs)
            {
                var key = WordToKey(str);

                if (map.TryGetValue(key, out var list))
                {
                    list.Add(str);
                }
                else
                {
                    map[key] = new List<string> {str};
                }
            }

            return map.Values.ToList();
        }

        string WordToKey(string word)
        {
            var key = new char[26];
            foreach (var c in word)
                key[c - 'a']++;
            return new string(key);
        }

        [Theory]
        [InlineData(new[] {"eat", "tea", "tan", "ate", "nat", "bat"}, new[] {"bat"}, new[] {"nat", "tan"}, new[] {"ate", "eat", "tea"})]
        [InlineData(new[] { "" }, new[] { "" })]    
        [InlineData(new[] { "a" }, new[] { "a" })]
        public void Test(string[] inputs, params string[][] expected)
        {
            var actual = DictionaryGroup(inputs).Select(x => x.ToArray()).ToArray();
            Assert.Equal(expected, actual);
        }
    }
}