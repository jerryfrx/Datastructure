/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 * 计算给定二叉树的所有左叶子之和。

示例：

    3
   / \
  9  20
    /  \
   15   7

在这个二叉树中，有两个左叶子，分别是 9 和 15，所以返回 24
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