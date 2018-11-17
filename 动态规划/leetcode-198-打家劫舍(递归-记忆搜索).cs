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
//�Զ����� ���仯����
public class Solution {

    public static void Main ( string[] args ) {

    }
    //memo[i]��ʾ��������nums[i...n)�������ٵ��������
    int[] memo;
    public int Rob ( int[] nums ) {
        memo = Enumerable.Repeat ( -1,nums.Length ).ToArray ();
        return _Rob ( nums,0 );
    }
    //��������nums[index...nums.Length]�����Χ�����з���
    public int _Rob ( int[] nums,int index ) {
        if ( index >= nums.Length ) {
            return 0;
        }
        if ( memo[index] != -1 ) {
            return memo[index];
        }
        int result = 0;
        for ( int i = index ;i < nums.Length ;i++ ) {
            result = Math.Max ( result,nums[i] + _Rob ( nums,i + 2 ) );
        }
        memo[index] = result;
        return result;
    }
}
