using System;
using System.Collections.Generic;
//递归实现二分搜索树 Binary Search Tree
namespace BST {
    public class BST<T> where T : IComparable<T> {

        private class Node {
            public T e;
            public Node left, right;
            public Node( T e ) {
                this.e = e;
                this.left = null;
                this.right = null;
            }
        }
        private Node root;
        private int size;
        public BST() {
            root = null;
            size = 0;
        }
        public int GetSize() {
            return size;
        }
        public bool IsEmpty() {
            return size == 0;
        }
        public void Add( T e ) {
            if ( root == null ) {
                root = new Node(e);
                size++;
            }
            else {
                _Add(root,e);
            }
        }
        ////递归函数,向以node为根的二分搜索树中插入元素e
        //private void _Add(Node node,T e){
        //    //先考虑终止条件
        //    if(e.Equals(node.e)){
        //        return;
        //    }else if(e.CompareTo(node.e)<0 && node.left == null){
        //        node.left = new Node(e);
        //        size++;
        //        return;
        //    }else if(e.CompareTo(node.e)>0 && node.right == null){
        //        node.right = new Node(e);
        //        size++;
        //        return;
        //    }
        //    //再考虑普遍现象
        //    if(e.CompareTo(node.e)<0){
        //        _Add(node.left, e);
        //    }
        //    else{//e.CompareTo(node.e)>0
        //        _Add(node.right, e);
        //    }
        //}

        ////递归函数,向以node为根的二分搜索树中插入元素e
        ////改进方法,返回插入新节点后二分搜索树的根
        private Node _Add( Node node,T e ) {
            if ( node == null ) {
                size++;
                return new Node(e);
            }

            if ( e.CompareTo(node.e) < 0 ) {
                node.left = _Add(node.left,e);
            }
            else if ( e.CompareTo(node.e) > 0 ) {
                node.right = _Add(node.right,e);
            }
            return node;
        }
        //看二分搜索树中是否包含元素e
        public bool Contanis( T e ) {
            return _Contains(root,e);
        }
        //看以node为根的二分搜索树中是否包含元素e
        //递归实现
        private bool _Contains( Node node,T e ) {
            if ( node == null ) {
                return false;
            }

            if ( e.CompareTo(node.e) == 0 ) {
                return true;
            }
            else if ( e.CompareTo(node.e) < 0 ) {
                return _Contains(node.left,e);
            }
            else {
                return _Contains(node.right,e);
            }
        }
        //前序遍历
        public void PreOrder() {
            _PreOrder(root);
        }
        private void _PreOrder( Node node ) {
            if ( node == null ) {
                return;
            }
            Console.WriteLine(node.e);
            _PreOrder(node.left);
            _PreOrder(node.right);
        }
        //非递归前序遍历
        //利用栈进行操作
        public void PreOrderNR() {
            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);
            while ( stack.Count != 0 ) {
                Node current = stack.Pop();
                Console.WriteLine(current.e);
                if ( current.right != null ) {
                    stack.Push(current.right);
                }
                if ( current.left != null ) {
                    stack.Push(current.left);
                }
            }
        }

        //中序遍历
        public void InOrder() {
            _InOrder(root);
        }
        private void _InOrder( Node node ) {
            if ( node == null ) {
                return;
            }
            _InOrder(node.left);
            Console.WriteLine(node.e);
            _InOrder(node.right);
        }

        //后序遍历
        public void PostOrder() {
            _PostOrder(root);
        }
        private void _PostOrder( Node node ) {
            if ( node == null ) {
                return;
            }
            _PostOrder(node.left);
            _PostOrder(node.right);
            Console.WriteLine(node.e);
        }
        //广度优先遍历--层序遍历
        //利用队列
        public void LevelOrder() {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while ( queue.Count != 0 ) {
                Node current = queue.Dequeue();
                Console.WriteLine(current.e);
                if ( current.left != null ) {
                    queue.Enqueue(current.left);
                }
                if ( current.right != null ) {
                    queue.Enqueue(current.right);
                }
            }
        }
        //寻找二分搜索树中的最小元素
        public T Minimum() {
            if ( size == 0 ) {
                throw new Exception("BST is empty!");
            }
            return _Minimum(root).e;
        }
        private Node _Minimum( Node node ) {
            if ( node.left == null ) {
                return node;
            }
            else {
                return _Minimum(node.left);
            }
        }
        //寻找二分搜索树中的最大元素
        public T Maxmum() {
            if ( size == 0 ) {
                throw new Exception("BST is empty");
            }
            return _Maxmum(root).e;
        }
        private Node _Maxmum( Node node ) {
            if ( node.right == null ) {
                return node;
            }
            else {
                return _Maxmum(node.right);
            }
        }
        //删除二分搜索树中最小的元素并且返回该值
        public T RemoveMin() {
            T result = Minimum();
            _RemoveMin(root);
            return result;
        }
        //删除以node为根的二分搜索树中最小的节点
        //返回删除节点后新的二分搜索树的根
        private Node _RemoveMin( Node node ) {
            if ( node.left == null ) {
                Node rightnode = node.right;
                node.right = null;
                size--;
                return rightnode;
            }
            //当删除掉左节点后，递归函数会返回，所以需要将root重新设置
            node.left = _RemoveMin(node.left);
            return node;
        }

        //删除二分搜索树中最大的元素并且返回该值
        public T RemoveMax() {
            T result = Maxmum();
            _RemoveMax(root);
            return result;
        }
        private Node _RemoveMax( Node node ) {
            if ( node.right == null ) {
                Node leftnode = node.left;
                node.left = null;
                size--;
                return leftnode;
            }
            node.right = _RemoveMax(node.right);
            return node;
        }
        //删除二分搜索树指定元素
        public void Remove( T e ) {
            root = _Remove(root,e);
        }
        private Node _Remove( Node node,T e ) {
            if ( node == null ) {
                return null;
            }
            if ( e.CompareTo(node.e) < 0 ) {
                node.left = _Remove(node.left,e);
                return node;
            }
            else if ( e.CompareTo(node.e) > 0 ) {
                node.right = _Remove(node.right,e);
                node.right = _Remove(node.right,e);
                return node;
            }
            else {//待删节点左子树为空的情况
                if ( node.left == null ) {
                    Node rightnode = node.right;                   
                    node.right = null;
                    size--;
                    return rightnode;
                }//待删节点右子树为空的情况
                if ( node.right == null ) {
                    Node leftnode = node.left;
                    node.left = null;                   
                    size--;
                    return leftnode;
                }
                //待删除节点左右树均不为空的情况
                //找到比待删除节点大的最小节点，即待删除节点右子树的最小节点
                //用这个节点顶替待删节点的位置
                Node successor = _Minimum(node.right);
                successor.right = _RemoveMin(node.right);
                successor.left = node.left;

                //清除
                node.left = node.right = null;

                return successor;              
            }
        }
    }
}

