using System;
using System.Collections.Generic;
using Xunit;

namespace LeetCode._2022
{
    // [Easy][LinkedList] https://leetcode.com/problems/reverse-linked-list/
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
            var inputList = ArrayToLinkedList(input);
            var reversedList = ReverseList(inputList);
            var actual = LinkedListToArray(reversedList);
            Assert.Equal(expected, actual);
        }

        ListNode ArrayToLinkedList(int[] input)
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

        int[] LinkedListToArray(ListNode head)
        {
            if (head == null) return Array.Empty<int>();

            var list = new List<int> { head.val };

            ListNode next;
            while ((next = head.next) != null)
            {
                list.Add(next.val);
                head = next;
            }

            return list.ToArray();
        }
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
}