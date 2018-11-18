using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray {
    class DynamicArray<T> where T:IComparable<T> {
        private T[] data;
        private int size;
        //传入capacity构造数组
        public DynamicArray ( int capacity ) {
            data = new T[capacity];
            size = 0;
        }
        public DynamicArray ( ) {
            data = new T[10];
            size = 0;
        }
        public int GetSize ( ) {
            return size;
        }
        public int GetCapacity ( ) {
            return data.Length;
        }
        public bool IsEmpty ( ) {
            return size == 0;
        }
        public void AddLast ( T e ) {
            //if ( size == data.Length ) {
            //    throw new Exception ( "Add failed! Out of bounds!" );
            //}
            //data[size] = e;
            //size++;
            AddIndex ( size,e );
        }
        public void AddFirst ( T e ) {
            AddIndex ( 0,e );
        }
        //在index位置插入元素e
        public void AddIndex ( int index,T e ) {
            if ( index < 0 && index > size ) {
                throw new Exception ( "Add failed! Out of Size" );
            }
            if ( size == data.Length ) {
                this._Resize ( 2 * data.Length );
            }
            for ( int i = size - 1 ;i >= index ;i-- ) {
                data[i + 1] = data[i];
            }
            data[index] = e;
            size++;
        }
        //获取index索引位置的元素
        public T GetData ( int index ) {
            if ( index < 0 || index >= size ) {
                throw new Exception ( "ERROR!OUT OF BOUNDS!" );
            }
            return data[index];
        }
        public T GetFirstData ( ) {
            return GetData ( 0 );
        }
        public T GetLastData ( ) {
            return GetData ( size - 1 );
        }
        public void SetData ( int index,T e ) {
            if ( index < 0 || index >= size ) {
                throw new Exception ( "ERROR!OUT OF BOUNDS!" );
            }
            data[index] = e;
        }
        public bool Contains ( T e ) {
            for ( int i = 0 ;i < size ;i++ ) {
                if ( data[i].CompareTo ( e ) == 0 ) {
                    return true;
                }
            }
            return false;
        }
        //返回查找元素的索引
        public int Find ( T e ) {
            for ( int i = 0 ;i < size ;i++ ) {
                if ( data[i].CompareTo ( e ) == 0 ) {
                    return i;
                }
            }
            return -1;
        }
        //从数组中删除元素,并且返回删除的元素
        public T Remove ( int index ) {
            if ( index < 0 || index >= size ) {
                throw new Exception ( "ERROR!OUT OF BOUNDS!" );
            }
            T result = data[index];
            for ( int i = index + 1 ;i < size ;i++ ) {
                data[i - 1] = data[i];
            }
            size--;
            data[size] = default ( T );//让系统回收，不能像Java一样设置为空

            //缩容
            //当元素删除到一定的时候，减小数组容量
            if ( size == data.Length / 2 ) {
                _Resize ( data.Length / 2 );
            }
            return result;
        }
        public T RemoveFirst ( ) {
            return Remove ( 0 );
        }
        public T RemoveLast ( ) {
            return Remove ( size - 1 );
        }
        public void RemoveAllElement ( T e ) {
            bool flag = false;
            for ( int i = 0 ;i < size ;i++ ) {
                if ( data[i].CompareTo ( e ) == 0 ) {
                    this.Remove ( i );
                    flag = true;
                    Console.WriteLine ( $"Remove {e} complete!" );
                }
            }
            if ( !flag ) {
                Console.WriteLine ( $"There is no {e}" );
            }
        }

        //扩容
        private void _Resize ( int newCapacity ) {
            T[] newData = new T[newCapacity];
            for ( int i = 0 ;i < size ;i++ ) {
                newData[i] = data[i];
            }
            data = newData;
        }

        //覆写ToString方法
        public override string ToString ( ) {
            StringBuilder result = new StringBuilder();
            result.Append ( String.Format ( $"MyArray:size={size},capacity={data.Length}\n" ) );
            result.Append ( '[' );
            for ( int i = 0 ;i < size ;i++ ) {
                result.Append ( data[i] );
                if ( i != size - 1 ) {
                    result.Append ( ", " );
                }
            }
            result.Append ( ']' );
            return result.ToString ();
        }
    }
}
