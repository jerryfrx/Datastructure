/*
给定两个字符串 s 和 t ，编写一个函数来判断 t 是否是 s 的一个字母异位词。

示例 1:

输入: s = "anagram", t = "nagaram"
输出: true
示例 2:

输入: s = "rat", t = "car"
输出: false
说明:
你可以假设字符串只包含小写字母。
*/


public class Solution {
    public bool IsAnagram ( string s,string t ) {
        Dictionary<char,int> dictS = new Dictionary<char, int>();
        Dictionary<char,int> dictT = new Dictionary<char, int>();

        foreach ( var item in s ) {
            if ( dictS.ContainsKey ( item ) ) {
                dictS[item]++;
            }
            else {
                dictS.Add ( item,1 );
            }
        }
        foreach ( var item in t ) {
            if ( dictT.ContainsKey ( item ) ) {
                dictT[item]++;
            }
            else {
                dictT.Add ( item,1 );
            }
        }
        if ( s.Length != t.Length ) {
            return false;
        }

        foreach ( var item in s ) {
            if ( !dictT.ContainsKey ( item ) || dictS[item] != dictT[item] ) {
                return false;
            }
        }
        return true;
    }
}
