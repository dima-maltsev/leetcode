using Xunit;

namespace LeetCode.Easy;

// [Array] https://leetcode.com/problems/plus-one/
public class PlusOne
{
    int[] Solution(int[] digits) 
    {
        var index = digits.Length - 1;
        
        while (index >= 0)
        {
            if (digits[index] < 9)
            {
                digits[index]++;
                return digits;
            }

            digits[index] = 0;
            index--;
        }
        
        var result = new int[digits.Length + 1];
        result[0] = 1;
        
        return result;
    }
    [Theory]
    [InlineData(new[] { 1, 2, 3 }, new[] { 1, 2, 4 })]
    [InlineData(new[] { 4, 3, 2, 1 }, new[] { 4, 3, 2, 2 })]
    [InlineData(new[] { 9 }, new[] { 1, 0 })]
    [InlineData(new[] { 1, 4, 9 }, new[] { 1, 5, 0 })]
    [InlineData(new[] { 9, 9, 9 }, new[] { 1, 0, 0, 0 })]
    public void Test(int[] digits, int[] expected)
    {
        var actual = Solution(digits);
        Assert.Equal(expected, actual);
    }
}