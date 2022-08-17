using Xunit;

namespace LeetCode.Easy;

// [String] https://leetcode.com/problems/reverse-string
public class ReverseString
{
    void Reverse(char[] s) 
    {
        if (s.Length == 1)
            return;
        
        for (var i = 0; i < s.Length / 2; i++)
        {
            (s[i], s[s.Length - 1 - i]) = (s[s.Length - 1 - i], s[i]);
        }
    }
    
    [Theory]
    [InlineData(new[] { 'h', 'e', 'l', 'l', 'o' }, new[] { 'o', 'l', 'l', 'e', 'h' })]
    void Test(char[] s, char[] expected)
    {
        Reverse(s);
        
        Assert.Equal(expected, s);
    }
}