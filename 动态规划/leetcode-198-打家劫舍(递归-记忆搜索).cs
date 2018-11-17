/*
你是一个专业的小偷，计划偷窃沿街的房屋。每间房内都藏有一定的现金，
影响你偷窃的唯一制约因素就是相邻的房屋装有相互连通的防盗系统，如果两间相邻的房屋在同一晚上被小偷闯入，系统会自动报警。

给定一个代表每个房屋存放金额的非负整数数组，计算你在不触动警报装置的情况下，能够偷窃到的最高金额。

示例 1:

输入: [1,2,3,1]
输出: 4
解释: 偷窃 1 号房屋 (金额 = 1) ，然后偷窃 3 号房屋 (金额 = 3)。
     偷窃到的最高金额 = 1 + 3 = 4 。
示例 2:

输入: [2,7,9,3,1]
输出: 12
解释: 偷窃 1 号房屋 (金额 = 2), 偷窃 3 号房屋 (金额 = 9)，接着偷窃 5 号房屋 (金额 = 1)。
     偷窃到的最高金额 = 2 + 9 + 1 = 12 。
*/
using System;
using System.Diagnostics;
using System.Linq;
//自顶向下 记忆化搜素
public class Solution {

    public static void Main ( string[] args ) {

    }
    //memo[i]表示考虑抢劫nums[i...n)所能抢劫的最大收益
    int[] memo;
    public int Rob ( int[] nums ) {
        memo = Enumerable.Repeat ( -1,nums.Length ).ToArray ();
        return _Rob ( nums,0 );
    }
    //考虑抢劫nums[index...nums.Length]这个范围的所有房子
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
