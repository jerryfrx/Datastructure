/*
��дһ���㷨���ж�һ�����ǲ��ǡ�����������

һ����������������Ϊ������һ����������ÿһ�ν������滻Ϊ��ÿ��λ���ϵ����ֵ�ƽ���ͣ�
Ȼ���ظ��������ֱ���������Ϊ 1��Ҳ����������ѭ����ʼ�ձ䲻�� 1��������Ա�Ϊ 1����ô��������ǿ�������

ʾ��: 

����: 19
���: true
����: 
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
