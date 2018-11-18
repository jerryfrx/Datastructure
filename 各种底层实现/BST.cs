using System;
using System.Collections.Generic;
//�ݹ�ʵ�ֶ��������� Binary Search Tree
namespace BST {
    public class BST<T> where T : IComparable<T> {

        private class Node {
            public T e;
            public Node left, right;
            public Node ( T e ) {
                this.e = e;
                this.left = null;
                this.right = null;
            }
        }
        private Node root;
        private int size;
        public BST ( ) {
            root = null;
            size = 0;
        }
        public int GetSize ( ) {
            return size;
        }
        public bool IsEmpty ( ) {
            return size == 0;
        }
        public void Add ( T e ) {
            root = _Add ( root,e );
            //if ( root == null ) {
            //    root = new Node(e);
            //    size++;
            //}
            //else {
            //    _Add(root,e);
            //}
        }
        ////�ݹ麯��,����nodeΪ���Ķ����������в���Ԫ��e
        //private void _Add(Node node,T e){
        //    //�ȿ�����ֹ����
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
        //    //�ٿ����ձ�����
        //    if(e.CompareTo(node.e)<0){
        //        _Add(node.left, e);
        //    }
        //    else{//e.CompareTo(node.e)>0
        //        _Add(node.right, e);
        //    }
        //}

        ////�ݹ麯��,����nodeΪ���Ķ����������в���Ԫ��e
        ////�Ľ�����,���ز����½ڵ������������ĸ�
        private Node _Add ( Node node,T e ) {
            if ( node == null ) {
                size++;
                return new Node ( e );
            }

            if ( e.CompareTo ( node.e ) < 0 ) {
                node.left = _Add ( node.left,e );
            }
            else if ( e.CompareTo ( node.e ) > 0 ) {
                node.right = _Add ( node.right,e );
            }
            return node;
        }
        //���������������Ƿ����Ԫ��e
        public bool Contanis ( T e ) {
            return _Contains ( root,e );
        }
        //����nodeΪ���Ķ������������Ƿ����Ԫ��e
        //�ݹ�ʵ��
        private bool _Contains ( Node node,T e ) {
            if ( node == null ) {
                return false;
            }

            if ( e.CompareTo ( node.e ) == 0 ) {
                return true;
            }
            else if ( e.CompareTo ( node.e ) < 0 ) {
                return _Contains ( node.left,e );
            }
            else {
                return _Contains ( node.right,e );
            }
        }
        //ǰ�����
        public void PreOrder ( ) {
            _PreOrder ( root );
        }
        private void _PreOrder ( Node node ) {
            if ( node == null ) {
                return;
            }
            Console.WriteLine ( node.e );
            _PreOrder ( node.left );
            _PreOrder ( node.right );
        }
        //�ǵݹ�ǰ�����
        //����ջ���в���
        public void PreOrderNR ( ) {
            Stack<Node> stack = new Stack<Node>();
            stack.Push ( root );
            while ( stack.Count != 0 ) {
                Node current = stack.Pop();
                Console.WriteLine ( current.e );
                if ( current.right != null ) {
                    stack.Push ( current.right );
                }
                if ( current.left != null ) {
                    stack.Push ( current.left );
                }
            }
        }

        //�������
        public void InOrder ( ) {
            _InOrder ( root );
        }
        private void _InOrder ( Node node ) {
            if ( node == null ) {
                return;
            }
            _InOrder ( node.left );
            Console.WriteLine ( node.e );
            _InOrder ( node.right );
        }

        //�������
        public void PostOrder ( ) {
            _PostOrder ( root );
        }
        private void _PostOrder ( Node node ) {
            if ( node == null ) {
                return;
            }
            _PostOrder ( node.left );
            _PostOrder ( node.right );
            Console.WriteLine ( node.e );
        }
        //������ȱ���--�������
        //���ö���
        public void LevelOrder ( ) {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue ( root );
            while ( queue.Count != 0 ) {
                Node current = queue.Dequeue();
                Console.WriteLine ( current.e );
                if ( current.left != null ) {
                    queue.Enqueue ( current.left );
                }
                if ( current.right != null ) {
                    queue.Enqueue ( current.right );
                }
            }
        }
        //Ѱ�Ҷ����������е���СԪ��
        public T Minimum ( ) {
            if ( size == 0 ) {
                throw new Exception ( "BST is empty!" );
            }
            return _Minimum ( root ).e;
        }
        private Node _Minimum ( Node node ) {
            if ( node.left == null ) {
                return node;
            }
            else {
                return _Minimum ( node.left );
            }
        }
        //Ѱ�Ҷ����������е����Ԫ��
        public T Maxmum ( ) {
            if ( size == 0 ) {
                throw new Exception ( "BST is empty" );
            }
            return _Maxmum ( root ).e;
        }
        private Node _Maxmum ( Node node ) {
            if ( node.right == null ) {
                return node;
            }
            else {
                return _Maxmum ( node.right );
            }
        }
        //ɾ����������������С��Ԫ�ز��ҷ��ظ�ֵ
        public T RemoveMin ( ) {
            T result = Minimum();
            _RemoveMin ( root );
            return result;
        }
        //ɾ����nodeΪ���Ķ�������������С�Ľڵ�
        //����ɾ���ڵ���µĶ����������ĸ�
        private Node _RemoveMin ( Node node ) {
            if ( node.left == null ) {
                Node rightnode = node.right;
                node.right = null;
                size--;
                return rightnode;
            }
            //��ɾ������ڵ�󣬵ݹ麯���᷵�أ�������Ҫ��root��������
            node.left = _RemoveMin ( node.left );
            return node;
        }

        //ɾ������������������Ԫ�ز��ҷ��ظ�ֵ
        public T RemoveMax ( ) {
            T result = Maxmum();
            _RemoveMax ( root );
            return result;
        }
        private Node _RemoveMax ( Node node ) {
            if ( node.right == null ) {
                Node leftnode = node.left;
                node.left = null;
                size--;
                return leftnode;
            }
            node.right = _RemoveMax ( node.right );
            return node;
        }
        //ɾ������������ָ��Ԫ��
        public void Remove ( T e ) {
            root = _Remove ( root,e );
        }
        private Node _Remove ( Node node,T e ) {
            if ( node == null ) {
                return null;
            }
            if ( e.CompareTo ( node.e ) < 0 ) {
                node.left = _Remove ( node.left,e );
                return node;
            }
            else if ( e.CompareTo ( node.e ) > 0 ) {
                node.right = _Remove ( node.right,e );
                node.right = _Remove ( node.right,e );
                return node;
            }
            else {//��ɾ�ڵ�������Ϊ�յ����
                if ( node.left == null ) {
                    Node rightnode = node.right;
                    node.right = null;
                    size--;
                    return rightnode;
                }//��ɾ�ڵ�������Ϊ�յ����
                if ( node.right == null ) {
                    Node leftnode = node.left;
                    node.left = null;
                    size--;
                    return leftnode;
                }
                //��ɾ���ڵ�����������Ϊ�յ����
                //�ҵ��ȴ�ɾ���ڵ�����С�ڵ㣬����ɾ���ڵ�����������С�ڵ�
                //������ڵ㶥���ɾ�ڵ��λ��
                Node successor = _Minimum(node.right);
                successor.right = _RemoveMin ( node.right );
                successor.left = node.left;

                //���
                node.left = node.right = null;

                return successor;
            }
        }
    }
}

