/*����:
s: "cbaebabacd" p: "abc"

���:
[0, 6]

����:
��ʼ�������� 0 ���Ӵ��� "cba", ���� "abc" ����ĸ��λ�ʡ�
��ʼ�������� 6 ���Ӵ��� "bac", ���� "abc" ����ĸ��λ�ʡ�
*/

//δͨ��������ʱ�����ƣ�Ҫ�Ľ�

using System;
using System.Collections.Generic;

public class Solution {
    public static void Main ( string[] args ) {
        IList<int> res = FindAnagrams("abaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa","ab");
        foreach ( var item in res ) {
            Console.WriteLine ( item );
        }
    }
    public static IList<int> FindAnagrams ( string s,string p ) {
        int l = 0;
        int r = p.Length - 1;
        IList<int> result = new List<int>();
        List<char> list2 = new List<char>();

        foreach ( var item in p ) {
            list2.Add ( item );
        }


        while ( r < s.Length ) {
            List<char> list1 = new List<char>();

            for ( int i = l ;i <= r ;i++ ) {
                list1.Add ( s[i] );
            }

            list1.Sort ();
            list2.Sort ();
            string s1 = new string(list1.ToArray());
            string s2 = new string(list2.ToArray());


            if ( s1.Equals ( s2 ) ) {
                result.Add ( l );
            }
            l++;
            r++;
        }
        return result;
    }
}