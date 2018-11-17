/*

给定一个单链表，把所有的奇数节点和偶数节点分别排在一起。请注意，这里的奇数节点和偶数节点指的是节点编号的奇偶性，而不是节点的值的奇偶性。

请尝试使用原地算法完成。你的算法的空间复杂度应为 O(1)，时间复杂度应为 O(nodes)，nodes 为节点总数。

示例 1:

输入: 1->2->3->4->5->NULL
输出: 1->3->5->2->4->NULL
示例 2:

输入: 2->1->3->5->6->4->7->NULL 
输出: 2->3->6->7->1->5->4->NULL
说明:

应当保持奇数节点和偶数节点的相对顺序。
链表的第一个节点视为奇数节点，第二个节点视为偶数节点，以此类推。
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

