/*
0 1 �������� ���仯�����ⷨ
*/
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
public class Solution {

    public static void Main ( string[] args ) {
    }

    //Լ�����������������Լ��仯������Ҫһ����ά����
    int[,] memo;
    public int Knapsack01 ( int[] weight,int[] value,int capacity ) {
        int n = weight.Length;

        memo = new int[n,capacity + 1];
        for ( int i = 0 ;i < n ;i++ ) {
            for ( int j = 0 ;j < capacity + 1 ;j++ ) {
                memo[i,j] = -1;
            }
        }

        return BestValue ( weight,value,n - 1,capacity );
    }
    //��[0...index]����Ʒ������ݻ�Ϊc�ı���
    public int BestValue ( int[] w,int[] v,int index,int c ) {
        if ( index < 0 || c <= 0 ) {
            return 0;
        }
        if ( memo[index,c] != -1 ) {
            return memo[index,c];
        }
        int result = BestValue ( w,v,index - 1,c );
        if ( c >= w[index] ) {
            result = Math.Max ( result,v[index] + BestValue ( w,v,index - 1,c - w[index] ) );
        }
        memo[index,c] = result;
        return result;
    }
}
