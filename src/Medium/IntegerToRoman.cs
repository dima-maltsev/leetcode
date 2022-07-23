using Xunit;

namespace LeetCode.Medium;

// https://leetcode.com/problems/integer-to-roman/
public class IntegerToRoman
{
    // Time complexity: O(1)
    // Space complexity: O(1)
    string IntToRoman(int num)
    {
        var ones = new[] { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
        var tens = new[] { "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC"};
        var hundreds = new[] { "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM"};
        var thousands = new[] { "M", "MM", "MMM"};
        
        var maps = new[] { ones, tens, hundreds, thousands };

        var result = "";
        var i = 0;

        while (num > 0)
        {
            var cur = num % 10;

            if (cur > 0)
            {
                result = maps[i][cur - 1] + result;
            }
            
            num /= 10;
            i++;
        }

        return result;
    }

    // Time complexity: O(1)
    // Space complexity: O(1)
    string OneLiner(int num)
    {
        var ones = new[] { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
        var tens = new[] { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC"};
        var hundreds = new[] { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM"};
        var thousands = new[] { "", "M", "MM", "MMM"};

        return thousands[num / 1000] + hundreds[num % 1000 / 100] + tens[num % 100 / 10] + ones[num % 10];
    }

    [Theory]
    [InlineData(1, "I")]
    [InlineData(3, "III")]
    [InlineData(58, "LVIII")]
    [InlineData(40, "XL")]
    [InlineData(21, "XXI")]
    [InlineData(1994, "MCMXCIV")]
    void Test(int num, string expected)
    {
        var actual = OneLiner(num);
        Assert.Equal(expected, actual);
    }
}