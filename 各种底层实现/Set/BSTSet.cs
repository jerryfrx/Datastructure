using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BST;

namespace Set {
    class BSTSet<T>: ISet<T> where T : IComparable<T> {
        private BST<T> bst;
        public BSTSet() {
            bst = new BST<T>();
        }
        public void Add( T e ) {
            bst.Add(e);
        }

        public bool Contains( T e ) {
            return bst.Contanis(e);
        }

        public int GetSize() {
            return bst.GetSize();
        }

        public bool IsEmpty() {
            return bst.IsEmpty();
        }

        public void Remove( T e ) {
            bst.Remove(e);
        }
    }
}
