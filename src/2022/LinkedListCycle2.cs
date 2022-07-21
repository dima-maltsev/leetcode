using System.Collections.Generic;
using Xunit;

namespace LeetCode._2022;

// [Medium][LinkedList] https://leetcode.com/problems/linked-list-cycle-ii/
public class LinkedListCycle2
{
    int DetectCycle(ListNode head)
    {
        if (head == null) return -1;

        var index = 0;
        var set = new Dictionary<ListNode, int> { { head, index } };

        while (head.next != null)
        {
            if (set.ContainsKey(head.next))
                return set[head.next];
            set.Add(head.next, ++index);
            head = head.next;
        }

        return -1;
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
    [InlineData(new[] {3, 2, 0, -4}, 1)]
    [InlineData(new[] {1, 2}, 0)]
    [InlineData(new[] {1}, -1)]
    [InlineData(new[] {1}, 0)]
    [InlineData(new int[0], -1)]
    public void Test(int[] array, int pos)
    {
        var list = ArrayToLinkedList(array, pos);
        var actual = DetectCycle(list);
        Assert.Equal(pos, actual);
    }

    class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
        
    ListNode ArrayToLinkedList(int[] input, int pos)
    {
        if (input == null || input.Length == 0) return null;

        var head = new ListNode(input[0]);
        
        ListNode tail = null;
        if (pos == 0) tail = head;

        var curr = head;
        for (var i = 1; i < input.Length; i++)
        {
            curr.next = new ListNode(input[i]);
            curr = curr.next;
            if (i == pos) tail = curr;
        }

        curr.next = tail;

        return head;
    }
}