using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionFind {
    class UnionFind_Three : IUF {
        private int[] parent;
        private int[] sz;//sz[i]表示以i为根的集合中元素个数
        public UnionFind_Three ( int size ) {
            parent = new int[size];
            sz = new int[size];
            for ( int i = 0 ;i < size ;i++ ) {
                parent[i] = i;
                sz[i] = 1;
            }
        }

        public int GetSize ( ) {
            return parent.Length;
        }
        //查找过程，查找元素p所对应的集合编号--根节点
        //O（h）复杂度，h为树的高度
        private int Find ( int p ) {
            if ( p < 0 && p >= parent.Length ) {
                throw new Exception ( "out of bounds!" );
            }
            while ( p != parent[p] ) {
                p = parent[p];
            }
            return p;
        }

        public bool IsConnected ( int p,int q ) {
            return Find ( p ) == Find ( q );
        }

        public void UnionElements ( int p,int q ) {
            int pRoot = Find(p);
            int qRoot = Find(q);
            if ( pRoot == qRoot ) {
                return;
            }
            //根据两个元素所在树的元素个数不同判断合并方向
            //将元素个数少的集合合并到元素个数多的集合上
            if ( sz[pRoot] < sz[qRoot] ) {
                parent[pRoot] = qRoot;
                sz[qRoot] += sz[pRoot];
            }
            else {
                parent[qRoot] = pRoot;
                sz[pRoot] += sz[qRoot];
            }
        }
    }
}
