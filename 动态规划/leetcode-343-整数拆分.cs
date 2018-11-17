/*
����һ�������� n��������Ϊ���������������ĺͣ���ʹ��Щ�����ĳ˻���󻯡� ��������Ի�õ����˻���

ʾ�� 1:

����: 2
���: 1
����: 2 = 1 + 1, 1 �� 1 = 1��
ʾ�� 2:

����: 10
���: 36
����: 10 = 3 + 3 + 4, 3 �� 3 �� 4 = 36��
˵��: ����Լ��� n ��С�� 2 �Ҳ����� 58��
*/
using System;
using System.Diagnostics;
using System.Linq;

public class Solution {
    public int[] memo;
    public static void Main ( string[] args ) {

    }
    public int IntegerBreak ( int n ) {
        memo = Enumerable.Repeat ( -1,n + 1 ).ToArray ();
        return BreakInt ( n );
    }
    public int BreakInt ( int n ) {
        if ( n == 1 ) {
            return 1;
        }
        if ( memo[n] != -1 ) {
            return memo[n];
        }
        int result = -1;
        for ( int i = 1 ;i <= n - 1 ;i++ ) {
            result = _Max ( result,i * ( n - i ),i * BreakInt ( n - i ) );
        }
        memo[n] = result;
        return result;
    }
    public int _Max ( int a,int b,int c ) {
        return Math.Max ( a,Math.Max ( b,c ) );
    }
}
