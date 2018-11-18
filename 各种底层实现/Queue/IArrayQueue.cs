using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue {
    interface IArrayQueue<T> {
        int GetSize ( );
        bool IsEmpty ( );
        void EnQueue ( T e );
        T Dequeue ( );
        T GetFront ( );
    }
}
