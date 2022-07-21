using System.Collections.Generic;
using Xunit;

namespace LeetCode._2022
{
    // [Medium][Array] https://leetcode.com/problems/daily-temperatures
    public class DailyTemperatures
    {
        int[] BruteForce(int[] temperatures)
        {
            var result = new int[temperatures.Length];
        
            if (temperatures.Length == 1) return result;
        
            for (var i = 0; i < temperatures.Length - 1; i++)
            {
                for (var j = i + 1; j < temperatures.Length; j++)
                {
                    if (temperatures[j] > temperatures[i])
                    {
                        result[i] = j - i;
                        break;
                    }
                }
            }
        
            return result;
        }

        int[] MonotonicStack(int[] temperatures)
        {
            var result = new int[temperatures.Length];
        
            if (temperatures.Length == 1) return result;

            var stack = new Stack<int>();
        
            for (var i = 0; i < temperatures.Length; i++)
            {   
                while (stack.Count > 0 && temperatures[stack.Peek()] < temperatures[i])
                {
                    var index = stack.Pop();
                    result[index] = i - index;
                }                
            
                stack.Push(i);            
            }
        
            return result;
        }

        int[] ArrayBackwards(int[] temperatures)
        {
            var result = new int[temperatures.Length];
        
            if (temperatures.Length == 1) return result;

            var max = 0;
            
            for (var i = temperatures.Length - 1; i >= 0; i--)
            {
                if (temperatures[i] >= max)
                {
                    max = temperatures[i];
                    continue;
                }

                var days = 1;
                while (temperatures[i + days] <= temperatures[i])
                {
                    days += result[i + days];
                }

                result[i] = days;
            }

            return result;
        }

        [Theory]
        [InlineData(new[] {73, 74, 75, 71, 69, 72, 76, 73}, new[] {1, 1, 4, 2, 1, 1, 0, 0})]
        [InlineData(new[] {30, 40, 50, 60}, new[] {1, 1, 1, 0})]
        [InlineData(new[] {30, 60, 90}, new[] {1, 1, 0})]
        [InlineData(new[] {30}, new[] {0})]
        public void Test(int[] input, int[] expected)
        {
            var actual = ArrayBackwards(input);
            Assert.Equal(expected, actual);
        }
    }
}