/*
����һ���������������������ڵĽڵ㣬�����ؽ����������

ʾ��:

���� 1->2->3->4, ��Ӧ�÷��� 2->1->4->3.
˵��:

����㷨ֻ��ʹ�ó����Ķ���ռ䡣
�㲻��ֻ�ǵ����ĸı�ڵ��ڲ���ֵ��������Ҫʵ�ʵĽ��нڵ㽻����
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