using System;

//µÈÍ¬ÓÚDictionary
namespace Map {
    interface IMap<K, V> {
        void Add ( K key,V value );
        V Remove ( K key );
        bool Contains ( K key );
        V GetElement ( K key );
        void SetElement ( K key,V value );
        int GetSize ( );
        bool IsEmpty ( );
    }
}
