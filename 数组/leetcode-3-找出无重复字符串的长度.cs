using System.Linq;
using System;

/*给定一个字符串，找出不含有重复字符的最长子串的长度。
输入: "abcabcbb"
输出: 3 
解释: 无重复字符的最长子串是 "abc"，其长度为 3
*/

//滑动窗口
public class Solution {
    public int LengthOfLongestSubstring ( string s ) {
        int l = 0;
        int r = -1;
        int[] freq = Enumerable.Repeat(0,256).ToArray();
        int result = 0;
        while ( l < s.Length ) {
            if ( r + 1 < s.Length && freq[s[r + 1]] == 0 ) {
                r++;
                freq[s[r]]++;
            }
            else {
                freq[s[l]]--;
                l++;
            }
            result = Math.Max ( result,r - l + 1 );
        }
        return result;
    }
}