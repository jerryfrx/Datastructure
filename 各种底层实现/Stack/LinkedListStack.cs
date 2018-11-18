using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Link_List;

namespace Stack {
    class LinkedListStack<T>:IStack<T> where T:IComparable<T> {
        private Link_List.LinkedList<T> linkedlist;
        public LinkedListStack ( ) {
            linkedlist = new Link_List.LinkedList<T> ();
        }
        public int GetSize ( ) {
            return linkedlist.GetSize ();
        }
        public bool IsEmpty ( ) {
            return linkedlist.IsEmpty ();
        }

        public T Peek ( ) {
            return linkedlist.GetFirst ();
        }

        public T Pop ( ) {
            return linkedlist.RemoveFirst ();
        }

        public void Push( T e ) {
            linkedlist.AddFirst ( e );
        }

        public override string ToString ( ) {
            StringBuilder result = new StringBuilder();
            result.Append ( "Stack : Top" );
            result.Append ( linkedlist );
            return result.ToString ();
        }
    }
}
