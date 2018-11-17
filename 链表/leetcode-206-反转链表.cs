/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 * 反转一个单链表。

示例:

输入: 1->2->3->4->5->NULL
输出: 5->4->3->2->1->NULL
 */
public class Solution {
    public ListNode ReverseList ( ListNode head ) {
        ListNode front = null;
        ListNode current = head;
        while ( current != null ) {
            ListNode tail = current.next;
            current.next = front;
            front = current;
            current = tail;
        }
        return front;
    }
}