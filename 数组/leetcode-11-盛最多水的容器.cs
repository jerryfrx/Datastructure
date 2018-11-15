public class Solution {
    public int MaxArea ( int[] height ) {
        int result = 0;
        int l = 0;
        int r = height.Length - 1;
        while ( l < r ) {
            int value = Math.Min(height[l],height[r])*(r-l);
            if ( result < value ) {
                result = value;
            }
            if ( height[l] < height[r] ) {
                l++;
            }
            else {
                r--;
            }
        }
        return result;
    }
}