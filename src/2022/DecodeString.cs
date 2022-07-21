using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LeetCode._2022;

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

    string DecodeFaster(string s)
    {
        var stack = new Stack<string>();
        var currStr = "";
        var currNum = "";
        
        foreach (var c in s)
        {
            switch (c)
            {
                case '[':
                    stack.Push(currStr);
                    stack.Push(currNum);
                    currStr = "";
                    currNum = "";
                    break;
                case ']':
                {
                    var prevNum = int.Parse(stack.Pop());
                    var prevStr = stack.Pop();
                    currStr = prevStr + string.Concat(Enumerable.Repeat(currStr, prevNum));
                    break;
                }
                default:
                {
                    if (char.IsDigit(c))
                    {
                        currNum += c;
                    }
                    else
                    {
                        currStr += c;
                    }

                    break;
                }
            }
        }

        return currStr;
    }

    string DecodeRecursive(string s)
    {
        var i = 0;
        return SubDecode(s, ref i);
    }

    string SubDecode(string s, ref int i)
    {
        var builder = new StringBuilder();

        while (i < s.Length && s[i] != ']')
        {
            if (char.IsDigit(s[i]))
            {
                var num = 0;
                while (i < s.Length && char.IsDigit(s[i]))
                    num = num * 10 + (s[i++] - '0');

                i++; // '['
                var innerStr = SubDecode(s, ref i);
                i++; // ']'

                while (num-- > 0)
                    builder.Append(innerStr);
            }
            else
            {
                builder.Append(s[i++]);
            }
        }

        return builder.ToString();
    }
    
    [Theory]
    [InlineData("3[a]2[bc]", "aaabcbc")]
    [InlineData("3[a2[c]]", "accaccacc")]
    [InlineData("2[abc]3[cd]ef", "abcabccdcdcdef")]
    public void Test(string input, string expected)
    {
        var actual = DecodeFaster(input);
        Assert.Equal(expected, actual);
    }
}