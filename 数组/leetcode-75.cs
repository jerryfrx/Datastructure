public class Solution {
    //ʱ�临�Ӷ�O(n)
    //�ռ临�Ӷ�O(1)
    //��·����
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
