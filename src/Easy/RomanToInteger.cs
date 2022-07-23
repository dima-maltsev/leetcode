using System.Collections.Generic;
using Xunit;

namespace LeetCode.Easy;

// https://leetcode.com/problems/roman-to-integer/
public class RomanToInteger
{
    // Time complexity: O(n)
    // Space complexity: O(1)
    int Solution(string s)
    {
        var numerals = new Dictionary<string, int>
        {
            { "I", 1 },
            { "V", 5 },
            { "X", 10 },
            { "L", 50 },
            { "C", 100 },
            { "D", 500 },
            { "M", 1000 }
        };

        var substracts = new Dictionary<string, int>
        {
            { "IV", 4 },
            { "IX", 9 },
            { "XL", 40 },
            { "XC", 90 },
            { "CD", 400 },
            { "CM", 900 }
        };

        var result = 0;

        var prevSymbol = s[^1].ToString();
        var prevNumber = numerals[prevSymbol];
        result += prevNumber;

        for (var i = s.Length - 2; i >= 0; i--)
        {
            var curSymbol = s[i].ToString();
            var curNumber = numerals[curSymbol];

            if (curNumber < prevNumber)
            {
                var substract = curSymbol + prevSymbol;
                curNumber = substracts[substract] - prevNumber;
            }

            result += curNumber;

            prevSymbol = curSymbol;
            prevNumber = curNumber;
        }
        
        return result;
    }

    // Time complexity: O(n)
    // Space complexity: O(1)
    int SimplerSolution(string s)
    {
        var map = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        var sum = 0;
        var prev = 0;

        for (var i = s.Length - 1; i >= 0; i--)
        {
            var cur = map[s[i]];
            
            if (cur >= prev)
            {
                sum += cur;
            }
            else
            {
                sum -= cur;
            }

            prev = cur;
        }
        
        return sum;
    }

    [Theory]
    [InlineData("I", 1)]
    [InlineData("III", 3)]
    [InlineData("LVIII", 58)]
    [InlineData("XL", 40)]
    [InlineData("XXI", 21)]
    [InlineData("MCMXCIV", 1994)]
    void Test(string s, int expected)
    {
        var actual = SimplerSolution(s);
        Assert.Equal(expected, actual);
    }
}