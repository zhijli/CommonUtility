using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhijieLi.CommonUtility.DataStructure.Tree;

namespace ZhijieLi.CommonUtility.DataStructure.Tree
{
    public class BinarySearchTree<T> : BinaryTree<T> where T : IComparable<T>
    {
        public new BinarySearchTreeNode<T> Root
        {
            get { return (BinarySearchTreeNode<T>)base.Root; }
            set { base.Root = value; }
        }

        public T Search(T data)
        {
            var node = _Search(data);
            return node == null ? default(T) : node.data;
        }

        public T Search(BinarySearchTreeNode<T> node)
        {
            return node == null ? default(T) : Search(node.data);
        }

        private BinarySearchTreeNode<T> _Search(T data)
        {
            if (data == null || Root == null)
                return null;

            var current = Root;
            while (current != null && current.data.CompareTo(data) != 0)
            {
                if (current.data.CompareTo(data) > 0)
                {
                    current = current.Left;
                }
                else if (current.data.CompareTo(data) < 0)
                {
                    current = current.Right;
                }
            }

            return current;
        }

        public void Insert(T data)
        {
            Insert(new BinarySearchTreeNode<T>() { data = data });
        }

        public void Insert(BinarySearchTreeNode<T> node)
        {
            if (node == null || node.data == null)
            {
                return;
            }

            if (Root == null)
            {
                Root = node;
                return;
            }

            var current = Root;
            BinarySearchTreeNode<T> pre = null;

            while (current != null)
            {
                pre = current;
                if (current.data.CompareTo(node.data) > 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            if (pre.data.CompareTo(node.data) > 0)
            {
                pre.Left = node;
            }
            else
            {
                pre.Right = node;
            }
        }


        public void Insert(ICollection<T> datas)
        {
            foreach (var data in datas)
            {
                Insert(data);
            }
        }

        public T Minimum()
        {
            return Root == null ? default(T) : Minimum(Root.data);
        }

        public T Minimum(T data)
        {
            var node = _Minimum(data);
            return node == null ? default(T) : node.data;
        }

        private BinarySearchTreeNode<T> _Minimum(T data)
        {
            if (data == null)
                return null;

            var node = _Search(data);
            return _Minimum(node);
        }

        private BinarySearchTreeNode<T> _Minimum(BinarySearchTreeNode<T> node)
        {
            if (node == null)
                return null;

            var current = node;
            while (current.Left != null)
            {
                current = current.Left;
            }

            return current;
        }

        public T Maximum()
        {
            return Root == null ? default(T) : Maximum(Root.data);
        }

        public T Maximum(T data)
        {
            var node = _Maximum(data);
            return node == null ? default(T) : node.data;
        }

        private BinarySearchTreeNode<T> _Maximum(T data)
        {
            if (data == null)
                return null;

            var node = _Search(data);
            return _Maximum(node);
        }

        private BinarySearchTreeNode<T> _Maximum(BinarySearchTreeNode<T> node)
        {
            if (node == null)
                return null;

            var current = node;
            while (current.Right != null)
            {
                current = current.Right;
            }

            return current;
        }

        public T Successor(T data)
        {
            var node = _Search(data);
            var successor = _Successor(node);
            return successor == null ? default(T) : successor.data;
        }


        private BinarySearchTreeNode<T> _Successor(BinarySearchTreeNode<T> node)
        {
            if (Root == null && node == null)
                return null;

            if (node.Right != null)
            {
                return _Minimum(node.Right.data);
            }
            else
            {
                var current = Root;
                BinarySearchTreeNode<T> successor = null;

                while (current.data.CompareTo(node.data) != 0)
                {
                    if (current.data.CompareTo(node.data) > 0)
                    {
                        successor = current;
                        current = current.Left;
                    }
                    else if (current.data.CompareTo(node.data) < 0)
                    {
                        current = current.Right;
                    }
                }

                return successor ?? null;
            }
        }

        public T Predecessor(T data)
        {
            var node = _Search(data);
            var successor = _Predecessor(node);
            return successor == null ? default(T) : successor.data;
        }


        private BinarySearchTreeNode<T> _Predecessor(BinarySearchTreeNode<T> node)
        {
            if (Root == null && node == null)
                return null;

            if (node.Left != null)
            {
                return _Maximum(node.Left);
            }
            else
            {
                var current = Root;
                BinarySearchTreeNode<T> predecessor = null;

                while (current.data.CompareTo(node.data) != 0)
                {
                    if (current.data.CompareTo(node.data) > 0)
                    {
                        current = current.Left;
                    }
                    else if (current.data.CompareTo(node.data) < 0)
                    {
                        predecessor = current;
                        current = current.Right;
                    }
                }

                return predecessor ?? null;
            }
        }

        public void Delete(T data)
        {
            if (data == null || Root == null)
            {
                return;
            }



            var current = Root;
            BinarySearchTreeNode<T> pre = null;

            while (current != null && current.data.CompareTo(data) != 0)
            {
                pre = current;
                if (current.data.CompareTo(data) > 0)
                {
                    current = current.Left;
                }
                else if (current.data.CompareTo(data) < 0)
                {
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            if (pre != null && (pre.Left != null || pre.Right != null))
            {
                var accessor = FindAccessor(pre);
            }


        }



        private object FindAccessor(BinarySearchTreeNode<T> pre)
        {
            return pre;
        }

        public class BinarySearchTreeNode<T> : BinaryTreeNode<T> where T : IComparable<T>
        {
            public new BinarySearchTreeNode<T> Left
            {
                get { return (BinarySearchTreeNode<T>)base.Left; }
                set { base.Left = value; }
            }

            public new BinarySearchTreeNode<T> Right
            {
                get { return (BinarySearchTreeNode<T>)base.Right; }
                set { base.Right = value; }
            }
        }
    }
}