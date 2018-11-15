/*
�����������飬��дһ���������������ǵĽ�����

ʾ�� 1:

����: nums1 = [1,2,2,1], nums2 = [2,2]
���: [2,2]
ʾ�� 2:

����: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
���: [4,9]
˵����

��������ÿ��Ԫ�س��ֵĴ�����Ӧ��Ԫ�������������г��ֵĴ���һ�¡�
���ǿ��Բ�������������˳��
����:

��������������Ѿ��ź����أ��㽫����Ż�����㷨��
��� nums1 �Ĵ�С�� nums2 С�ܶ࣬���ַ������ţ�
��� nums2 ��Ԫ�ش洢�ڴ����ϣ������ڴ������޵ģ������㲻��һ�μ������е�Ԫ�ص��ڴ��У������ô�죿
*/


using System;
using System.Collections.Generic;

public class Solution {
    public static void Main ( string[] args ) {
        int[] array = Intersect(new int[]{1,2,2,1},new int[]{2,2});
        foreach ( var item in array ) {
            Console.WriteLine ( item );
        }
    }
    public static int[] Intersect ( int[] nums1,int[] nums2 ) {
        Dictionary<int,int> dict = new Dictionary<int, int>();
        foreach ( var item in nums1 ) {
            if ( dict.ContainsKey ( item ) ) {
                dict[item]++;
            }
            else {
                dict.Add ( item,1 );
            }
        }
        List<int> list = new List<int>();

        foreach ( var item in nums2 ) {
            if ( dict.ContainsKey ( item ) && dict[item] > 0 ) {
                list.Add ( item );
                dict[item]--;
            }
        }
        return list.ToArray ();
    }
}