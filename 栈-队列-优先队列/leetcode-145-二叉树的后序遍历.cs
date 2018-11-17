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
    public IList<int> PostorderTraversal ( TreeNode root ) {
        if ( root == null ) {
            return list;
        }
        PostorderTraversal ( root.left );
        PostorderTraversal ( root.right );
        list.Add ( root.val );
        return list;
    }
}