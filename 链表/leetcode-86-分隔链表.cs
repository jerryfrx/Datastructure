/*

����һ�������һ���ض�ֵ x����������зָ���ʹ������С�� x �Ľڵ㶼�ڴ��ڻ���� x �Ľڵ�֮ǰ��

��Ӧ����������������ÿ���ڵ�ĳ�ʼ���λ�á�

ʾ��:

����: head = 1->4->3->2->5->2, x = 3
���: 1->2->2->4->3->5

*/
using System;
using System.Collections.Generic;
public class Solution {
    public static void Main ( string[] args ) {

    }


    public ListNode Partition ( ListNode head,int x ) {
        ListNode dummyhead1 = new ListNode(0);
        ListNode dummyhead2 = new ListNode(0);
        ListNode node1 = dummyhead1;
        ListNode node2 = dummyhead2;
        while ( head != null ) {
            if ( head.val < x ) {
                node1.next = head;
                head = head.next;
                node1 = node1.next;
                node1.next = null;
            }
            else {
                node2.next = head;
                head = head.next;
                node2 = node2.next;
                node2.next = null;
            }
        }
        node1.next = dummyhead2.next;
        return dummyhead1.next;
    }
}


public class ListNode {
    public int val;
    public ListNode next;
    public ListNode ( int x ) { val = x; }
}

