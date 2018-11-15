//a e i o u
public class Solution {
    public static void Main ( string[] args ) {
        Console.WriteLine ( ReverseVowels ( "aeiou" ) );
    }
    public static string ReverseVowels ( string s ) {
        char[] array = s.ToArray();
        string vowels = "aeiouAEIOU";
        int l = 0;
        int r = array.Length-1;
        int count = 0;
        while ( l < r ) {
            if ( vowels.Contains ( array[l] ) && vowels.Contains ( array[r] ) ) {
                var temp = array[l];
                array[l] = array[r];
                array[r] = temp;
                l++;
                r--;
            }
            else if ( vowels.Contains ( array[l] ) && !vowels.Contains ( array[r] ) ) {
                r--;
            }
            else {
                l++;
            }
        }
        s = new string ( array );
        return s;
    }
}
