using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegmentTree {
    public class NumArray {
        class Merger : IMerger<int> {
            public int Merge ( int a,int b ) {
                return a + b;
            }
        }
        private SegmentTree<int> segmentTree;
        public NumArray ( int[] nums ) {
            if ( nums.Length > 0 ) {
                segmentTree = new SegmentTree<int> ( nums,new Merger ( ) );
            }
        }

        public int SumRange ( int i,int j ) {
            return segmentTree.Query ( i,j );
        }
    }
}
