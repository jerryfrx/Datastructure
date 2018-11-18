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
        //判断该二叉树是否是一颗二分搜索树
        //如果是二分搜索树，那么中序遍历一定是按升序排列
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
        //判断是否是平衡二叉树
        //对于每一个节点，它的左右子树的高度差不能超过1
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
        // 获得节点node的高度
        private int GetHeight ( Node node ) {
            if ( node == null )
                return 0;
            return node.height;
        }
        // 获得节点node的平衡因子
        private int GetBalanceFactor ( Node node ) {
            if ( node == null )
                return 0;
            return GetHeight ( node.left ) - GetHeight ( node.right );
        }
        // 向二分搜索树中添加新的元素(key, value)
        public void Add ( K key,V value ) {
            root = Add ( root,key,value );
        }

        // 向以node为根的二分搜索树中插入元素(key, value)，递归算法
        // 返回插入新节点后二分搜索树的根
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

            // 更新height
            node.height = 1 + Math.Max ( GetHeight ( node.left ),GetHeight ( node.right ) );

            // 计算平衡因子
            int balanceFactor = GetBalanceFactor(node);
            if ( Math.Abs ( balanceFactor ) > 1 )
                Console.WriteLine ( "unbalanced : " + balanceFactor );

            return node;
        }

        // 返回以node为根节点的二分搜索树中，key所在的节点
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

        // 返回以node为根的二分搜索树的最小值所在的节点
        private Node Minimum ( Node node ) {
            if ( node.left == null )
                return node;
            return Minimum ( node.left );
        }

        // 删除掉以node为根的二分搜索树中的最小节点
        // 返回删除节点后新的二分搜索树的根
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

        // 从二分搜索树中删除键为key的节点
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

                // 待删除节点左子树为空的情况
                if ( node.left == null ) {
                    Node rightNode = node.right;
                    node.right = null;
                    size--;
                    return rightNode;
                }

                // 待删除节点右子树为空的情况
                if ( node.right == null ) {
                    Node leftNode = node.left;
                    node.left = null;
                    size--;
                    return leftNode;
                }

                // 待删除节点左右子树均不为空的情况

                // 找到比待删除节点大的最小节点, 即待删除节点右子树的最小节点
                // 用这个节点顶替待删除节点的位置
                Node successor = Minimum(node.right);
                successor.right = RemoveMin ( node.right );
                successor.left = node.left;

                node.left = node.right = null;

                return successor;
            }
        }
    }
}