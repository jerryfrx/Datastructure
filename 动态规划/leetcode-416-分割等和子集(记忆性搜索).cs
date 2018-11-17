/*
给定一个只包含正整数的非空数组。是否可以将这个数组分割成两个子集，使得两个子集的元素和相等。

注意:

每个数组中的元素不会超过 100
数组的大小不会超过 200
示例 1:

输入: [1, 5, 11, 5]

输出: true

解释: 数组可以分割成 [1, 5, 5] 和 [11].
 

示例 2:

输入: [1, 2, 3, 5]

输出: false

解释: 数组不能分割成两个元素和相等的子集.
*/

//记忆性查询
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

public class Solution {

    //memo[i,c]表示使用索引[0...i]的这些元素，是否可以完全填充一个容量为c的背包
    //-1表示未计算，0表示不可以填充，1表示可以填充
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
    //使nums[0...index]，是否可以填充一个容量为sum的背包
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












