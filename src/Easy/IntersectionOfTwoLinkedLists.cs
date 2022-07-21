using System.Collections.Generic;
using LeetCode.DataTypes;
using Xunit;

namespace LeetCode.Easy;

// [LinkedList] https://leetcode.com/problems/intersection-of-two-linked-lists/
public class IntersectionOfTwoLinkedLists
{
    // O(n + m) + O (n) space
    ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
        var map = new HashSet<ListNode>();

        var currA = headA;
        while (currA != null)
        {
            map.Add(currA);
            currA = currA.next;
        }

        var currB = headB;
        while (currB != null && !map.Contains(currB)) currB = currB.next;

        return currB;
    }

    // O(n * m) + O(1) space
    ListNode BruteForce(ListNode headA, ListNode headB)
    {
        var currA = headA;

        while (currA is not null)
        {
            var currB = headB;

            while (currB is not null)
            {
                if (currA == currB)
                    return currA;

                currB = currB.next;
            }

            currA = currA.next;
        }

        return null;
    }

    // O(n + m) + O(1)
    ListNode LenDifference(ListNode headA, ListNode headB)
    {
        var lenA = GetLength(headA);
        var lenB = GetLength(headB);

        var currA = headA;
        var currB = headB;

        if (lenA > lenB)
            currA = SkipElements(currA, lenA - lenB);
        if (lenB > lenA)
            currB = SkipElements(currB, lenB - lenA);

        while (currA is not null)
        {
            if (currA == currB)
                return currA;

            currA = currA.next;
            currB = currB.next;
        }

        return null;
    }

    int GetLength(ListNode head)
    {
        var len = 0;

        while (head is not null)
        {
            len++;
            head = head.next;
        }

        return len;
    }

    ListNode SkipElements(ListNode head, int skip)
    {
        var index = 0;
        var curr = head;

        while (index++ < skip)
            curr = curr.next;

        return curr;
    }

    // https://leetcode.com/problems/intersection-of-two-linked-lists/discuss/49785/Java-solution-without-knowing-the-difference-in-len!
    ListNode TwoPointers(ListNode headA, ListNode headB)
    {
        var currA = headA;
        var currB = headB;

        while (currA != currB)
        {
            currA = currA is null ? headB : currA.next;
            currB = currB is null ? headA : currB.next;
        }

        return currA;
    }

    [Theory]
    [InlineData(new[] { 4, 1, 8, 4, 5 }, new[] { 5, 6, 1, 8, 4, 5 }, 2, 3, 8)]
    [InlineData(new[] { 1, 9, 1, 2, 4 }, new[] { 3, 2, 4 }, 3, 1, 2)]
    [InlineData(new[] { 2, 6, 4 }, new[] { 1, 5 }, 3, 2, 0)]
    public void Test(int[] listA, int[] listB, int skipA, int skipB, int expected)
    {
        var headA = ListNode.ArrayToLinkedList(listA);
        var headB = ListNode.ArrayToLinkedList(listB);

        var intersectNode = LenDifference(headA, headB);
        var intersectVal = intersectNode?.val ?? 0;

        Assert.Equal(expected, intersectVal);
        if (intersectNode is null) return;

        var nextA = ListNode.NextElementAt(headA, skipA);
        var nextB = ListNode.NextElementAt(headB, skipB);

        Assert.Equal(nextA, nextB);
        Assert.Equal(expected, nextA);
        Assert.Equal(expected, nextB);
    }
}