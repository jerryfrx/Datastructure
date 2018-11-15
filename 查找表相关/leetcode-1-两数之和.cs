/*
����һ�����������һ��Ŀ��ֵ���ҳ������к�ΪĿ��ֵ����������

����Լ���ÿ������ֻ��Ӧһ�ִ𰸣���ͬ����Ԫ�ز��ܱ��ظ����á�

ʾ��:

���� nums = [2, 7, 11, 15], target = 9

��Ϊ nums[0] + nums[1] = 2 + 7 = 9
���Է���[0,1]
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
                //�����ֵ�ظ�����ֻ��������Ӧ��value�������¶�Ӧ�����е�λ�ã��±꣩
                dict[nums[i]] = i;
            }
            else {
                dict.Add ( nums[i],i );
            }
        }
        return null;
    }
}