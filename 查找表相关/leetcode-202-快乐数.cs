/*
编写一个算法来判断一个数是不是“快乐数”。

一个“快乐数”定义为：对于一个正整数，每一次将该数替换为它每个位置上的数字的平方和，
然后重复这个过程直到这个数变为 1，也可能是无限循环但始终变不到 1。如果可以变为 1，那么这个数就是快乐数。

示例: 

输入: 19
输出: true
解释: 
1^2 + 9^2 = 82
8^2 + 2^2 = 68
6^2 + 8^2 = 100
1^2 + 0^2 + 0^2 = 1
*/

using System;
using System.Collections.Generic;

public class Solution {
    public static void Main ( string[] args ) {
        Console.WriteLine (IsHappy ( 2 ));
    }
    public static bool IsHappy ( int n ) {
        string s = n.ToString();
        List<int> list = new List<int>();

        for ( int i = 0 ;i < s.Length ;i++ ) {
            list.Add ( int.Parse ( s[i].ToString () ) );
        }

        Dictionary<int,int> dict = new Dictionary<int, int>();

        int sum = 0;

        string strsum;

        while ( true ) {
            for ( int i = 0 ;i < list.Count ;i++ ) {
                sum += list[i]*list[i];
            }
            if ( sum == 1 ) {
                return true;
            }
            if ( dict.ContainsKey ( sum ) ) {
                return false;
            }
            else {
                dict.Add ( sum,1 );
            }
            list.Clear ();
            strsum = sum.ToString ();
            for ( int i = 0 ;i < strsum.Length ;i++ ) {
                list.Add ( int.Parse ( strsum[i].ToString () ) );
            }
            sum = 0;
        }   
        return false;
    }
}
