using System;
using System.Collections.Generic;
using System.Linq;

namespace HashCode {
    class HashTable<K, V> {
        private Dictionary<K,V>[] hashtable;
        private int M;
        private int size;

        public HashTable ( int m ) {
            this.M = m;
            size = 0;
            hashtable = new Dictionary<K,V>[M];
            for ( int i = 0 ;i < M ;i++ ) {
                hashtable[i] = new Dictionary<K,V> ();
            }
        }
        public HashTable ( ) {
            this.M = 97;
            hashtable = new Dictionary<K,V>[M];
            for ( int i = 0 ;i < M ;i++ ) {
                hashtable[i] = new Dictionary<K,V> ();
            }
        }
        //辅助方法
        private int Hash ( K key ) {
            //消除掉 负号(与0x7fffffff进行&运算)
            return ( key.GetHashCode () & 0x7fffffff ) % M;
        }
        public int GetSize ( ) {
            return size;
        }
        public void AddElement ( K key,V value ) {
            Dictionary<K,V> dic = hashtable[Hash(key)];
            if ( dic.ContainsKey ( key ) ) {
                dic[key] = value;
            }
            else {
                dic.Add ( key,value );
                size++;
            }
        }
        public V RemoveElement ( K key ) {
            Dictionary<K,V> dic = hashtable[Hash(key)];
            V value  = default(V);
            bool result = false;
            if ( dic.ContainsKey ( key ) ) {
                dic.TryGetValue ( key,out value );
                result = dic.Remove ( key );
                size--;
            }
            return value;
        }
        public void SetElement ( K key,V value ) {
            Dictionary<K,V> dic = hashtable[Hash(key)];
            if ( !dic.ContainsKey ( key ) ) {
                throw new Exception ( "key dosen't exist" );
            }
            dic[key] = value;
        }
        public bool Contains ( K key ) {
            return hashtable[Hash ( key )].ContainsKey ( key );
        }
        public V GetElement ( K key ) {
            return hashtable[Hash ( key )][key];
        }
    }
}

























