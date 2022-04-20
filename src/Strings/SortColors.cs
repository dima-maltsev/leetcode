using Xunit;

namespace LeetCode
{
    // [Medium][Sorting] https://leetcode.com/problems/sort-colors/
    public class SortColors
    {
        void CountingSort(int[] nums)
        {
            var map = new int[3];

            foreach (var num in nums)
                map[num]++;

            var index = 0;
            
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < map[i]; j++)
                {
                    nums[index] = i;
                    index++;
                }
            }
        }

        // https://en.wikipedia.org/wiki/Dutch_national_flag_problem
        void DutchFlagSorting(int[] nums)
        {
            const int mid = 1;
            
            var i = 0;
            var j = 0;
            var k = nums.Length - 1;

            while (j <= k)
            {
                switch (nums[j])
                {
                    case < mid:
                        (nums[i], nums[j]) = (nums[j], nums[i]);
                        i++;
                        j++;
                        break;
                    case > mid:
                        (nums[j], nums[k]) = (nums[k], nums[j]);
                        k--;
                        break;
                    default:
                        j++;
                        break;
                }
            }
        }

        [Theory]
        [InlineData(new[] {2, 0, 2, 1, 1, 0}, new[] {0, 0, 1, 1, 2, 2})]
        [InlineData(new[] {2, 0, 1}, new[] {0, 1, 2})]
        public void Test(int[] nums, int[] expected)
        {
            DutchFlagSorting(nums);
            Assert.Equal(expected, nums);
        }
    }
}