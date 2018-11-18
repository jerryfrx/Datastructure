using System;
using System.Collections.Generic;
using System.Linq;

namespace AVLTree {
    class AVLTree<K, V> where K : IComparable<K> {
        private class Node {
            public K key;
            public V value;
            public Node left,right;
            public int height;
            public Node ( K key,V value ) {
                this.key = key;
                this.value = value;
                left = null;
                right = null;
                height = 1;
            }
        }
        private Node root;
        private int size;
        public AVLTree ( ) {
            root = null;
            size = 0;
        }
        public int GetSize ( ) {
            return size;
        }
        public bool IsEmpty ( ) {
            return size == 0;
        }
        //�жϸö������Ƿ���һ�Ŷ���������
        //����Ƕ�������������ô�������һ���ǰ���������
        public bool IsBST ( ) {
            List<K> keys = new List<K>();
            _InOrder ( root,keys );
            for ( int i = 1 ;i < keys.Count () ;i++ ) {
                if ( keys[i - 1].CompareTo ( keys[i] ) > 0 ) {
                    return false;
                }
            }
            return true;
        }
        private void _InOrder ( Node node,List<K> keys ) {
            if ( node == null ) {
                return;
            }
            _InOrder ( node.left,keys );
            keys.Add ( node.key );
            _InOrder ( node.right,keys );
        }
        //�ж��Ƿ���ƽ�������
        //����ÿһ���ڵ㣬�������������ĸ߶Ȳ�ܳ���1
        public bool IsBalanced ( ) {
            return _IsBalanced ( root );
        }
        private bool _IsBalanced ( Node node ) {
            if ( node == null ) {
                return true;
            }
            int balanceFactor = this.GetBalanceFactor(node);
            if ( Math.Abs ( balanceFactor ) > 1 ) {
                return false;
            }
            return _IsBalanced ( node.left ) && _IsBalanced ( node.right );
        }
        // ��ýڵ�node�ĸ߶�
        private int GetHeight ( Node node ) {
            if ( node == null )
                return 0;
            return node.height;
        }
        // ��ýڵ�node��ƽ������
        private int GetBalanceFactor ( Node node ) {
            if ( node == null )
                return 0;
            return GetHeight ( node.left ) - GetHeight ( node.right );
        }
        // �����������������µ�Ԫ��(key, value)
        public void Add ( K key,V value ) {
            root = Add ( root,key,value );
        }

        // ����nodeΪ���Ķ����������в���Ԫ��(key, value)���ݹ��㷨
        // ���ز����½ڵ������������ĸ�
        private Node Add ( Node node,K key,V value ) {

            if ( node == null ) {
                size++;
                return new Node ( key,value );
            }

            if ( key.CompareTo ( node.key ) < 0 )
                node.left = Add ( node.left,key,value );
            else if ( key.CompareTo ( node.key ) > 0 )
                node.right = Add ( node.right,key,value );
            else // key.CompareTo(node.key) == 0
                node.value = value;

            // ����height
            node.height = 1 + Math.Max ( GetHeight ( node.left ),GetHeight ( node.right ) );

            // ����ƽ������
            int balanceFactor = GetBalanceFactor(node);
            if ( Math.Abs ( balanceFactor ) > 1 )
                Console.WriteLine ( "unbalanced : " + balanceFactor );

            return node;
        }

        // ������nodeΪ���ڵ�Ķ����������У�key���ڵĽڵ�
        private Node GetNode ( Node node,K key ) {

            if ( node == null )
                return null;

            if ( key.Equals ( node.key ) )
                return node;
            else if ( key.CompareTo ( node.key ) < 0 )
                return GetNode ( node.left,key );
            else // if(key.CompareTo(node.key) > 0)
                return GetNode ( node.right,key );
        }

        public bool Contains ( K key ) {
            return GetNode ( root,key ) != null;
        }

        public V Get ( K key ) {

            Node node = GetNode(root, key);
            return node == null ? default ( V ) : node.value;
        }

        public void Set ( K key,V newValue ) {
            Node node = GetNode(root, key);
            if ( node == null )
                throw new Exception ( key + " doesn't exist!" );

            node.value = newValue;
        }

        // ������nodeΪ���Ķ�������������Сֵ���ڵĽڵ�
        private Node Minimum ( Node node ) {
            if ( node.left == null )
                return node;
            return Minimum ( node.left );
        }

        // ɾ������nodeΪ���Ķ����������е���С�ڵ�
        // ����ɾ���ڵ���µĶ����������ĸ�
        private Node RemoveMin ( Node node ) {

            if ( node.left == null ) {
                Node rightNode = node.right;
                node.right = null;
                size--;
                return rightNode;
            }

            node.left = RemoveMin ( node.left );
            return node;
        }

        // �Ӷ�����������ɾ����Ϊkey�Ľڵ�
        public V Remove ( K key ) {

            Node node = GetNode(root, key);
            if ( node != null ) {
                root = Remove ( root,key );
                return node.value;
            }
            return default ( V );
        }

        private Node Remove ( Node node,K key ) {

            if ( node == null )
                return null;

            if ( key.CompareTo ( node.key ) < 0 ) {
                node.left = Remove ( node.left,key );
                return node;
            }
            else if ( key.CompareTo ( node.key ) > 0 ) {
                node.right = Remove ( node.right,key );
                return node;
            }
            else {   // key.CompareTo(node.key) == 0

                // ��ɾ���ڵ�������Ϊ�յ����
                if ( node.left == null ) {
                    Node rightNode = node.right;
                    node.right = null;
                    size--;
                    return rightNode;
                }

                // ��ɾ���ڵ�������Ϊ�յ����
                if ( node.right == null ) {
                    Node leftNode = node.left;
                    node.left = null;
                    size--;
                    return leftNode;
                }

                // ��ɾ���ڵ�������������Ϊ�յ����

                // �ҵ��ȴ�ɾ���ڵ�����С�ڵ�, ����ɾ���ڵ�����������С�ڵ�
                // ������ڵ㶥���ɾ���ڵ��λ��
                Node successor = Minimum(node.right);
                successor.right = RemoveMin ( node.right );
                successor.left = node.left;

                node.left = node.right = null;

                return successor;
            }
        }
    }
}