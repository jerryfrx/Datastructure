/*
��������һλ�ܰ��ļҳ�����Ҫ����ĺ�����һЩС���ɡ����ǣ�ÿ���������ֻ�ܸ�һ����ɡ���ÿ������ i ��
����һ��θ��ֵ gi ���������ú���������θ�ڵı��ɵ���С�ߴ磻����ÿ����� j ������һ���ߴ� sj ����� sj >= gi ��
���ǿ��Խ�������� j ��������� i ��������ӻ�õ����㡣���Ŀ���Ǿ���������Խ�������ĺ��ӣ��������������ֵ��

ע�⣺

����Լ���θ��ֵΪ����
һ��С�������ֻ��ӵ��һ����ɡ�

ʾ�� 1:

����: [1,2,3], [1,1]

���: 1

����: 
�����������Ӻ�����С���ɣ�3�����ӵ�θ��ֵ�ֱ��ǣ�1,2,3��
��Ȼ��������С���ɣ��������ǵĳߴ綼��1����ֻ����θ��ֵ��1�ĺ������㡣
������Ӧ�����1��
ʾ�� 2:

����: [1,2], [1,2,3]

���: 2

����: 
�����������Ӻ�����С���ɣ�2�����ӵ�θ��ֵ�ֱ���1,2��
��ӵ�еı��������ͳߴ綼���������к������㡣
������Ӧ�����2.
*/

//̰���㷨
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

public class Solution {
    public static void Main ( string[] args ) {
        int[] array = {1,3,4,5,21,7,2 };

    }
    public int FindContentChildren ( int[] g,int[] s ) {
        List<int>listg = new List<int>(g);
        List<int>lists = new List<int>(s);
        listg.Sort ();
        lists.Sort ();
        listg.Reverse ();
        lists.Reverse ();
        int gi = 0;
        int si = 0;
        int result = 0;
        while ( gi < g.Length && si < s.Length ) {
            if ( lists[si] >= listg[gi] ) {
                si++;
                gi++;
                result++;
            }
            else {
                gi++;
            }
        }
        return result;
    }
}












