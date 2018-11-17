/*
����һ��ֻ���� '('��')'��'{'��'}'��'['��']' ���ַ������ж��ַ����Ƿ���Ч��

��Ч�ַ��������㣺

�����ű�������ͬ���͵������űպϡ�
�����ű�������ȷ��˳��պϡ�
ע����ַ����ɱ���Ϊ����Ч�ַ�����

ʾ�� 1:

����: "()"
���: true
ʾ�� 2:

����: "()[]{}"
���: true
ʾ�� 3:

����: "(]"
���: false
ʾ�� 4:

����: "([)]"
���: false
ʾ�� 5:

����: "{[]}"
���: true
*/
public class Solution {
    public bool IsValid ( string s ) {
        Stack<char> stack = new Stack<char>();
        for ( int i = 0 ;i < s.Length ;i++ ) {
            char c = s[i];
            if ( c == '[' || c == '{' || c == '(' ) {
                stack.Push ( c );
            }
            else {
                if ( stack.Count == 0 ) {
                    return false;
                }
                if ( c == ']' && stack.Pop () != '[' ) {
                    return false;
                }
                if ( c == '}' && stack.Pop () != '{' ) {
                    return false;
                }
                if ( c == ')' && stack.Pop () != '(' ) {
                    return false;
                }
            }
        }
        if ( stack.Count == 0 ) {
            return true;
        }
        else {
            return false;
        }
    }
}