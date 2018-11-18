using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicArray;

namespace Queue {
    class ArrayQueue<T>:IArrayQueue<T> where T:IComparable<T> {
        private DynamicArray<T> array;
        public ArrayQueue ( int capacity ) {
            array = new DynamicArray<T> ( capacity );
        }
        public ArrayQueue ( ) {
            array = new DynamicArray<T> ();
        }

        public int GetSize ( ) {
            return array.GetSize ();
        }

        public bool IsEmpty ( ) {
            return array.IsEmpty ();
        }

        public void EnQueue ( T e ) {
            array.AddLast ( e );
        }

        public T Dequeue ( ) {
            return array.RemoveFirst ();
        }

        public T GetFront ( ) {
            return array.GetFirstData ();
        }
        public int GetCapacity ( ) {
            return array.GetCapacity ();
        }
        public override string ToString ( ) {
            StringBuilder result = new StringBuilder();
            result.Append ( $"Queue: capacity = {array.GetCapacity()}...size = {array.GetSize()}\n" );
            result.Append ( "Top - [" );
            for ( int i = 0 ;i < array.GetSize() ;i++ ) {
                result.Append ( array.GetData(i) );
                if ( i != array.GetSize () - 1 ) {
                    result.Append ( ", " );
                }
            }
            result.Append ( "] Tail" );
            return result.ToString ();
        }
    }
}
