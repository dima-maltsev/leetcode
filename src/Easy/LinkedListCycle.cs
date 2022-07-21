using System.Collections.Generic;
using LeetCode.DataTypes;
using Xunit;

namespace LeetCode.Easy;

// [LinkedList] https://leetcode.com/problems/linked-list-cycle/
public class LinkedListCycle
{
    bool HasCycle(ListNode head)
    {
        if (head == null) return false;

        var set = new HashSet<ListNode> { head };

        while (head.next != null)
        {
            if (set.Contains(head.next))
                return true;
            set.Add(head.next);
            head = head.next;
        }

        return false;
    }

    // https://leetcode.com/problems/linked-list-cycle/discuss/44489/O(1)-Space-Solution
    bool HasCycleConstantSpace(ListNode head)
    {
        if (head == null) return false;

        var walker = head;
        var runner = head;

        while (runner.next != null && runner.next.next != null)
        {
            walker = walker.next;
            runner = runner.next.next;
            if (walker == runner) return true;
        }

        return false;
    }

    [Theory]
    [InlineData(new[] { 3, 2, 0, -4 }, 1, true)]
    [InlineData(new[] { 1, 2 }, 0, true)]
    [InlineData(new[] { 1 }, -1, false)]
    [InlineData(new[] { 1 }, 0, true)]
    [InlineData(new int[0], -1, false)]
    public void Test(int[] array, int pos, bool expected)
    {
        var list = ListNode.ArrayToLinkedList(array, pos);
        var actual = HasCycleConstantSpace(list);
        Assert.Equal(expected, actual);
    }
}