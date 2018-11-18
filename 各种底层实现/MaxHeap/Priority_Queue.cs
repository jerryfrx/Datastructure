using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxHeap {
    class PriorityQueue<T> : Queue<T> where T : IComparable<T> {
        private MaxHeap<T> maxHeap;
        public PriorityQueue ( ) {
            maxHeap = new MaxHeap<T> ();
        }
        public int GetSize ( ) {
            return maxHeap.Size ();
        }
        public bool IsEmpty ( ) {
            return maxHeap.IsEmpty ();
        }
        public T GetFront ( ) {
            return maxHeap.FindMax ();
        }
        public void EnQueue ( T e ) {
            maxHeap.AddElement ( e );
        }
        public T DeQueue ( ) {
            return maxHeap.ExtractMax ();
        }
    }
}
