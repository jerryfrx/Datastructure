/*
����һ��ֻ�����������ķǿ����顣�Ƿ���Խ��������ָ�������Ӽ���ʹ�������Ӽ���Ԫ�غ���ȡ�

ע��:

ÿ�������е�Ԫ�ز��ᳬ�� 100
����Ĵ�С���ᳬ�� 200
ʾ�� 1:

����: [1, 5, 11, 5]

���: true

����: ������Էָ�� [1, 5, 5] �� [11].
 

ʾ�� 2:

����: [1, 2, 3, 5]

���: false

����: ���鲻�ָܷ������Ԫ�غ���ȵ��Ӽ�.
*/

//��̬�滮
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

public class Solution {
    public static void Main ( string[] args ) {
    }
    public bool CanPartition ( int[] nums ) {
        int sum = 0;
        for ( int i = 0 ;i < nums.Length ;i++ ) {
            sum += nums[i];
        }
        if ( sum % 2 != 0 ) {
            return false;
        }

        int n = nums.Length;
        int c = sum/2;
        bool[] memo = Enumerable.Repeat(false,c+1).ToArray();

        for ( int i = 0 ;i <= c ;i++ ) {
            memo[i] = ( nums[0] == i );
        }
        for ( int i = 1 ;i < n ;i++ ) {
            for ( int j = c ;j >= nums[i] ;j-- ) {
                memo[j] = memo[j] || memo[j - nums[i]];
            }
        }
        return memo[c];
    }

}












