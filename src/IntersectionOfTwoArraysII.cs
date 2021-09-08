using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeetCode
{
    //https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/674/
    public class IntersectionOfTwoArraysII
    {
        public int[] Intersect(int[] nums1, int[] nums2) => Linq(nums1, nums2);

        int[] Linq(int[] nums1, int[] nums2)
        {
            return IntersectIterator(nums1, nums2).ToArray();
        }

        IEnumerable<int> IntersectIterator(int[] nums1, int[] nums2)
        {
            var list = new List<int>(nums2);
            foreach (var i in nums1)
            {
                if (list.Remove(i))
                    yield return i;
            }
        }

        [Theory]
        [InlineData(new[] { 1, 2, 2, 1 }, new[] { 2, 2 }, new[] { 2, 2 })]
        public void Test(int[] nums1, int[] nums2, int[] expected)
        {
            var actual = Intersect(nums1, nums2);
            Assert.Equal(expected, actual);
        }
    }
}