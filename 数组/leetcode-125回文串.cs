using System.Text.RegularExpressions;
public class Solution {
    public bool IsPalindrome ( string s ) {
        s = s.ToLower ();
        s = Regex.Replace ( s,"[^a-z0-9]","" );
        int l = 0;
        int r = s.Length - 1;
        while ( l < r ) {
            if ( s[l] != s[r] ) {

                return false;
            }
            l++;
            r--;
        }
        return true;
    }
}