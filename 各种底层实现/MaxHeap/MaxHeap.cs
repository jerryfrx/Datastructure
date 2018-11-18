using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ����
//������ʵ��ʱ��1������1��ʼ����ʱ 2������0��ʼ����ʱ
//1��parent(i) = i/2    left_child(i) = 2*i   right_child(i) = 2*i+1
//2��parent(i) = (i-1)/2    left_child(i) = 2*i+1   right_child(i) = 2*i+2
namespace MaxHeap {
    public class MaxHeap<T> where T : IComparable<T> {
        private List<T> data;
        public MaxHeap ( int capacity ) {
            data = new List<T> ( capacity );
        }
        public MaxHeap ( ) {
            data = new List<T> ();
        }
        //���ض���Ԫ�ظ���
        public int Size ( ) {
            return data.Count ();
        }
        //�Ƿ�Ϊ��
        public bool IsEmpty ( ) {
            return data.Count () == 0;
        }
        public T RetKValue ( int k ) {
            return data[k - 1];
        }
        //��������˽�еĸ�������
        //������ȫ�������������ʾ�У�һ����������ʾ��Ԫ�صĸ��׽ڵ������
        private int Parent ( int index ) {
            if ( index == 0 ) {
                //throw new Exception("error");
                return 0;
            }
            return ( index - 1 ) / 2;
        }
        //������ȫ�������������ʾ�У�һ����������ʾ��Ԫ�ص����ӽڵ������
        private int LeftChild ( int index ) {
            return index * 2 + 1;
        }
        //������ȫ�������������ʾ�У�һ����������ʾ��Ԫ�ص��Һ��ӽڵ������
        private int RightChild ( int index ) {
            return index * 2 + 2;
        }
        //��������Ԫ��
        public void AddElement ( T e ) {
            data.Add ( e );
            _SiftUp ( data.Count () - 1 );
        }
        //�����
        private void _SiftUp ( int k ) {
            while ( k > 0 && data[this.Parent ( k )].CompareTo ( data[k] ) < 0 ) {
                if ( Parent ( k ) < 0 || Parent ( k ) >= data.Count () || k < 0 || k >= data.Count () ) {
                    throw new Exception ( "out of bounds" );
                }
                var temp = data[k];
                data[k] = data[this.Parent ( k )];
                data[Parent ( k )] = temp;
                k = this.Parent ( k );
            }
        }
        //��������Ԫ��
        public T FindMax ( ) {
            if ( data.Count () == 0 ) {
                throw new Exception ( "empty data" );
            }
            return data[0];
        }
        //ȡ���������Ԫ��
        public T ExtractMax ( ) {
            T result = FindMax();
            //��0���λ�õ�Ԫ�غͶ������һ��Ԫ�ؽ���λ�ã�Ȼ��ɾ��
            data[0] = data[data.Count () - 1];
            data.RemoveAt ( data.Count () - 1 );
            _SiftDown ( 0 );
            return result;
        }
        private void _SiftDown ( int k ) {
            while ( LeftChild ( k ) < data.Count () ) {
                int j = LeftChild(k);
                if ( j + 1 < data.Count () && data[j + 1].CompareTo ( data[j] ) > 0 ) {
                    j = RightChild ( k );
                    //data[j]��LeftChild��RightChild�е����ֵ
                }
                if ( data[k].CompareTo ( data[j] ) >= 0 ) {
                    break;
                }
                var temp = data[k];
                data[k] = data[j];
                data[j] = temp;
                k = j;
            }
        }
        //
        public T ReplaceElement ( T e ) {
            T result = FindMax();
            data[0] = e;
            _SiftDown ( 0 );
            return result;
        }
        //heapify ��������������ɶѵ���״
        public MaxHeap ( T[] arr ) {
            data = new List<T> ( arr );
            for ( int i = this.Parent ( arr.Length - 1 ) ;i >= 0 ;i-- ) {
                _SiftDown ( i );
            }
        }
    }
}









