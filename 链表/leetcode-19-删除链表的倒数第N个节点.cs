/*
给定一个链表，删除链表的倒数第 n 个节点，并且返回链表的头结点。

示例：

给定一个链表: 1->2->3->4->5, 和 n = 2.

当删除了倒数第二个节点后，链表变为 1->2->3->5.
*/

//需要找到删除节点的前一个节点，设为p，
//当p指向删除节点前一个位置时，q指向链表尾->null
//即p与q之间的距离应该是n+1；
//同时让p和q移动，保持距离不变；
//双指针

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

