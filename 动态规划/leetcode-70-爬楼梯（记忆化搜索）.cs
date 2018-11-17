/*
������������¥�ݡ���Ҫ n ������ܵ���¥����

ÿ��������� 1 �� 2 ��̨�ס����ж����ֲ�ͬ�ķ�����������¥���أ�

ע�⣺���� n ��һ����������

ʾ�� 1��

���룺 2
����� 2
���ͣ� �����ַ�����������¥����
1.  1 �� + 1 ��
2.  2 ��
ʾ�� 2��

���룺 3
����� 3
���ͣ� �����ַ�����������¥����
1.  1 �� + 1 �� + 1 ��
2.  1 �� + 2 ��
3.  2 �� + 1 ��
*/
using System;
using System.Diagnostics;
using System.Linq;

public class Solution {
    int[] memo;
    public static void Main ( string[] args ) {

    }
    public int ClimbStairs ( int n ) {
        memo = Enumerable.Repeat ( -1,n + 1 ).ToArray ();
        return ClimbWays ( n );
    }
    public int ClimbWays ( int n ) {

        if ( n == 1 ) {
            return 1;
        }
        if ( n == 2 ) {
            return 2;
        }
        if ( memo[n] == -1 ) {
            memo[n] = ClimbWays ( n - 1 ) + ClimbWays ( n - 2 );
        }
        return memo[n];
    }
}
