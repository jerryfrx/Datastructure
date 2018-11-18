using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionFind {
    class UnionFind_Two:IUF {
        private int[] parent;
        public UnionFind_Two(int size ) {
            parent = new int[size];
            for ( int i = 0 ;i < size ;i++ ) {
                parent[i] = i;
            }
        }

        public int GetSize ( ) {
            return parent.Length;
        }
        //查找过程，查找元素p所对应的集合编号--根节点
        //O（h）复杂度，h为树的高度
        private int Find(int p ) {
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
            if( pRoot == qRoot ) {
                return;
            }
            parent[pRoot] = qRoot;
        }
    }
}
