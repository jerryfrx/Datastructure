using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicArray;

namespace Stack {
    class ArrayStack<T> : IStack<T> where T : IComparable<T> {
        private DynamicArray<T> array;
        public ArrayStack(int capacity ) {
            array = new DynamicArray<T> ( capacity );
        }
        public ArrayStack ( ) {
            array = new DynamicArray<T> ();
        }

        public void Push ( T e ) {
            array.AddLast ( e );
        }

        public T Pop ( ) {
            return array.RemoveLast ();
        }

        //查看栈顶元素
        public T Peek ( ) {
            return array.GetLastData ();
        }

        public int GetSize ( ) {
            return array.GetSize ();
        }

        public bool IsEmpty ( ) {
            return array.IsEmpty ();
        }

        public int GetCapacity ( ) {
            return array.GetCapacity ();
        }

        public override string ToString ( ) {
            StringBuilder result = new StringBuilder();
            result.Append ( "Stack:" );
            result.Append ( "[" );
            for ( int i = 0 ;i < array.GetSize() ;i++ ) {
                result.Append ( array.GetData ( i ) );
                if ( i != array.GetSize() - 1 ) {
                    result.Append ( ", " );
                }
            }
            result.Append ("] top");
            return result.ToString ();
        }
    }
}
