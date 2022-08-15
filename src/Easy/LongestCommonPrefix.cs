using System.Linq;
using System.Text;
using LeetCode.DataTypes;
using Xunit;

namespace LeetCode.Easy;

// [String] https://leetcode.com/problems/longest-common-prefix/
public class LongestCommonPrefix
{
    string VerticalScan(string[] strs)
    {
        if (strs.Length == 1)
            return strs[0];

        var builder = new StringBuilder();

        var template = strs[0];
        
        for (var i = 0; i < template.Length; i++)
        {
            for (var j = 1; j < strs.Length; j++)
            {
                if (i >= strs[j].Length || strs[j][i] != template[i])
                {
                    return builder.ToString();
                }
            }

            builder.Append(template[i]);
        }

        return builder.ToString();
    }

    string Improved(string[] strs)
    {
        if (strs.Length == 1)
            return strs[0];

        var prefix = strs[0];

        for (var i = 1; i < strs.Length; i++)
        {
            var builder = new StringBuilder();

            for (var j = 0; j < strs[i].Length; j++)
            {
                if (j >= prefix.Length || strs[i][j] != prefix[j])
                    break;
                
                builder.Append(prefix[j]);
            }

            prefix = builder.ToString();
            if (prefix.Length == 0) break;
        }

        return prefix;
    }

    string Sorted(string[] strs)
    {
        if (strs.Length == 1)
            return strs[0];

        var minStr = strs.Min();
        var maxStr = strs.Max();

        for (var i = 0; i < minStr.Length; i++)
        {
            if (minStr[i] != maxStr[i])
                return minStr.Substring(0, i);
        }

        return minStr;
    }

    string Trie(string[] strs)
    {
        if (strs.Length == 1)
            return strs[0];

        var trie = new Trie();

        for (var i = 1; i < strs.Length; i++)
        {
            trie.Insert(strs[i]);
        }

        return trie.SearchLongestPrefix(strs[0]);
    }

    [Theory]
    [InlineData(new[] { "flower", "flow", "flight" }, "fl")]
    [InlineData(new[] { "dog", "racecar", "car" }, "")]
    void Test(string[] strs, string expected)
    {
        var actual = Trie(strs);
        Assert.Equal(expected, actual);
    }
}