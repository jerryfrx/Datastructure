/*输入:
s: "cbaebabacd" p: "abc"

输出:
[0, 6]

解释:
起始索引等于 0 的子串是 "cba", 它是 "abc" 的字母异位词。
起始索引等于 6 的子串是 "bac", 它是 "abc" 的字母异位词。
*/

//未通过，超出时间限制，要改进

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