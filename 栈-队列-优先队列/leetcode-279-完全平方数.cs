/*
给定正整数 n，找到若干个完全平方数（比如 1, 4, 9, 16, ...）使得它们的和等于 n。你需要让组成和的完全平方数的个数最少。

示例 1:

输入: n = 12
输出: 3 
解释: 12 = 4 + 4 + 4.
示例 2:

输入: n = 13
输出: 2
解释: 13 = 4 + 9.
*/
using System.Diagnostics;
using System.Linq;
public class Solution {
    public int NumSquares ( int n ) {
        Trace.Assert ( n > 0 );
        Queue<KeyValuePair<int,int>>queue = new Queue<KeyValuePair<int, int>>();
        queue.Enqueue ( new KeyValuePair<int,int> ( n,0 ) );

        bool[] visited = Enumerable.Repeat(false,n+1).ToArray();
        while ( queue.Count () != 0 ) {
            KeyValuePair<int,int> res = queue.Dequeue();
            int num = res.Key;
            int step = res.Value;

            for ( int i = 0 ;;i++ ) {
                int a = num-i*i;
                if ( a < 0 ) {
                    break;
                }
                if ( a == 0 ) {
                    return step + 1;
                }
                if ( !visited[a] ) {
                    queue.Enqueue ( new KeyValuePair<int,int> ( ( a ),step + 1 ) );
                    visited[a] = true;
                }
            }
        }
        throw new Exception ( "no result" );
    }
}