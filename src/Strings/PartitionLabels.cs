using Xunit;

namespace LeetCode
{
    // [Medium][String] https://leetcode.com/problems/partition-labels/
    // Notes:
    // - It's enough to just keep track of the last occurence rather than the whole interval,
    //      then we can use moving pointer to calculate the end position of the current interval.
    // - Use s[i] - 'a' to calculate char position in an array
    public class PartitionLabels
    {
        public IList<int> Partition(string s)
        {
            if (s.Length == 1) return new List<int> { 1 };

            var map = new Dictionary<char, int[]>();

            for (var i = 0; i < s.Length; i++)
            {
                var c = s[i];

                if (!map.ContainsKey(c))
                {
                    map.Add(c, new[] { i, -1 });
                }
                else
                {
                    map[c][1] = i;
                }
            }

            var result = new List<int>();
            var start = -1;

            for (var k = 0; k < s.Length; k++)
            {
                var intersect = map.Values.Any(p => p[0] <= k && p[1] > k);
                if (intersect) continue;

                result.Add(k - start);
                start = k;
            }

            return result;
        }

        IList<int> MovingPointer(string s)
        {
            if (s.Length == 1) return new List<int> { 1 };

            var last = new int[26];
            for (var i = 0; i < s.Length; i++)
                last[s[i] - 'a'] = i;

            var result = new List<int>();

            var start = 0;
            var end = 0;
            for (var i = 0; i < s.Length; i++)
            {
                end = Math.Max(end, last[s[i] - 'a']);
                if (end == i)
                {
                    result.Add(end - start + 1);
                    start = end + 1;
                    end = 0;
                }
            }

            return result;
        }

        [Theory]
        [InlineData("ababcbacadefegdehijhklij", new[] {9, 7, 8})]
        [InlineData("eccbbbbdec", new[] {10})]
        [InlineData("aaabbbbccc", new[] {3, 4, 3})]
        [InlineData("aaabbbbacc", new[] {8, 2})]
        public void Test(string input, int[] expected)
        {
            var actual = MovingPointer(input);
            Assert.Equal(expected, actual);
        }
    }
}