/*
����һ�� pattern(ģʽ) ��һ���ַ��� str ���ж� str �Ƿ���ѭ��ͬ��ģʽ��

�������ѭָ��ȫƥ�䣬���磬 pattern ���ÿ����ĸ���ַ��� str �е�ÿ���ǿյ���֮�������˫�����ӵĶ�Ӧģʽ��

ʾ��1:

����: pattern = "abba", str = "dog cat cat dog"
���: true
ʾ�� 2:

����:pattern = "abba", str = "dog cat cat fish"
���: false
ʾ�� 3:

����: pattern = "aaaa", str = "dog cat cat dog"
���: false
ʾ�� 4:

����: pattern = "abba", str = "dog dog dog dog"
���: false
˵��:
����Լ��� pattern ֻ����Сд��ĸ�� str �������ɵ����ո�ָ���Сд��ĸ��
*/

using System;
using System.Collections.Generic;

public class Solution {
    public static void Main ( string[] args ) {
        Console.WriteLine ( WordPattern ( "abaa","cat dog cat cat" ) );
    }
    public static bool WordPattern ( string pattern,string str ) {
        List<char> listpattern = new List<char>();
        foreach ( var item in pattern ) {
            listpattern.Add ( item );
        }
        Dictionary<char,int> dictpattern = new Dictionary<char, int>();
        for ( int i = 0 ;i < listpattern.Count ;i++ ) {
            if ( dictpattern.ContainsKey ( listpattern[i] ) ) {
                dictpattern[listpattern[i]]++;
            }
            else {
                dictpattern.Add ( listpattern[i],1 );
            }
        }
        foreach ( var item in dictpattern ) {
            Console.WriteLine ( item );
        }
        List<string> liststr = new List<string>();
        var arraystr = str.Split ( ' ' );
        foreach ( var item in arraystr ) {
            liststr.Add ( item );
        }

        Dictionary<string,int> dictstr = new Dictionary<string, int>();
        for ( int i = 0 ;i < liststr.Count ;i++ ) {
            if ( dictstr.ContainsKey ( liststr[i] ) ) {
                dictstr[liststr[i]]++;
            }
            else {
                dictstr.Add ( liststr[i],1 );
            }
        }

        if ( listpattern.Count != liststr.Count ) {
            return false;
        }

        for ( int i = 0 ;i < listpattern.Count ;i++ ) {
            if ( dictpattern[listpattern[i]] != dictstr[liststr[i]] ) {
                return false;
            }
        }
        return true;
    }
}

