using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegmentTree {
    interface IMerger <T> {
        T Merge ( T a,T b );
    }
}
