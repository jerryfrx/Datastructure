using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionFind {
    interface IUF {
        bool IsConnected ( int p,int q );
        void UnionElements ( int p,int q );
        int GetSize ( );
    }
}
