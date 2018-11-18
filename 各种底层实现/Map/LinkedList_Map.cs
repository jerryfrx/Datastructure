using System;
using Map;

//用链表实现Map
namespace LinkedListMap {
    class LinkedListMap<K, V> : IMap<K,V> {
        private class Node {
            public K key;
            public V value;
            public Node next;
            public Node ( K key,V value,Node next ) {
                this.key = key;
                this.value = value;
                this.next = next;
            }
            public Node ( K key ) {
                this.key = key;
                this.value = default ( V );
                this.next = null;
            }
            public Node ( ) {
                this.key = default ( K );
                this.value = default ( V );
                this.next = null;
            }
            public String ToString ( ) {
                return key.ToString () + ":" + value.ToString ();
            }
        }
        private Node dummyNode;
        private int size;
        public LinkedListMap ( ) {
            dummyNode = new Node ();
            size = 0;
        }
        //辅助方法
        private Node GetNode ( K key ) {
            Node current = dummyNode.next;
            while ( current != null ) {
                if ( current.key.Equals ( key ) ) {
                    return current;
                }
                current = current.next;
            }
            return null;
        }
        public void Add ( K key,V value ) {
            //key不能重复，所以先确定传进来的key有无对应的value
            Node node = this.GetNode(key);
            if ( node == null ) {
                dummyNode.next = new Node ( key,value,dummyNode.next );
                size++;
            }
            else {//更新数据
                node.value = value;
            }
        }

        public bool Contains ( K key ) {
            return this.GetNode ( key ) != null;
        }

        public V GetElement ( K key ) {
            Node node = this.GetNode(key);
            return node == null ? default ( V ) : node.value;
        }

        public int GetSize ( ) {
            return size;
        }

        public bool IsEmpty ( ) {
            return size == 0;
        }

        public V Remove ( K key ) {
            Node prev = dummyNode;
            while ( prev.next != null ) {
                if ( prev.next.key.Equals ( key ) ) {
                    break;
                }
                prev = prev.next;
            }
            if ( prev.next != null ) {
                Node delnode = prev.next;
                prev.next = delnode.next;
                delnode.next = null;
                size--;
                return delnode.value;
            }
            else {
                return default ( V );
            }
        }

        public void SetElement ( K key,V value ) {
            Node node = this.GetNode(key);
            if ( node == null ) {
                throw new Exception ( $"key {key} dosen't exist" );
            }
            node.value = value;
        }
    }
}