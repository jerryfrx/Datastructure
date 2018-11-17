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
        Stack<TreeNode> stack = new Stack<TreeNode>();
        while ( root != null || stack.Count () != 0 ) {
            if ( root != null ) {
                stack.Push ( root );
                root = root.left;
            }
            else {
                root = stack.Pop ();
                list.Add ( root.val );
                root = root.right;
            }
        }
        return list;
    }
}