/*
给定一个二叉树，返回其按层次遍历的节点值。 （即逐层地，从左到右访问所有节点）。

例如:
给定二叉树: [3,9,20,null,null,15,7],

    3
   / \
  9  20
    /  \
   15   7
返回其层次遍历结果：

[
  [3],
  [9,20],
  [15,7]
]
*/
using System;
using System.Collections.Generic;
public class Solution {
    public IList<IList<int>> LevelOrder ( TreeNode root ) {
        IList<IList<int>> result = new List<IList<int>>();
        if ( root == null ) {
            return result;
        }
        Queue<KeyValuePair<TreeNode,int>> queue = new Queue<KeyValuePair<TreeNode, int>>();
        queue.Enqueue ( new KeyValuePair<TreeNode,int> ( root,0 ) );
        while ( queue.Count != 0 ) {
            TreeNode node = queue.Peek().Key;
            int level = queue.Peek().Value;
            queue.Dequeue ();

            if ( level == result.Count ) {
                result.Add ( new List<int> () );
            }
            result[level].Add ( node.val );
            if ( node.left != null ) {
                queue.Enqueue ( new KeyValuePair<TreeNode,int> ( node.left,level + 1 ) );
            }
            if ( node.right != null ) {
                queue.Enqueue ( new KeyValuePair<TreeNode,int> ( node.right,level + 1 ) );
            }
        }

        return result;
    }

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode ( int x ) { val = x; }
    }
}


