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
    public IList<string> BinaryTreePaths ( TreeNode root ) {
        IList<string> result = new List<string>();
        //递归终止条件；
        if ( root == null ) {
            return result;
        }
        if ( root.left == null && root.right == null ) {
            result.Add ( root.val.ToString () );
            return result;
        }
        //递归的过程
        IList<string> leftS = BinaryTreePaths ( root.left );
        for ( int i = 0 ;i < leftS.Count ;i++ ) {
            result.Add ( root.val + "->" + leftS[i].ToString () );
        }
        IList<string> rightS = BinaryTreePaths(root.right);
        for ( int i = 0 ;i < rightS.Count ;i++ ) {
            result.Add ( root.val + "->" + rightS[i].ToString () );
        }
        return result;
    }
}