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

//自底向上
public class Solution {

    public static void Main ( string[] args ) {

    }
    public int IntegerBreak ( int n ) {
        Trace.Assert ( n >= 2 );
        //memo[i]表示将数字i分割（至少分割两部分）后得到的最大乘积
        int[] memo = Enumerable.Repeat ( -1,n + 1 ).ToArray ();
        memo[1] = 1;
        for ( int i = 0 ;i <= n ;i++ ) {
            //求解memo[i]
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
