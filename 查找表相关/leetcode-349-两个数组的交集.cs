/*
�����������飬��дһ���������������ǵĽ�����

ʾ�� 1:

����: nums1 = [1,2,2,1], nums2 = [2,2]
���: [2]
ʾ�� 2:

����: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
���: [9,4]
˵��:

�������е�ÿ��Ԫ��һ����Ψһ�ġ�
���ǿ��Բ�������������˳��
*/
using System.Collections.Generic;
using System.Collections;

public class Solution {
    public int[] Intersection ( int[] nums1,int[] nums2 ) {

        HashSet<int> vs = new HashSet<int>();
        //��ϣ���в�������ظ�Ԫ��
        foreach ( var item in nums1 ) {
            vs.Add ( item );
        }
        List<int> list = new List<int>();
        foreach ( var item in nums2 ) {
            if ( vs.Contains ( item ) ) {
                list.Add ( item );
                vs.Remove ( item );
            }
        }
        return list.ToArray ();
    }
}