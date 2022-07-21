using System.Collections.Generic;
using Xunit;

namespace LeetCode._2022;

// [Easy][LinkedList] https://leetcode.com/problems/linked-list-cycle/
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
    [InlineData(new[] {3, 2, 0, -4}, 1, true)]
    [InlineData(new[] {1, 2}, 0, true)]
    [InlineData(new[] {1}, -1, false)]
    [InlineData(new[] {1}, 0, true)]
    [InlineData(new int[0], -1, false)]
    public void Test(int[] array, int pos, bool expected)
    {
        var list = ArrayToLinkedList(array, pos);
        var actual = HasCycleConstantSpace(list);
        Assert.Equal(expected, actual);
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