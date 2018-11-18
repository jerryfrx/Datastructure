using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue {
    class LoopQueue<T>:IArrayQueue<T> where T : IComparable<T> {
        private T[] data;
        private int front,tail;
        private int size;
        public LoopQueue(int capacity ) {
            //循环队列里面会有意识的浪费一个空间
            //如果front == tail，队列为空
            //如果(tail+1)%data.Length == front ,队列为满
            data = new T[capacity+1];
            front = 0;
            tail = 0;
            size = 0;
        }
        public LoopQueue ( ) : this ( 10 ) { }
        
        //因为浪费了一个空间，所以真正承载的容量需要 -1
        public int GetCapacity ( ) {
            return data.Length - 1;
        }

        public int GetSize ( ) {
            return size;
        }

        public bool IsEmpty ( ) {
            return front == tail;
        }

        public void EnQueue ( T e ) {
            //先判断队列是否为满
            if ( ( tail + 1 ) % data.Length == front ) {
                _Resize (this.GetCapacity()*2);
            }
            data[tail] = e;
            tail = ( tail + 1 ) % data.Length;
            size++;
        }
        private void _Resize(int newCapacity ) {
            T[] newData = new T[newCapacity+1];
            for ( int i = 0 ;i < size ;i++ ) {
                //有可能front不在0的位置,因为是循环队列，有可能越界,所以要对data.Length取模
                newData[i] = data[(front + i) % data.Length];
            }
            data = newData;
            front = 0;
            tail = size;
        }

        public T Dequeue ( ) {
            if ( this.IsEmpty () ) {
                throw new Exception ("Empty Queue!");
            }
            T result = data[front];
            //让系统回收
            data[front] = default ( T );
            front = ( front + 1 ) % data.Length;
            size--;
            if(size == GetCapacity () / 4 && GetCapacity() / 2 != 0 ) {
                _Resize ( GetCapacity () / 2 );
            }
            return result;
        }

        public T GetFront ( ) {
            if ( IsEmpty () ) {
                throw new Exception ( "Empty Queue!" );
            }
            return data[front];
        }

        public override string ToString ( ) {
            StringBuilder result = new StringBuilder();
            result.Append ( $"LoopQueue: size = {size} , capacity = {GetCapacity ()}\n" );
            result.Append("Front - [");
            for ( int i = front ;i != tail ;i = (i+1)%data.Length ) {
                result.Append ( data[i] );
                if ( ( i + 1 ) % data.Length != tail ) {
                    result.Append ( ", " );
                }
            }
            result.Append ( "] - Tail" );
            return result.ToString ();
        }
    }
}
