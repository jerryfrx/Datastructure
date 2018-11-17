/*
����һ������ļ��ϣ��ҵ���Ҫ�Ƴ��������С������ʹʣ�����以���ص���

ע��:

������Ϊ������յ����Ǵ���������㡣
���� [1,2] �� [2,3] �ı߽��໥���Ӵ�������û���໥�ص���
ʾ�� 1:

����: [ [1,2], [2,3], [3,4], [1,3] ]

���: 1

����: �Ƴ� [1,3] ��ʣ�µ�����û���ص���
ʾ�� 2:

����: [ [1,2], [1,2], [1,2] ]

���: 2

����: ����Ҫ�Ƴ����� [1,2] ��ʹʣ�µ�����û���ص���
ʾ�� 3:

����: [ [1,2], [2,3] ]

���: 0

����: �㲻��Ҫ�Ƴ��κ����䣬��Ϊ�����Ѿ������ص����ˡ�
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












