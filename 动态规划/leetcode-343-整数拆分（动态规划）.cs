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

//�Ե�����
public class Solution {

    public static void Main ( string[] args ) {

    }
    public int IntegerBreak ( int n ) {
        Trace.Assert ( n >= 2 );
        //memo[i]��ʾ������i�ָ���ٷָ������֣���õ������˻�
        int[] memo = Enumerable.Repeat ( -1,n + 1 ).ToArray ();
        memo[1] = 1;
        for ( int i = 0 ;i <= n ;i++ ) {
            //���memo[i]
            for ( int j = 0 ;j <= i - 1 ;j++ ) {
                //j+(i-j)
                memo[i] = _Max ( memo[i],j * ( i - j ),j * memo[i - j] );
            }
        }
        return memo[n];
    }
    public int _Max ( int a,int b,int c ) {
        return Math.Max ( a,Math.Max ( b,c ) );
    }
}
