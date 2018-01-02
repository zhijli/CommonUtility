using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhijieLi.CommonUtility.DataStructure.Tree
{
    class AvlTree<T> where T : IComparable<T>
    {
        public AvlTreeNode<T> Root { get; set; }


        public void Insert(T data) { }

        public void Delete(T data) { }
    }

    internal class AvlTreeNode<T> where T : IComparable<T>
    {
        public AvlTreeNode<T> Left { get; set; }

        public AvlTreeNode<T> Right { get; set; }

        public T Data { get; set; }

        public int Height { get; set; }
    }
}
