using System.Linq;
using System;

/*����һ���ַ������ҳ��������ظ��ַ�����Ӵ��ĳ��ȡ�
����: "abcabcbb"
���: 3 
����: ���ظ��ַ�����Ӵ��� "abc"���䳤��Ϊ 3
*/

//��������
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