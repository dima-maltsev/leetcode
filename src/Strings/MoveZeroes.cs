using Xunit;

namespace LeetCode
{
    // [Easy][Array] https://leetcode.com/problems/move-zeroes/
    public class MoveZeroes
    {
        void Move(int[] nums)
        {
            var next = 0;
            
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0) continue;
                nums[next++] = nums[i];
            }

            for (var j = next; j < nums.Length; j++)
            {
                nums[j] = 0;
            }
        }

        void MoveImproved(int[] nums)
        {
            var next = 0;
            
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0) continue;
                
                nums[next] = nums[i];

                if (next != i)
                    nums[i] = 0;

                next++;
            }
        }

        [Theory]
        [InlineData(new[] { 0, 1, 0, 3, 12 }, new[] { 1, 3, 12, 0, 0 })]
        [InlineData(new[] { 1, 2, 0, 3, 4, 0, 7 }, new[] { 1, 2, 3, 4, 7, 0, 0 })]
        [InlineData(new[] { 0 }, new[] { 0 })]
        public void Test(int[] nums, int[] expected)
        {
            Move(nums);
            Assert.Equal(expected, nums);
        }
    }
}