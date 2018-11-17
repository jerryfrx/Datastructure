/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    IList<int> list = new List<int>();
    public IList<int> InorderTraversal ( TreeNode root ) {
        if ( root == null ) {
            return list;
        }
        InorderTraversal ( root.left );
        list.Add ( root.val );
        InorderTraversal ( root.right );
        return list;
    }
}