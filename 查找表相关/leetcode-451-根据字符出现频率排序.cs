/*
示例 1:

输入:
"tree"

输出:
"eert"

解释:
'e'出现两次，'r'和't'都只出现一次。
因此'e'必须出现在'r'和't'之前。此外，"eetr"也是一个有效的答案。
示例 2:

输入:
"cccaaa"

输出:
"cccaaa"

解释:
'c'和'a'都出现三次。此外，"aaaccc"也是有效的答案。
注意"cacaca"是不正确的，因为相同的字母必须放在一起。
示例 3:

输入:
"Aabb"

输出:
"bbAa"

解释:
此外，"bbaA"也是一个有效的答案，但"Aabb"是不正确的。
注意'A'和'a'被认为是两种不同的字符。
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
