/*
给定一个链表，两两交换其中相邻的节点，并返回交换后的链表。

示例:

给定 1->2->3->4, 你应该返回 2->1->4->3.
说明:

你的算法只能使用常数的额外空间。
你不能只是单纯的改变节点内部的值，而是需要实际的进行节点交换。
*/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode SwapPairs ( ListNode head ) {
        ListNode dummyhead = new ListNode(0);
        dummyhead.next = head;
        ListNode p = dummyhead;
        while ( p.next != null && p.next.next != null ) {
            ListNode nodefirst = p.next;
            ListNode nodesecond = p.next.next;
            ListNode nodethird = nodesecond.next;

            nodesecond.next = nodefirst;
            nodefirst.next = nodethird;
            p.next = nodesecond;

            p = nodefirst;
        }
        return dummyhead.next;
    }
}