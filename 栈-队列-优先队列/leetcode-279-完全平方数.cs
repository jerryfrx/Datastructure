/*
���������� n���ҵ����ɸ���ȫƽ���������� 1, 4, 9, 16, ...��ʹ�����ǵĺ͵��� n������Ҫ����ɺ͵���ȫƽ�����ĸ������١�

ʾ�� 1:

����: n = 12
���: 3 
����: 12 = 4 + 4 + 4.
ʾ�� 2:

����: n = 13
���: 2
����: 13 = 4 + 9.
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