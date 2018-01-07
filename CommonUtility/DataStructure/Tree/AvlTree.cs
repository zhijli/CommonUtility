using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhijieLi.CommonUtility.DataStructure.Tree
{
    public class AvlTree<T> : BinarySearchTree<T> where T : IComparable<T>
    {
        public new AvlTreeNode<T> Root
        {
            get { return (AvlTreeNode<T>)base.Root; }
            set { base.Root = value; }
        }

        public override void Insert(T data)
        {
            _Insert(new AvlTreeNode<T>() { data = data });
        }

        public override void Insert(ICollection<T> dataCollection)
        {
            foreach (var data in dataCollection)
            {
                Insert(data);
            }
        }

        private void _Insert(AvlTreeNode<T> node)
        {
            if (node == null)
                return;

            base._Insert(node);

            var current = node;

            while (current != null)
            {
                current.UpdateHeight();

                if (!current.IsBallance())
                {
                    if (node.IsLeftChild(current))
                    {
                        if (node.IsRightChild(current.Left))
                        {
                            LeftRotate(current.Left.Right, current.Left);
                        }

                        RightRotate(current.Left, current);

                    }
                    if (node.IsRightChild(current))
                    {
                        if (node.IsLeftChild(current.Right))
                        {
                            RightRotate(current.Right.Left, current.Right);
                        }

                        LeftRotate(current.Right, current);

                    }

                    break;
                }

                current = current.Parent;
            }
        }

        /// <summary>
        /// LeftRotate(B, B.parent) 
        ///                 
        ///     A                 B                      
        ///   /   \             /   \                 
        ///  x     B     ->    A     z              
        ///       / \         / \                    
        ///      y   z       x   y                   
        /// </summary>
        /// <param name="node"></param>
        /// <param name="parent"></param>
        private void LeftRotate(AvlTreeNode<T> node, AvlTreeNode<T> parent)
        {
            var grandParent = parent.Parent;
            var son = node.Left;

            if (grandParent == null)
            {
                Root = node;
            }
            else
            {
                if (parent.IsLeftChild())
                {
                    grandParent.Left = node;
                }
                else
                {
                    grandParent.Right = node;
                }
            }
            node.Parent = grandParent;
            if (son != null)
            {
                son.Parent = parent;
            }
            node.Left = parent;
            parent.Parent = node;
            parent.Right = son;

            parent.UpdateHeight();
            node.UpdateHeight();
        }


        /// <summary>
        /// RightRotate(A, A.parent) 
        ///                 
        ///              B                       A        
        ///            /   \                   /   \
        ///           A     z      ->         x     B 
        ///         /   \                          / \
        ///        x     y                        y   z
        /// </summary>
        /// <param name="node"></param>
        /// <param name="parent"></param>
        private void RightRotate(AvlTreeNode<T> node, AvlTreeNode<T> parent)
        {
            var grandParent = parent.Parent;
            var son = node.Left;

            if (grandParent == null)
            {
                Root = node;
            }
            else
            {
                if (parent.IsLeftChild())
                {
                    grandParent.Left = node;
                }
                else
                {
                    grandParent.Right = node;
                }

            }
            node.Parent = grandParent;
            if (son != null)
            {
                son.Parent = parent;
            }
            node.Right = parent;
            parent.Parent = node;
            parent.Left = son;
            

            parent.UpdateHeight();
            node.UpdateHeight();
        }

        public void Delete(T data) { }
    }

    public class AvlTreeNode<T> : BinarySearchTreeNode<T> where T : IComparable<T>
    {
        public new AvlTreeNode<T> Left
        {
            get { return (AvlTreeNode<T>)base.Left; }
            set { base.Left = value; }
        }

        public new AvlTreeNode<T> Right
        {
            get { return (AvlTreeNode<T>)base.Right; }
            set { base.Right = value; }
        }

        public new AvlTreeNode<T> Parent
        {
            get { return (AvlTreeNode<T>)base.Parent; }
            set { base.Parent = value; }
        }

        public int Height { get; set; }

        public void UpdateHeight()
        {
            int leftChildHeight = Left == null ? 0 : Left.Height;
            int rightChildHeight = Right == null ? 0 : Right.Height;

            Height = Math.Max(leftChildHeight, rightChildHeight) + 1;
        }

        public bool IsBallance()
        {
            int leftChildHeight = Left == null ? 0 : Left.Height;
            int rightChildHeight = Right == null ? 0 : Right.Height;

            return Math.Abs(leftChildHeight - rightChildHeight) <= 1;
        }
    }
}
