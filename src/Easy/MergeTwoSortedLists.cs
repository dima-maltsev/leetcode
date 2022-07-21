using LeetCode.DataTypes;
using Xunit;

namespace LeetCode.Easy;

// [LinkedList] https://leetcode.com/problems/merge-two-sorted-lists/
public class MergeTwoSortedLists
{
    ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if (list1 == null) return list2;
        if (list2 == null) return list1;

        var head = list2;

        ListNode prev = null;

        while (list1 != null)
        {
            while (list2 != null && list2.val <= list1.val)
            {
                prev = list2;
                list2 = list2.next;
            }

            if (prev == null)
            {
                prev = list1;
                list1 = list1.next;
                prev.next = list2;
                head = prev;
            }
            else
            {
                prev.next = list1;
                prev = prev.next;
                list1 = list1.next;
                prev.next = list2;
            }
        }

        return head;
    }

    ListNode RecursiveMerge(ListNode list1, ListNode list2)
    {
        if (list1 == null) return list2;
        if (list2 == null) return list1;

        if (list1.val <= list2.val)
        {
            list1.next = RecursiveMerge(list1.next, list2);
            return list1;
        }

        list2.next = RecursiveMerge(list1, list2.next);
        return list2;
    }

    ListNode IterativeMerge(ListNode list1, ListNode list2)
    {
        if (list1 == null) return list2;
        if (list2 == null) return list1;

        var head = new ListNode();
        var curr = head;

        while (list1 != null && list2 != null)
        {
            if (list1.val < list2.val)
            {
                curr.next = list1;
                list1 = list1.next;
            }
            else
            {
                curr.next = list2;
                list2 = list2.next;
            }

            curr = curr.next;
        }

        curr.next = list1 ?? list2;

        return head.next;
    }

    [Theory]
    [InlineData(new[] { 1, 2, 4 }, new[] { 1, 3, 4 }, new[] { 1, 1, 2, 3, 4, 4 })]
    [InlineData(new[] { 1, 2, 4 }, new[] { 0, 0, 1, 3, 4 }, new[] { 0, 0, 1, 1, 2, 3, 4, 4 })]
    [InlineData(new[] { 0, 0, 1, 3, 4 }, new[] { 1, 2, 4 }, new[] { 0, 0, 1, 1, 2, 3, 4, 4 })]
    [InlineData(new[] { 2, 2 }, new[] { 2, 2 }, new[] { 2, 2, 2, 2 })]
    [InlineData(new int[0], new int[0], new int[0])]
    [InlineData(new int[0], new[] { 0 }, new[] { 0 })]
    public void Test(int[] array1, int[] array2, int[] expected)
    {
        var list1 = ListNode.ArrayToLinkedList(array1);
        var list2 = ListNode.ArrayToLinkedList(array2);

        var result = IterativeMerge(list1, list2);

        var actual = ListNode.LinkedListToArray(result);
        Assert.Equal(expected, actual);
    }
}