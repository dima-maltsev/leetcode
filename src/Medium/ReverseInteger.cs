using Xunit;

namespace LeetCode.Medium;

// [Math] https://leetcode.com/problems/reverse-integer/
public class ReverseInteger
{
    int Reverse(int x) 
    {
        var sign = x < 0 ? -1 : 1;
        x *= sign;
                
        var reversed = 0;
        
        while (x > 0)
        {
            var remainder = x % 10;
            
            if (reversed > (int.MaxValue - remainder) / 10)
                return 0;
            
            reversed = (reversed * 10) + remainder;
            x /= 10;
        }
        
        return reversed * sign;
    }
    
    [Theory]
    [InlineData(123, 321)]
    [InlineData(-123, -321)]
    [InlineData(120, 21)]
    [InlineData(5, 5)]
    [InlineData(-8, -8)]
    [InlineData(0, 0)]
    [InlineData(10, 1)]
    [InlineData(-100, -1)]
    [InlineData(int.MaxValue, 0)]
    [InlineData(int.MinValue, 0)]
    public void Test(int input, int expected)
    {
        var actual = Reverse(input);
        Assert.Equal(expected, actual);
    }
}