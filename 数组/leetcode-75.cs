public class Solution {
    //时间复杂度O(n)
    //空间复杂度O(1)
    //三路快排
    public void SortColors ( int[] nums ) {
        int zero = -1; //nums[0...zero] == 0;
        int two = nums.Length;//nums[two...nums.Length-1] == 2;
        for ( int i = 0 ;i < two ; ) {
            if ( nums[i] == 1 ) {
                i++;
            }
            else if ( nums[i] == 2 ) {
                two--;
                var temp = nums[i];
                nums[i] = nums[two];
                nums[two] = temp;
            }
            else {//nums[i] == 0;
                zero++;
                var temp = nums[i];
                nums[i] = nums[zero];
                nums[zero] = temp;
                i++;
            }
        }
    }
}
