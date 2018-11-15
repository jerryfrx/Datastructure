/*
���������ַ��� s �� t ����дһ���������ж� t �Ƿ��� s ��һ����ĸ��λ�ʡ�

ʾ�� 1:

����: s = "anagram", t = "nagaram"
���: true
ʾ�� 2:

����: s = "rat", t = "car"
���: false
˵��:
����Լ����ַ���ֻ����Сд��ĸ��
*/


public class Solution {
    public bool IsAnagram ( string s,string t ) {
        Dictionary<char,int> dictS = new Dictionary<char, int>();
        Dictionary<char,int> dictT = new Dictionary<char, int>();

        foreach ( var item in s ) {
            if ( dictS.ContainsKey ( item ) ) {
                dictS[item]++;
            }
            else {
                dictS.Add ( item,1 );
            }
        }
        foreach ( var item in t ) {
            if ( dictT.ContainsKey ( item ) ) {
                dictT[item]++;
            }
            else {
                dictT.Add ( item,1 );
            }
        }
        if ( s.Length != t.Length ) {
            return false;
        }

        foreach ( var item in s ) {
            if ( !dictT.ContainsKey ( item ) || dictS[item] != dictT[item] ) {
                return false;
            }
        }
        return true;
    }
}
