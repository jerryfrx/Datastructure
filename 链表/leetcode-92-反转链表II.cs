/*
��ת��λ�� m �� n ��������ʹ��һ��ɨ����ɷ�ת��

˵��:
1 �� m �� n �� �����ȡ�

ʾ��:

����: 1->2->3->4->5->NULL, m = 2, n = 4
���: 1->4->3->2->5->NULL
*/
using System;
using System.Collections.Generic;
public class Solution {
    public static void Main ( string[] args ) {

    }


    public ListNode ReverseBetween ( ListNode head,int m,int n ) {
        if ( m == n ) {
            return head;
        }
        ListNode dummyhead = new ListNode(0);
        dummyhead.next = head;
        ListNode nodeMpre = dummyhead;
        ListNode nodeNnext = dummyhead;
        for ( int i = 0 ;i < m - 1 ;i++ ) {
            nodeMpre = nodeMpre.next;
        }

        ListNode current = nodeMpre.next.next;
        ListNode pre = nodeMpre.next;

        for ( int i = 0 ;i < n - m ;i++ ) {
            ListNode tail = current.next;
            current.next = pre;
            pre = current;
            current = tail;
        }

        nodeMpre.next.next = nodeNnext;
        nodeMpre.next = pre;
        return dummyhead.next;
    }
}


public class ListNode {
    public int val;
    public ListNode next;
    public ListNode ( int x ) { val = x; }
}

