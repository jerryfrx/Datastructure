using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link_List {
    class LinkedList<T> {
        private class Node {
            public Node next;
            public T e;
            public Node ( T e,Node next ) {
                this.e = e;
                this.next = next;
            }
            public Node ( T e ) : this ( e,null ) { }
            public Node ( ) : this ( default ( T ),null ) { }
            public override string ToString ( ) {
                return e.ToString ();
            }
        }
        private Node dummyhead;
        private int size;
        public LinkedList ( ) {
            dummyhead = new Node ( default ( T ),null );
            size = 0;
        }
        //获取链表中元素个数
        public int GetSize ( ) {
            return size;
        }
        //返回链表是否为空
        public bool IsEmpty ( ) {
            return size == 0;
        }
        //在链表index(0-based)处添加元素e
        public void AddIndex ( T e,int index ) {
            if ( index < 0 && index >= size ) {
                throw new Exception ( "Out of Bounds!" );
            }
            //注意，由于prev初始指向dummyhead，所以这里 i<index 而不是 i<index-1
            Node prev = dummyhead;
            for ( int i = 0 ;i < index ;i++ ) {
                prev = prev.next;
            }
            Node node = new Node(e); 
            node.next = prev.next;
            prev.next = node;
            size++;
        }
        //在链表头添加元素e
        public void AddFirst ( T e ) {
            AddIndex ( e,0 );
        }
        //在链表末尾添加元素e
        public void AddLast ( T e ) {
            AddIndex ( e,size );
        }
        //获得链表中index（0--based）位置的元素
        public T GetIndexData( int index ) {
            if ( index < 0 && index >= size ) {
                throw new Exception ( "Out of Bounds!" );
            }
            Node current = dummyhead.next;
            for ( int i = 0 ;i < index ;i++ ) {
                current = current.next;
            }
            return current.e;
        }
        //获得链表第一个元素
        public T GetFirst ( ) {
            return GetIndexData ( 0 );
        }
        //获得链表最后一个元素
        public T GetLast ( ) {
            return GetIndexData ( size - 1 );
        }
        //修改链表index(0-based)位置的元素
        public void SetIndexData( int index,T e ) {
            if ( index < 0 && index >= size ) {
                throw new Exception ( "OUT OF BOUNDS!" );
            }
            Node current = dummyhead.next;
            for ( int i = 0 ;i < index ;i++ ) {
                current = current.next;
            }
            current.e = e;
        }
        //查找链表中是否有e
        public bool Contains ( T e ) {
            Node current = dummyhead.next;
            while ( current != null ) {
                if(current.e.Equals(e)) {
                    return true;
                }
                current = current.next;
            }
            return false;
        }
        
        //从链表中删除index（0-based）位置的元素，返回删除的元素
        public T RemoveIndexData( int index ) {
            if ( index < 0 && index >= size ) {
                throw new Exception ( "OUT OF BOUNDS!" );
            }
            Node prev = dummyhead;
            for ( int i = 0 ;i < index ;i++ ) {
                prev = prev.next;
            }
            Node delnode = prev.next;
            prev.next = delnode.next;
            delnode.next = null;
            size--;
            return delnode.e;
        }
        public T RemoveFirst ( ) {
            return RemoveIndexData ( 0 );
        } 
        public T RemoveLast ( ) {
            return RemoveIndexData ( size - 1 );
        }

        public override string ToString ( ) {
            StringBuilder result = new StringBuilder();
            result.Append ( $"LinkedList: size = {size}\n" );
            Node current = dummyhead.next;
            while ( current != null ) {
                result.Append ( current.e + "-->" );
                current = current.next;
            }
            result.Append ( "null" );
            return result.ToString ();
        }
    }
}
