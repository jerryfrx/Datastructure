/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 * ���������������������Ҷ��֮�͡�

ʾ����

    3
   / \
  9  20
    /  \
   15   7

������������У���������Ҷ�ӣ��ֱ��� 9 �� 15�����Է��� 24
 */
public class Solution {
    public int SumOfLeftLeaves ( TreeNode root ) {
        if ( root == null ) {
            return 0;
        }
        int leftside = 0;
        int rightside = 0;
        if ( root.left != null && root.left.left == null && root.left.right == null ) {
            leftside = root.left.val;
        }
        else {
            leftside = SumOfLeftLeaves ( root.left );
        }
        rightside = SumOfLeftLeaves ( root.right );
        return leftside + rightside;
    }
}