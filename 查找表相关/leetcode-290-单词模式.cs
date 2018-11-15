/*
给定一种 pattern(模式) 和一个字符串 str ，判断 str 是否遵循相同的模式。

这里的遵循指完全匹配，例如， pattern 里的每个字母和字符串 str 中的每个非空单词之间存在着双向连接的对应模式。

示例1:

输入: pattern = "abba", str = "dog cat cat dog"
输出: true
示例 2:

输入:pattern = "abba", str = "dog cat cat fish"
输出: false
示例 3:

输入: pattern = "aaaa", str = "dog cat cat dog"
输出: false
示例 4:

输入: pattern = "abba", str = "dog dog dog dog"
输出: false
说明:
你可以假设 pattern 只包含小写字母， str 包含了由单个空格分隔的小写字母。
*/

using System;
using System.Collections.Generic;

public class Solution {
    public static void Main ( string[] args ) {
        Console.WriteLine ( WordPattern ( "abaa","cat dog cat cat" ) );
    }
    public static bool WordPattern ( string pattern,string str ) {
        List<char> listpattern = new List<char>();
        foreach ( var item in pattern ) {
            listpattern.Add ( item );
        }
        Dictionary<char,int> dictpattern = new Dictionary<char, int>();
        for ( int i = 0 ;i < listpattern.Count ;i++ ) {
            if ( dictpattern.ContainsKey ( listpattern[i] ) ) {
                dictpattern[listpattern[i]]++;
            }
            else {
                dictpattern.Add ( listpattern[i],1 );
            }
        }
        foreach ( var item in dictpattern ) {
            Console.WriteLine ( item );
        }
        List<string> liststr = new List<string>();
        var arraystr = str.Split ( ' ' );
        foreach ( var item in arraystr ) {
            liststr.Add ( item );
        }

        Dictionary<string,int> dictstr = new Dictionary<string, int>();
        for ( int i = 0 ;i < liststr.Count ;i++ ) {
            if ( dictstr.ContainsKey ( liststr[i] ) ) {
                dictstr[liststr[i]]++;
            }
            else {
                dictstr.Add ( liststr[i],1 );
            }
        }

        if ( listpattern.Count != liststr.Count ) {
            return false;
        }

        for ( int i = 0 ;i < listpattern.Count ;i++ ) {
            if ( dictpattern[listpattern[i]] != dictstr[liststr[i]] ) {
                return false;
            }
        }
        return true;
    }
}

