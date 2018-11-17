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

//�����Բ�ѯ
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

public class Solution {

    //memo[i,c]��ʾʹ������[0...i]����ЩԪ�أ��Ƿ������ȫ���һ������Ϊc�ı���
    //-1��ʾδ���㣬0��ʾ��������䣬1��ʾ�������
    int[,] memo;
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
        memo = new int[nums.Length,sum / 2 + 1];
        for ( int i = 0 ;i < nums.Length ;i++ ) {
            for ( int j = 0 ;j < sum / 2 + 1 ;j++ ) {
                memo[i,j] = -1;
            }
        }
        return _Partition ( nums,nums.Length - 1,sum / 2 );
    }
    //ʹnums[0...index]���Ƿ�������һ������Ϊsum�ı���
    private bool _Partition ( int[] nums,int index,int sum ) {
        if ( sum == 0 ) {
            return true;
        }
        if ( sum < 0 || index < 0 ) {
            return false;
        }
        if ( memo[index,sum] != -1 ) {
            return memo[index,sum] == 1;
        }
        memo[index,sum] = ( _Partition ( nums,index - 1,sum ) || _Partition ( nums,index - 1,sum - nums[index] ) ) ? 1 : 0;
        return memo[index,sum] == 1;
    }
}












