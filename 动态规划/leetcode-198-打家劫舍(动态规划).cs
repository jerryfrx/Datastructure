/*
����һ��רҵ��С͵���ƻ�͵���ؽֵķ��ݡ�ÿ�䷿�ڶ�����һ�����ֽ�
Ӱ����͵�Ե�Ψһ��Լ���ؾ������ڵķ���װ���໥��ͨ�ķ���ϵͳ������������ڵķ�����ͬһ���ϱ�С͵���룬ϵͳ���Զ�������

����һ������ÿ�����ݴ�Ž��ķǸ��������飬�������ڲ���������װ�õ�����£��ܹ�͵�Ե�����߽�

ʾ�� 1:

����: [1,2,3,1]
���: 4
����: ͵�� 1 �ŷ��� (��� = 1) ��Ȼ��͵�� 3 �ŷ��� (��� = 3)��
     ͵�Ե�����߽�� = 1 + 3 = 4 ��
ʾ�� 2:

����: [2,7,9,3,1]
���: 12
����: ͵�� 1 �ŷ��� (��� = 2), ͵�� 3 �ŷ��� (��� = 9)������͵�� 5 �ŷ��� (��� = 1)��
     ͵�Ե�����߽�� = 2 + 9 + 1 = 12 ��
*/
using System;
using System.Diagnostics;
using System.Linq;
//�Ե����� ��̬�滮
public class Solution {

    public static void Main ( string[] args ) {

    }

    public int Rob ( int[] nums ) {
        int n = nums.Length;
        if ( n == 0 ) {
            return 0;
        }
        int[] memo = Enumerable.Repeat ( -1,nums.Length ).ToArray ();
        memo[n - 1] = nums[n - 1];
        for ( int i = n - 2 ;i >= 0 ;i-- ) {
            for ( int j = i ;j < n ;j++ ) {
                memo[i] = Math.Max ( memo[i],nums[j] + ( j + 2 < n ? memo[j + 2] : 0 ) );
            }
        }
        return memo[0];
    }
}
