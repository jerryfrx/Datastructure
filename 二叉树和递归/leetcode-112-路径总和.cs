/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 * 
 * 
 * ����һ����������һ��Ŀ��ͣ��жϸ������Ƿ���ڸ��ڵ㵽Ҷ�ӽڵ��·��������·�������нڵ�ֵ��ӵ���Ŀ��͡�

˵��: Ҷ�ӽڵ���ָû���ӽڵ�Ľڵ㡣

ʾ��: 
�������¶��������Լ�Ŀ��� sum = 22��

              5
             / \
            4   8
           /   / \
          11  13  4
         /  \      \
        7    2      1
���� true, ��Ϊ����Ŀ���Ϊ 22 �ĸ��ڵ㵽Ҷ�ӽڵ��·�� 5->4->11->2��
 */
public class Solution {
    public bool HasPathSum ( TreeNode root,int sum ) {
        if ( root == null ) {
            return false;
        }
        if ( root.left == null && root.right == null ) {
            return root.val == sum;
        }
        if ( HasPathSum ( root.left,sum - root.val ) ) {
            return true;
        }
        if ( HasPathSum ( root.right,sum - root.val ) ) {
            return true;
        }
        return false;
    }
}