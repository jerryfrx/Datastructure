/*
翻转一棵二叉树。

示例：

输入：

     4
   /   \
  2     7
 / \   / \
1   3 6   9
输出：

     4
   /   \
  7     2
 / \   / \
9   6 3   1
*/
using System;

class Solution {
    public TreeNode InvertTree ( TreeNode root ) {
        if ( root == null ) {
            return null;
        }
        TreeNode left = InvertTree ( root.left );
        TreeNode right = InvertTree ( root.right );
        root.left = right;
        root.right = left;
        return root;
    }

    public class TreeNode {
        int val;
        public TreeNode left;
        public TreeNode right;
        TreeNode ( int x ) { val = x; }
    }
}


