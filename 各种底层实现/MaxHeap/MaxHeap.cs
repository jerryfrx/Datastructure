using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 最大堆
//用数组实现时：1、当以1开始遍历时 2、当以0开始遍历时
//1、parent(i) = i/2    left_child(i) = 2*i   right_child(i) = 2*i+1
//2、parent(i) = (i-1)/2    left_child(i) = 2*i+1   right_child(i) = 2*i+2
namespace MaxHeap {
    public class MaxHeap<T> where T : IComparable<T> {
        private List<T> data;
        public MaxHeap ( int capacity ) {
            data = new List<T> ( capacity );
        }
        public MaxHeap ( ) {
            data = new List<T> ();
        }
        //返回堆中元素个数
        public int Size ( ) {
            return data.Count ();
        }
        //是否为空
        public bool IsEmpty ( ) {
            return data.Count () == 0;
        }
        public T RetKValue ( int k ) {
            return data[k - 1];
        }
        //设置三个私有的辅助方法
        //返回完全二叉树的数组表示中，一个索引所表示的元素的父亲节点的索引
        private int Parent ( int index ) {
            if ( index == 0 ) {
                //throw new Exception("error");
                return 0;
            }
            return ( index - 1 ) / 2;
        }
        //返回完全二叉树的数组表示中，一个索引所表示的元素的左孩子节点的索引
        private int LeftChild ( int index ) {
            return index * 2 + 1;
        }
        //返回完全二叉树的数组表示中，一个索引所表示的元素的右孩子节点的索引
        private int RightChild ( int index ) {
            return index * 2 + 2;
        }
        //向堆中添加元素
        public void AddElement ( T e ) {
            data.Add ( e );
            _SiftUp ( data.Count () - 1 );
        }
        //插入堆
        private void _SiftUp ( int k ) {
            while ( k > 0 && data[this.Parent ( k )].CompareTo ( data[k] ) < 0 ) {
                if ( Parent ( k ) < 0 || Parent ( k ) >= data.Count () || k < 0 || k >= data.Count () ) {
                    throw new Exception ( "out of bounds" );
                }
                var temp = data[k];
                data[k] = data[this.Parent ( k )];
                data[Parent ( k )] = temp;
                k = this.Parent ( k );
            }
        }
        //堆中最大的元素
        public T FindMax ( ) {
            if ( data.Count () == 0 ) {
                throw new Exception ( "empty data" );
            }
            return data[0];
        }
        //取出堆中最大元素
        public T ExtractMax ( ) {
            T result = FindMax();
            //将0这个位置的元素和堆中最后一个元素交换位置，然后删除
            data[0] = data[data.Count () - 1];
            data.RemoveAt ( data.Count () - 1 );
            _SiftDown ( 0 );
            return result;
        }
        private void _SiftDown ( int k ) {
            while ( LeftChild ( k ) < data.Count () ) {
                int j = LeftChild(k);
                if ( j + 1 < data.Count () && data[j + 1].CompareTo ( data[j] ) > 0 ) {
                    j = RightChild ( k );
                    //data[j]是LeftChild和RightChild中的最大值
                }
                if ( data[k].CompareTo ( data[j] ) >= 0 ) {
                    break;
                }
                var temp = data[k];
                data[k] = data[j];
                data[j] = temp;
                k = j;
            }
        }
        //
        public T ReplaceElement ( T e ) {
            T result = FindMax();
            data[0] = e;
            _SiftDown ( 0 );
            return result;
        }
        //heapify 将任意数组整理成堆的形状
        public MaxHeap ( T[] arr ) {
            data = new List<T> ( arr );
            for ( int i = this.Parent ( arr.Length - 1 ) ;i >= 0 ;i-- ) {
                _SiftDown ( i );
            }
        }
    }
}









