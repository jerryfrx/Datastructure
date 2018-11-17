/*

����һ�������������е������ڵ��ż���ڵ�ֱ�����һ����ע�⣬����������ڵ��ż���ڵ�ָ���ǽڵ��ŵ���ż�ԣ������ǽڵ��ֵ����ż�ԡ�

�볢��ʹ��ԭ���㷨��ɡ�����㷨�Ŀռ临�Ӷ�ӦΪ O(1)��ʱ�临�Ӷ�ӦΪ O(nodes)��nodes Ϊ�ڵ�������

ʾ�� 1:

����: 1->2->3->4->5->NULL
���: 1->3->5->2->4->NULL
ʾ�� 2:

����: 2->1->3->5->6->4->7->NULL 
���: 2->3->6->7->1->5->4->NULL
˵��:

Ӧ�����������ڵ��ż���ڵ�����˳��
����ĵ�һ���ڵ���Ϊ�����ڵ㣬�ڶ����ڵ���Ϊż���ڵ㣬�Դ����ơ�
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
        int count = 1;
        while ( head != null ) {
            if ( count % 2 != 0 ) {
                node1.next = head;
                head = head.next;
                node1 = node1.next;
                node1.next = null;
                count++;
            }
            else if ( count % 2 == 0 ) {
                node2.next = head;
                head = head.next;
                node2 = node2.next;
                node2.next = null;
                count++;
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

