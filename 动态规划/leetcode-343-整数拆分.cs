/*
给定一个正整数 n，将其拆分为至少两个正整数的和，并使这些整数的乘积最大化。 返回你可以获得的最大乘积。

示例 1:

输入: 2
输出: 1
解释: 2 = 1 + 1, 1 × 1 = 1。
示例 2:

输入: 10
输出: 36
解释: 10 = 3 + 3 + 4, 3 × 3 × 4 = 36。
说明: 你可以假设 n 不小于 2 且不大于 58。
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
