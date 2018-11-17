/*
给定一个区间的集合，找到需要移除区间的最小数量，使剩余区间互不重叠。

注意:

可以认为区间的终点总是大于它的起点。
区间 [1,2] 和 [2,3] 的边界相互“接触”，但没有相互重叠。
示例 1:

输入: [ [1,2], [2,3], [3,4], [1,3] ]

输出: 1

解释: 移除 [1,3] 后，剩下的区间没有重叠。
示例 2:

输入: [ [1,2], [1,2], [1,2] ]

输出: 2

解释: 你需要移除两个 [1,2] 来使剩下的区间没有重叠。
示例 3:

输入: [ [1,2], [2,3] ]

输出: 0

解释: 你不需要移除任何区间，因为它们已经是无重叠的了。
*/

using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

/**
 * Definition for an interval.
 * public class Interval {
 *     public int start;
 *     public int end;
 *     public Interval() { start = 0; end = 0; }
 *     public Interval(int s, int e) { start = s; end = e; }
 * }
 */
public class Solution {
    public int EraseOverlapIntervals ( Interval[] intervals ) {
        if ( intervals.Length == 0 ) {
            return 0;
        }
        var list = (from interval in intervals orderby interval.start select interval).ToList();

        int[] memo = Enumerable.Repeat(1,list.Count).ToArray();

        for ( int i = 0 ;i < list.Count ;i++ ) {
            for ( int j = 0 ;j < i ;j++ ) {
                if ( list[i].start >= list[j].end ) {
                    memo[i] = Math.Max ( memo[i],1 + memo[j] );
                }
            }
        }
        int result = 0;
        for ( int i = 0 ;i < memo.Length ;i++ ) {
            result = Math.Max ( result,memo[i] );
        }
        return list.Count - result;
    }
    public class Interval {
        public int start;
        public int end;
        public Interval ( ) { start = 0; end = 0; }
        public Interval ( int s,int e ) { start = s; end = e; }
    }

}












