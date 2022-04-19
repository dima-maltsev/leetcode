using System;
using Xunit;

namespace LeetCode
{
    // [Easy][Array] https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
    public class BestTimeToBuyAndSellStock
    {
        public int MaxProfit(int[] prices)
        {
            if (prices.Length == 0) return 0;

            var min = prices[0];
            var max = 0;

            for (var i = 1; i < prices.Length; i++)
            {
                max = Math.Max(max, prices[i] - min);
                min = Math.Min(min, prices[i]);
            }

            return max;
        }

        // https://leetcode.com/problems/best-time-to-buy-and-sell-stock/discuss/39038/Kadane's-Algorithm-Since-no-one-has-mentioned-about-this-so-far-%3A)-(In-case-if-interviewer-twists-the-input)
        int KadenesAlgorithm(int[] nums)
        {
            if (nums.Length == 1) return nums[0];

            var globalMax = 0;
            var localMax = 0;

            for (var i = 1; i < nums.Length; i++)
            {
                localMax = Math.Max(localMax + nums[i] - nums[i - 1], 0);
                globalMax = Math.Max(localMax, globalMax);
            }

            return globalMax;
        }

        [Theory]
        [InlineData(new[] { 3, 5, 2, 6, 1, 6 }, 5)]
        [InlineData(new[] { 7, 1, 5, 3, 6, 4 }, 5)]
        [InlineData(new[] { 7, 6, 4, 3, 1 }, 0)]
        [InlineData(new[] { 1, 2, 1, 2, 5 }, 4)]
        public void Test(int[] prices, int expected)
        {
            var actual = KadenesAlgorithm(prices);
            Assert.Equal(expected, actual);
        }
    }
}