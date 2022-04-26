using System.Collections.Generic;
using Xunit;

namespace LeetCode;

// [Medium][String] https://leetcode.com/problems/decode-string/
public class DecodeString
{
    string Decode(string s)
    {
        var stack = new Stack<string>();

        var i = 0;
        
        while (i < s.Length)
        {
            if (char.IsDigit(s[i]))
            {
                var number = "";
                while (char.IsDigit(s[i]))
                    number += s[i++];
                
                stack.Push(number);
            }
            else if (s[i] == '[')
            {
                stack.Push("[");
                i++;
            }
            else if (s[i] == ']')
            {
                var subStr = stack.Pop();
                while (stack.Peek() != "[")
                    subStr = stack.Pop() + subStr;
                
                stack.Pop();
                var number = int.Parse(stack.Pop());

                var line = subStr;
                for (var k = 0; k < number - 1; k++)
                    line += subStr;
                
                stack.Push(line);

                i++;
            }
            else
            {
                var encoded = "";
                while (i < s.Length && char.IsLetter(s[i]))
                    encoded += s[i++];
                
                stack.Push(encoded);
            }
        }

        var result = "";

        while (stack.Count != 0)
            result = stack.Pop() + result;

        return result;
    }
    
    [Theory]
    [InlineData("3[a]2[bc]", "aaabcbc")]
    [InlineData("3[a2[c]]", "accaccacc")]
    [InlineData("2[abc]3[cd]ef", "abcabccdcdcdef")]
    public void Test(string input, string expected)
    {
        var actual = Decode(input);
        Assert.Equal(expected, actual);
    }
}