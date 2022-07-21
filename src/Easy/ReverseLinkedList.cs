using LeetCode.DataTypes;
using Xunit;

namespace LeetCode.Easy;

// [LinkedList] https://leetcode.com/problems/reverse-linked-list/
public class ReverseLinkedList
{
    ListNode ReverseList(ListNode head)
    {
        if (head?.next == null) return head;

        ListNode prev = null;

        ListNode next;
        while ((next = head.next) != null)
        {
            head.next = prev;
            prev = head;
            head = next;
        }

        head.next = prev;

        return head;
    }

    // 1 -> 2 -> 3
    // null <- 1    2 -> 3
    // null <- 1 <- 2    3
    // null <- 1 <- 2 <- 3
    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 5, 4, 3, 2, 1 })]
    [InlineData(new[] { 1, 2 }, new[] { 2, 1 })]
    [InlineData(new[] { 1 }, new[] { 1 })]
    [InlineData(new int[0], new int[0])]
    public void Test(int[] input, int[] expected)
    {
        var inputList = ListNode.ArrayToLinkedList(input);
        var reversedList = ReverseList(inputList);
        var actual = ListNode.LinkedListToArray(reversedList);
        Assert.Equal(expected, actual);
    }
}
