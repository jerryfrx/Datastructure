using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map;

//基于二分搜索树实现Map
namespace Map {
    public class BSTMap<K, V> : IMap<K,V> where K : IComparable<K> {
        private class Node {
            public K key;
            public V value;
            public Node left,right;
            public Node ( K key,V value ) {
                this.key = key;
                this.value = value;
                this.left = null;
                this.right = null;
            }
        }
        private Node root;
        private int size;
        public BSTMap ( ) {
            root = null;
            size = 0;
        }

        //递归方法
        public void Add ( K key,V value ) {
            root = _Add ( root,key,value );
        }
        private Node _Add ( Node node,K key,V value ) {
            if ( node == null ) {
                size++;
                return new Node ( key,value );
            }
            if ( key.CompareTo ( node.key ) < 0 ) {
                node.left = _Add ( node.left,key,value );
            }
            else if ( key.CompareTo ( node.key ) > 0 ) {
                node.right = _Add ( node.right,key,value );
            }
            else {//key.CompareTo(node.key) == 0
                node.value = value;
            }
            return node;
        }
        public bool Contains ( K key ) {
            return _GetNode ( root,key ) != null;
        }

        //辅助方法,递归方法
        private Node _GetNode ( Node node,K key ) {
            if ( node == null ) {
                return null;
            }
            if ( key.CompareTo ( node.key ) == 0 ) {
                return node;
            }
            else if ( key.CompareTo ( node.key ) < 0 ) {
                return _GetNode ( node.left,key );
            }
            else {
                return _GetNode ( node.right,key );
            }
        }
        public V GetElement ( K key ) {
            Node node = _GetNode(root,key);
            return node == null ? default ( V ) : node.value;
        }

        public int GetSize ( ) {
            return size;
        }

        public bool IsEmpty ( ) {
            return size == 0;
        }

        //辅助方法
        private Node _Minimum ( Node node ) {
            if ( node.left == null ) {
                return node;
            }
            return _Minimum ( node.left );
        }
        private Node _RemoveMin ( Node node ) {
            if ( node.left == null ) {
                Node rightNode = node.right;
                node.right = null;
                size--;
                return rightNode;
            }
            node.left = _RemoveMin ( node.left );
            return node;
        }
        public V Remove ( K key ) {
            Node node = _GetNode(root,key);
            if ( node != null ) {
                root = _Remove ( root,key );
                return node.value;
            }
            return default ( V );
        }
        private Node _Remove ( Node node,K key ) {
            if ( node == null ) {
                return null;
            }
            if ( key.CompareTo ( node.key ) < 0 ) {
                node.left = _Remove ( node.left,key );
                return node;
            }
            else if ( key.CompareTo ( node.key ) > 0 ) {
                node.right = _Remove ( node.right,key );
                return node;
            }
            else {//key.CompareTo(node.key) == 0
                if ( node.left == null ) {
                    Node rightnode = node.right;
                    node.right = null;
                    size--;
                    return rightnode;
                }
                if ( node.right == null ) {
                    Node leftnode = node.left;
                    node.left = null;
                    size--;
                    return leftnode;
                }
                Node successor = _Minimum(node.right);
                successor.right = _RemoveMin ( node.right );
                successor.left = node.left;
                node.left = node.right = null;
                return successor;
            }
        }
        //更新key所在结点的value值
        public void SetElement ( K key,V newvalue ) {
            Node node = _GetNode(root,key);
            if ( node == null ) {
                throw new Exception ( $"key {key} dosen't exist!" );
            }
            node.value = newvalue;
        }
    }
}
