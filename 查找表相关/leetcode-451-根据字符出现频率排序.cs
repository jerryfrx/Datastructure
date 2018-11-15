/*
ʾ�� 1:

����:
"tree"

���:
"eert"

����:
'e'�������Σ�'r'��'t'��ֻ����һ�Ρ�
���'e'���������'r'��'t'֮ǰ�����⣬"eetr"Ҳ��һ����Ч�Ĵ𰸡�
ʾ�� 2:

����:
"cccaaa"

���:
"cccaaa"

����:
'c'��'a'���������Ρ����⣬"aaaccc"Ҳ����Ч�Ĵ𰸡�
ע��"cacaca"�ǲ���ȷ�ģ���Ϊ��ͬ����ĸ�������һ��
ʾ�� 3:

����:
"Aabb"

���:
"bbAa"

����:
���⣬"bbaA"Ҳ��һ����Ч�Ĵ𰸣���"Aabb"�ǲ���ȷ�ġ�
ע��'A'��'a'����Ϊ�����ֲ�ͬ���ַ���
*/

using System;
using System.Collections.Generic;

public class Solution {
    public static void Main ( string[] args ) {
        Console.WriteLine ( FrequencySort ( "tree" ) );
    }
    public static string FrequencySort ( string s ) {
        Dictionary<char,int> dict = new Dictionary<char, int>();
        for ( int i = 0 ;i < s.Length ;i++ ) {
            if ( dict.ContainsKey ( s[i] ) ) {
                dict[s[i]]++;
            }
            else {
                dict.Add ( s[i],1 );
            }
        }
        List<KeyValuePair<char,int>> listdict = new List<KeyValuePair<char,int>>();
        foreach ( var item in dict ) {
            listdict.Add ( item );
        }
        foreach ( var item in listdict ) {
            Console.WriteLine ( item );
        }
        int count = 0;
        //[t 1]
        //[r 1]
        //[e 2]
        for ( int i = 0 ;i < listdict.Count ;i++ ) {
            for ( int j = i + 1 ;j < listdict.Count ;j++ ) {
                if ( listdict[i].Value < listdict[j].Value ) {
                    var temp = listdict[i];
                    listdict[i] = listdict[j];
                    listdict[j] = temp;
                    count++;
                }
            }
        }
        Console.WriteLine ( count );

        List<char> listchar = new List<char>();

        for ( int i = 0 ;i < listdict.Count ;i++ ) {
            for ( int j = 0 ;j < listdict[i].Value ;j++ ) {
                listchar.Add ( listdict[i].Key );
            }
        }

        return string.Join ( "",listchar.ToArray () );
    }
}
