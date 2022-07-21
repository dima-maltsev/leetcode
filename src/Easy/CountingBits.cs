using Xunit;

namespace LeetCode.Easy;

// [Dynamic] https://leetcode.com/problems/counting-bits/
public class CountingBits
{
    // https://en.wikipedia.org/wiki/Hamming_weight
    int[] HammingWeight(int n)
    {
        var bits = new int[n + 1];

        for (var i = 0; i <= n; i++)
        {
            var count = 0;
            var value = i;

            while (value > 0)
            {
                value &= value - 1;
                count++;
            }

            bits[i] = count; // BitOperations.PopCount((uint) i);
        }

        return bits;
    }

    // https://leetcode.com/problems/counting-bits/discuss/656849/Python-Simple-Solution-with-Clear-Explanation
    // f[binary string without the last bit] + last bit is 1 or not
    int[] Dynamic(int n)
    {
        var bits = new int[n + 1];

        for (var i = 1; i <= n; i++)
            bits[i] = bits[i / 2] + i % 2; // bits[i] = bits[i >> 1] + (i % 1); 

        return bits;
    }

    [Theory]
    [InlineData(2, new[] { 0, 1, 1 })]
    [InlineData(5, new[] { 0, 1, 1, 2, 1, 2 })]
    public void Test(int n, int[] expected)
    {
        var actual = Dynamic(n);
        Assert.Equal(expected, actual);
    }
}