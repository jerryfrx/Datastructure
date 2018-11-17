using System.Linq;
public class Solution {

    public int ClimbStairs ( int n ) {
        int[] memo = Enumerable.Repeat ( -1,n + 1 ).ToArray ();
        memo[0] = 1;
        memo[1] = 1;
        for ( int i = 2 ;i <= n ;i++ ) {
            memo[i] = memo[i - 1] + memo[i - 2];
        }
        return memo[n];
    }
}