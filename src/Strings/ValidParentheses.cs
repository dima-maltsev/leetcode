using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeetCode
{
    // [Easy][String] https://leetcode.com/problems/valid-parentheses/
    // Notes:
    // - Think about edge cases in inputs
    // - Refactor solution after implementation to clean up code
    // - Use more tests
    public class ValidParentheses
    {
        public bool IsValid(string s)
        {
            var openBrackets = new[] { '(', '{', '[' };

            if ((s.Length & 1) == 1) return false;

            var brackets = new Dictionary<char, char>
            {
                { ')', '(' },
                { '}', '{'},
                { ']', '[' }
            };

            var stack = new Stack<char>();

            foreach (var c in s)
            {
                if (openBrackets.Contains(c))
                    stack.Push(c);
                else if (stack.Count == 0 || stack.Pop() != brackets[c])
                    return false;
            }

            return stack.Count == 0;
        }

        bool Beautiful(string s)
        {
            var stack = new Stack<char>();

            foreach (var c in s)
            {
                if (c == '(')
                    stack.Push(')');
                else if (c == '{')
                    stack.Push('}');
                else if (c == '[')
                    stack.Push(']');
                else if (stack.Count == 0 || stack.Pop() != c)
                    return false;

            }

            return stack.Count == 0;
        }

        [Theory]
        [InlineData("()", true)]
        [InlineData("()[]{}", true)]
        [InlineData("(]", false)]
        [InlineData("(((({{}}))))[[((({})))]]", true)]
        [InlineData("[", false)]
        [InlineData(")(", false)]
        [InlineData("((", false)]
        [InlineData("(){}}{", false)]
        public void Test(string input, bool expected)
        {
            var actual = IsValid(input);
            Assert.Equal(expected, actual);
        }
    }
}