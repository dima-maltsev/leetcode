using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeetCode
{
    //https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/674/
    public class IntersectionOfTwoArraysII
    {
        public int[] Intersect(int[] nums1, int[] nums2) => Sort(nums1, nums2);

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

        int[] Sort(int[] nums1, int[] nums2)
        {
            var map = new Dictionary<int, int>();

            var arr1 = nums1;
            var arr2 = nums2;

            if (nums2.Length < nums1.Length)
            {
                arr1 = nums2;
                arr2 = nums1;
            }

            Array.Sort(arr2);

            for (var i = 0; i < arr1.Length; i++)
            {
                var index = Array.BinarySearch(arr2, arr1[i]);
                if (index >= 0)
                {
                    map.Add(arr1[i], i);
                }
            }

            return map.Keys.ToArray();
        }

        [Theory]
        [InlineData(new[] { 1, 2, 2, 1 }, new[] { 2, 2 }, new[] { 2, 2 })]
        [InlineData(new[] { 4, 9, 5 }, new[] { 9, 4, 9, 8, 4 }, new[] { 4, 9 })]
        public void Test(int[] nums1, int[] nums2, int[] expected)
        {
            var actual = Intersect(nums1, nums2);
            Assert.Equal(expected, actual);
        }
    }
}