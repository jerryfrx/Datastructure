/*
����һ������ɾ������ĵ����� n ���ڵ㣬���ҷ��������ͷ��㡣

ʾ����

����һ������: 1->2->3->4->5, �� n = 2.

��ɾ���˵����ڶ����ڵ�������Ϊ 1->2->3->5.
*/

//��Ҫ�ҵ�ɾ���ڵ��ǰһ���ڵ㣬��Ϊp��
//��pָ��ɾ���ڵ�ǰһ��λ��ʱ��qָ������β->null
//��p��q֮��ľ���Ӧ����n+1��
//ͬʱ��p��q�ƶ������־��벻�䣻
//˫ָ��

using System;
using System.Collections.Generic;
public class Solution {
    public ListNode RemoveNthFromEnd ( ListNode head,int n ) {
        ListNode dummyhead = new ListNode(0);
        dummyhead.next = head;
        ListNode p = dummyhead;
        ListNode q = dummyhead;
        for ( int i = 0 ;i < n+1 ;i++ ) {
            q = q.next;
        }
        while ( q != null ) {
            p = p.next;
            q = q.next;
        }
        ListNode delnode = p.next;
        p.next = delnode.next;
        delnode.next = null;
        return dummyhead.next;
    }
}


public class ListNode {
    public int val;
    public ListNode next;
    public ListNode ( int x ) { val = x; }
}

