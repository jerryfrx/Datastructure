using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//基于rank的优化，rank[i]表示根节点为i的树的高度
namespace UnionFind {
    class UnionFind_Four : IUF {
        private int[] parent;
        private int[] rank;//rank[i]表示以i为根的集合所表示树的层数
        public UnionFind_Four ( int size ) {
            parent = new int[size];
            rank = new int[size];
            for ( int i = 0 ;i < size ;i++ ) {
                parent[i] = i;
                rank[i] = 1;
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
            //根据两个元素所在树的rank不同判断合并方向
            //将rank低的集合合并到rank高的集合上
            if ( rank[pRoot] < rank[qRoot] ) {
                parent[pRoot] = qRoot;
            }
            else if(rank[pRoot] > rank[qRoot]){
                parent[qRoot] = pRoot;
            }
            else {//rank[pRoot] == rank[qRoot]
                parent[qRoot] = pRoot;
                rank[pRoot] += 1;
            }
        }
    }
}
