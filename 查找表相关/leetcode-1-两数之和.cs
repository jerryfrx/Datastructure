/*
给定一个整数数组和一个目标值，找出数组中和为目标值的两个数。

你可以假设每个输入只对应一种答案，且同样的元素不能被重复利用。

示例:

给定 nums = [2, 7, 11, 15], target = 9

因为 nums[0] + nums[1] = 2 + 7 = 9
所以返回[0,1]
*/
public class Solution {
    public int[] TwoSum ( int[] nums,int target ) {
        Dictionary<int,int> dict = new Dictionary<int, int>();
        for ( int i = 0 ;i < nums.Length ;i++ ) {
            int complement = target - nums[i];
            if ( dict.ContainsKey ( complement ) ) {
                int[] result = new int[] { dict[complement],i };
                return result;
            }
            if ( dict.ContainsKey ( nums[i] ) ) {
                //如果键值重复，则只更新所对应的value，即更新对应数组中的位置（下标）
                dict[nums[i]] = i;
            }
            else {
                dict.Add ( nums[i],i );
            }
        }
        return null;
    }
}