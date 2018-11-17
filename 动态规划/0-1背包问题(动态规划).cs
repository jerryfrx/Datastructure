/*
0 1 背包问题 动态规划
*/
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

public class Solution {

    public static void Main ( string[] args ) {
    }
    public int Knapsack01 ( int[] weight,int[] value,int capacity ) {
        Trace.Assert ( weight.Length == value.Length );
        int n = weight.Length;
        if ( n == 0 ) {
            return 0;
        }
        int[,] memo = new int[n,capacity+1];
        for ( int i = 0 ;i < n ;i++ ) {
            for ( int j = 0 ;j < capacity + 1 ;j++ ) {
                memo[i,j] = -1;
            }
        }
        for ( int k = 0 ;k <= capacity ;k++ ) {
            memo[0,k] = ( k >= weight[0] ? value[0] : 0 );
        }
        for ( int p = 1 ;p < n ;p++ ) {
            for ( int t = 0 ;t <= capacity ;t++ ) {
                memo[p,t] = memo[p - 1,t];
                if ( t >= weight[p] ) {
                    memo[p,t] = Math.Max ( memo[p,t],value[p] + memo[p - 1,t - weight[p]] );
                }
            }
        }
        return memo[n - 1,capacity];
    }

}
