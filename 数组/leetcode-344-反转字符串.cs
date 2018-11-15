public class Solution {
    public string ReverseString(string s) {
        int l = 0;
        int r = s.Length-1;
        char[] array = s.ToArray();
        while ( l < r ) {
            var temp = array[l];
            array[l] = array[r];
            array[r] = temp;
            l++;
            r--;
        }
        s = new string(array);
        return s;
    }
}