using System;
using System.Collections.Generic;

namespace LeetCode.DataTypes;

public class ListNode
{
    public readonly int val;
    public ListNode next;

    public ListNode(int x = 0)
    {
        val = x;
    }
    
    public static ListNode ArrayToLinkedList(int[] input)
    {
        if (input == null || input.Length == 0) return null;

        var head = new ListNode(input[0]);

        var curr = head;
        for (var i = 1; i < input.Length; i++)
        {
            curr.next = new ListNode(input[i]);
            curr = curr.next;
        }

        return head;
    }
    
    public static ListNode ArrayToLinkedList(int[] input, int pos)
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

    public static int NextElementAt(ListNode head, int index)
    {
        var i = 0;
        var curr = head;
        while (i++ < index)
            curr = curr.next;
        return curr.val;
    }
    
    public static int[] LinkedListToArray(ListNode head)
    {
        if (head == null) return Array.Empty<int>();

        var list = new List<int> { head.val };

        while (head.next is { } next)
        {
            list.Add(next.val);
            head = next;
        }

        return list.ToArray();
    }
}