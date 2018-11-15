/*
给定两个数组，编写一个函数来计算它们的交集。

示例 1:

输入: nums1 = [1,2,2,1], nums2 = [2,2]
输出: [2]
示例 2:

输入: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
输出: [9,4]
说明:

输出结果中的每个元素一定是唯一的。
我们可以不考虑输出结果的顺序。
*/
using System.Collections.Generic;
using System.Collections;

public class Solution {
    public int[] Intersection ( int[] nums1,int[] nums2 ) {

        HashSet<int> vs = new HashSet<int>();
        //哈希表中不会添加重复元素
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