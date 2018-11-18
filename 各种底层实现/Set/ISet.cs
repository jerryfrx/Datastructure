using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set {
    public interface ISet<T> {
        void Add( T e );
        void Remove( T e );
        bool Contains( T e );
        int GetSize();
        bool IsEmpty();

    }
}
