/*
����һ���������飬����Ҫ��ԭ��ɾ���ظ����ֵ�Ԫ�أ�ʹ��ÿ��Ԫ�����������Σ������Ƴ���������³��ȡ�

��Ҫʹ�ö��������ռ䣬�������ԭ���޸��������鲢��ʹ�� O(1) ����ռ����������ɡ�

ʾ�� 1:

���� nums = [1,1,1,2,2,3],

����Ӧ�����³��� length = 5, ����ԭ�����ǰ���Ԫ�ر��޸�Ϊ 1, 1, 2, 2, 3 ��

�㲻��Ҫ���������г����³��Ⱥ����Ԫ�ء� 
 
*/
public class Solution {
    public int RemoveDuplicates ( int[] nums ) {
        if ( nums.Length == 0 ) {
            return 0;
        }
        int count = 0;
        int k = 0;
        for ( int i = 1 ;i < nums.Length ;i++ ) {
            if ( nums[k] == nums[i] ) {
                count++;
                if ( count < 2 ) {
                    nums[++k] = nums[i];
                }
            }
            else {
                nums[++k] = nums[i];
                count = 0;
            }
        }
        return k + 1;
    }
}