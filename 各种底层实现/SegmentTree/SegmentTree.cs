using System;
using System.Collections.Generic;
using System.Text;

//线段树，用数组实现
namespace SegmentTree {
    class Program{
        public static void Main(string[] args){
            int[] arr = { 9, 2, 5, 1, 7, 4, 19 };
            SegmentTree<int> segmentTree = new SegmentTree<int>(arr, (a, b) => a + b);
            Console.WriteLine(segmentTree);
        }
    }
    
    public delegate T Merge<T>(T a,T b);
    
    class SegmentTree<T> {
        private T[] data;
        private T[] tree;
        private Merge<T> merge;
        public SegmentTree ( T[] array,Merge<T> merge ) {
            data = new T[ array.Length ];
            for ( int i = 0 ;i < array.Length ;i++ ) {
                data[ i ] = array[ i ];
            }
            tree = new T[ array.Length * 4 ];
            this.merge = merge;
            //创建SegementTree
            _BuildSegmentTree ( treeIndex: 0,l: 0,r: data.Length - 1 );
        }
        //在treeIndex这个位置上创建表示区间[l...r]的线段树
        private void _BuildSegmentTree ( int treeIndex,int l,int r ) {
            if ( l == r ) {
                tree [ treeIndex ] = data [ l ];
                return;
            }
            int leftTreeIndex = _LeftChild(treeIndex);
            int rightTreeIndex = _RightChild(treeIndex);
            int mid = l+(r-l)/2;
            _BuildSegmentTree ( leftTreeIndex,l,mid );
            _BuildSegmentTree ( rightTreeIndex,mid + 1,r );
            tree[treeIndex] = merge( tree[leftTreeIndex],tree[rightTreeIndex] );
        }

        public int GetSize ( ) {
            return data.Length;
        }
        public T GetElement ( int index ) {
            if ( index < 0 || index >= data.Length ) {
                throw new Exception ( "Out of bounds" );
            }
            return data[ index ];
        }
        //辅助函数
        //返回完全二叉树的数组表示中，一个索引所表示的元素的左孩子节点的索引
        private int _LeftChild ( int index ) {
            return 2 * index + 1;
        }
        private int _RightChild ( int index ) {
            return 2 * index + 2;
        }
        //查询query[l,r]区间
        public T Query(int queryL,int queryR ) {
            if ( queryL < 0 || queryL >= data.Length || queryR < 0 || queryR >= data.Length || queryL > queryR ) {
                throw new Exception ( "Out of Bounds!" );
            }
            return _Query (0,0,data.Length-1,queryL,queryR);
        }
        //在以treeID为根的线段树中[l...r]的范围里，搜索区间[queryL...queryR]的值
        private T _Query(int treeIndex,int l,int r,int queryL,int queryR ) {
            if ( l == queryL && r == queryR ) {
                return tree[treeIndex];
            }
            int mid = l+(r-l)/2;
            int leftTreeIndex = _LeftChild(treeIndex);
            int rightTreeIndex = _RightChild(treeIndex);
            if ( queryL >= mid + 1 ) {
                return _Query ( rightTreeIndex,mid + 1,r,queryL,queryR );
            }
            else if(queryR<=mid) {
                return _Query ( leftTreeIndex,l,mid,queryL,queryR );
            }
            T leftResult = _Query ( leftTreeIndex,l,mid,queryL,mid );
            T rightResult = _Query( rightTreeIndex,mid+1,r,mid+1,queryR );
            return merger.Merge ( leftResult,rightResult );
        }
        public void SetElement( int index,T e ) {
            if ( index < 0 || index >= data.Length ) {
                throw new Exception ( "Out of Bounds!" );
            }
            data[index] = e;
            _SetElement ( 0,0,data.Length - 1,index,e );
        }
        //在以treeIndex为根的线段树中更新index的值为e
        private void _SetElement( int treeIndex,int l,int r,int index,T e ) {
            if ( l == r ) {
                tree[treeIndex] = e;
                return;
            }
            int mid = l+(r-l)/2;
            int leftTreeIndex = _LeftChild(treeIndex);
            int rightTreeIndex = _RightChild(treeIndex);
            if ( index >= mid + 1 ) {
                _SetElement ( rightTreeIndex,mid + 1,r,index,e );
            }
            else {
                _SetElement ( leftTreeIndex,l,mid,index,e );
            }
            tree[treeIndex] = merger.Merge ( tree[leftTreeIndex],tree[rightTreeIndex] );
        }
        public string ToString ( ) {
            StringBuilder res = new StringBuilder();
            res.Append ( '[' );
            for ( int i = 0 ;i < tree.Length ;i++ ) {
                if ( tree[i] != null ) {
                    res.Append ( tree[i] );
                }
                else {
                    res.Append ("null");
                }
                if ( i != tree.Length - 1 ) {
                    res.Append ( ", " );
                }
            }
            res.Append ( ']' );
            return res.ToString ( );
        }
    }
}
