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

        public void Insert(T data)
        {
            if (data == null)
            {
                return;
            }

            if (Root == null)
            {
                Root = new BinarySearchTreeNode<T>() { data = data };
                return;
            }

            var current = Root;
            BinarySearchTreeNode<T> pre = null;

            while (current != null)
            {
                pre = current;
                if (current.data.CompareTo(data) > 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            if (pre.data.CompareTo(data) > 0)
            {
                pre.Left = new BinarySearchTreeNode<T>() { data = data };
            }
            else
            {
                pre.Right = new BinarySearchTreeNode<T>() { data = data };
            }
        }

        public void Insert(ICollection<T> datas)
        {
            foreach (var data in datas)
            {
                Insert(data);
            }
        }

        public void Delete(T data)
        {
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