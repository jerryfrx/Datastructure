/*
�����ַ��� s �� t ���ж� s �Ƿ�Ϊ t �������С�

�������Ϊ s �� t �н�����Ӣ��Сд��ĸ���ַ��� t ���ܻ�ܳ������� ~= 500,000������ s �Ǹ����ַ��������� <=100����

�ַ�����һ����������ԭʼ�ַ���ɾ��һЩ��Ҳ���Բ�ɾ�����ַ������ı�ʣ���ַ����λ���γɵ����ַ�����
�����磬"ace"��"abcde"��һ�������У���"aec"���ǣ���

ʾ�� 1:
s = "abc", t = "ahbgdc"

���� true.

ʾ�� 2:
s = "axc", t = "ahbgdc"

���� false.

������ս :

����д�������� S������S1, S2, ... , Sk ���� k >= 10�ڣ�����Ҫ���μ�������Ƿ�Ϊ T �������С�����������£���������ı���룿
*/

//̰���㷨
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

public class Solution {
    public static void Main ( string[] args ) {
        Console.WriteLine ( IsSubsequence ( "abc","abhcgd" ) );
    }
    public static bool IsSubsequence ( string s,string t ) {
        int si = 0;
        int ti = 0;
        int count = 0;
        while ( si < s.Length && ti < t.Length ) {
            if ( s[si] == t[ti] ) {
                si++;
                ti++;
                count++;
            }
            else {
                ti++;
            }
        }
        if ( count == s.Length ) {
            return true;
        }
        return false;
    }
}












