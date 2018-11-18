using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack {
    interface IStack<T> {
        void Push ( T e );
        T Pop ( );
        T Peek ( );
        int GetSize ( );
        bool IsEmpty ( );
    }
}
