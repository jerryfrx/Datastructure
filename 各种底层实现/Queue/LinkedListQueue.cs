using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue {
    class LinkedListQueue<T> : IArrayQueue<T> where T : IComparable<T> {
        private class Node {
            public T e;
            public Node next;
            public Node( T e,Node next ) {
                this.e = e;
                this.next = next;
            }
            public Node( T e ) : this ( e,null ) { }
            public Node ( ) : this ( default ( T ),null ) { }
            public override string ToString ( ) {
                return e.ToString ();
            }
        }
        private Node head,tail;
        private int size;
        public LinkedListQueue ( ) {
            head = null;
            tail = null;
            size = 0;
        }
        public void EnQueue ( T e ) {
            //如果尾为空，那么链表一定为空，因为当链表有元素时，tail指向最后一个元素，一定不为空
            if ( tail == null ) {
                tail = new Node ( e );
                head = tail;
            }
            else {
                tail.next = new Node ( e );
                tail = tail.next;
            }
            size++;
        }
        public T Dequeue ( ) {
            if ( IsEmpty () ) {
                throw new Exception ( "Empty Queue!" );
            }
            Node retNode = head;
            head = head.next;
            retNode.next = null;
            if ( head == null ) {
                tail = null;
            }
            size--;
            return retNode.e;
        }

        public T GetFront ( ) {
            if ( IsEmpty () ) {
                throw new Exception ( "Empty Queue!" );
            }
            return head.e;
        }

        public int GetSize ( ) {
            return size;
        }

        public bool IsEmpty ( ) {
            return size == 0;
        }
        public override string ToString ( ) {
            StringBuilder result = new StringBuilder();
            result.Append ( "LinkedListQueue : FRONT " );
            Node current = head;
            while ( current != null ) {
                result.Append ( current.e + "--->" );
                current = current.next;
            }
            result.Append ( " NULL Tail" );
            return result.ToString ();
        }
    }
}
