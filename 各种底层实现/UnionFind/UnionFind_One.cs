using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionFind {
    class UnionFind_One : IUF {
        private int[] id;
        public UnionFind_One ( int size ) {
            id = new int[size];
            for ( int i = 0 ;i < id.Length ;i++ ) {
                id[i] = i;
            }
        }
        public int GetSize ( ) {
            return id.Length;
        }

        //查找元素p所对应的集合编号
        private int Find(int p ) {
            if ( p < 0 && p >= id.Length ) {
                throw new Exception ( "out of bounds" );
            }
            return id[p];
        }

        //查看元素p和q是否属于同一个集合
        public bool IsConnected ( int p,int q ) {
            return Find(p)==Find(q);
        }

        //合并元素p和q所属的集合
        public void UnionElements ( int p,int q ) {
            int pID = Find(p);
            int qID = Find(q);
            if( pID == qID ) {
                return;
            }
            for ( int i = 0 ;i < id.Length ;i++ ) {
                if ( id[i] == pID ) {
                    id[i] = qID;
                }
            }
        }
    }
}
