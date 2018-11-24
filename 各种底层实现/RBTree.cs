using System;

namespace RBTree {
    public class RBTree<K, V> where K : IComparable<K> {

        private static readonly bool RED = true;
        private static readonly bool BLACK = false;

        public class Node {
            public K key;
            public V value;
            public Node left, right;
            public bool color;

            public Node(K key, V value) {
                this.key = key;
                this.value = value;
                left = null;
                right = null;
                color = RED;
            }
        }

        private Node root;
        private int size;

        public RBTree() {
            root = null;
            size = 0;
        }
        public int GetSize() {
            return size;
        }
        public bool IsEmpty() {
            return size == 0;
        }
        public bool IsRed(Node node) {
            if (node == null) {
                return BLACK;
            }
            return node.color;
        }

        /*------------------��������------------------------*/
        /*
         *     node                        x
         *     /  \        ����ת          / \
         *    T1   x    ---------->    node T3
         *        / \                   / \
         *      T2   T3                T1  T2
        */
        //�����������ת
        private Node LeftRotate(Node node) {
            Node x = node.right;
            //����
            node.right = x.left;
            x.left = node;
            x.color = node.color;
            node.color = RED;
            return x;
        }
        /*
         *      node                     x
         *      /  \       ����ת        / \
         *     x   T2   ----------->   y   node
         *    / \                          /   \
         *   y   T1                       T1   T2
        */
        //�����������ת
        private Node RightRotate(Node node) {
            Node x = node.left;
            //����
            node.left = x.right;
            x.right = node;
            x.color = node.color;
            node.color = RED;
            return x;
        }
        //��ɫ��ת
        //��Ϊnode��Ҫ�����ںϣ�������Ҫ���óɺ�ɫ
        private void FlipColors(Node node) {
            node.color = RED;
            node.left.color = BLACK;
            node.right.color = BLACK;
        }
        /*------------------��������------------------------*/

        //������������µ�Ԫ��
        public void Add(K key, V value) {
            root = Add(root, key, value);
            root.color = BLACK;
        }
        //���ز����½ڵ�������ĸ�
        private Node Add(Node node, K key, V value) {
            if (node == null) {//Ĭ�ϲ����ɫ�ڵ�
                size++;
                return new Node(key, value);
            }
            if (key.CompareTo(node.key) < 0) {
                node.left = Add(node.left, key, value);
            }
            else if (key.CompareTo(node.key) > 0) {
                node.right = Add(node.right, key, value);
            }
            else {
                node.value = value;
            }
            if (IsRed(node.right) && !IsRed(node.left)) {
                node = LeftRotate(node);
            }
            if (IsRed(node.left) && IsRed(node.left.left)) {
                node = RightRotate(node);
            }
            if (IsRed(node.left) && IsRed(node.right)) {
                FlipColors(node);
            }
            return node;
        }
        private Node GetNode(Node node, K key) {
            if (node == null) {
                return null;
            }
            if (key.Equals(node.key)) {
                return node;
            }
            else if (key.CompareTo(node.key) < 0) {
                return GetNode(node.left, key);
            }
            else {
                return GetNode(node.right, key);
            }
        }
        public bool Contains(K key) {
            return GetNode(root, key) != null;
        }
        public V Get(K key) {
            Node node = GetNode(root, key);
            return node == null ? default(V) : node.value;
        }
        public void Set(K key, V value) {
            Node node = GetNode(root, key);
            if (node == null) {
                throw new Exception();
            }
            node.value = value;
        }
    }
}
