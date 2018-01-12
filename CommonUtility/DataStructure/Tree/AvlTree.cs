using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhijieLi.CommonUtility.DataStructure.Tree
{
    using System.Runtime.Remoting.Metadata.W3cXsd2001;

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

        private void _Insert(AvlTreeNode<T> node)
        {
            if (node == null)
                return;

            base._Insert(node);

            var current = node;

            while (current != null)
            {
                current.UpdateHeight();
                var parrent = current.Parent;
                if (!current.IsBallance())
                {
                    if (node.IsLeftChild(current))
                    {
                        if (node.IsRightChild(current.Left))
                        {
                            LeftRotate(current.Left);
                        }

                        RightRotate(current);

                    }
                    else if (node.IsRightChild(current))
                    {
                        if (node.IsLeftChild(current.Right))
                        {
                            RightRotate(current.Right);
                        }

                        LeftRotate(current);

                    }
                }

                current = parrent;
            }
        }

        /// <summary>
        /// LeftRotate(A) 
        ///                 
        ///     A                 B                      
        ///   /   \             /   \                 
        ///  x     B     ->    A     z              
        ///       / \         / \                    
        ///      y   z       x   y                   
        /// </summary>
        /// <param name="node"></param>
        private void LeftRotate(AvlTreeNode<T> node)
        {
            var pivot = node.Right;
            if (pivot == null)
            {
                throw new ArgumentException("Cannot perform LeftRotate for current node since its right child is null.");
            }
            var parent = node.Parent;
            var grandSon = pivot.Left;

            if (parent == null)
            {
                Root = pivot;
            }
            else
            {
                if (node.IsLeftChild())
                {
                    parent.Left = pivot;
                }
                else
                {
                    parent.Right = pivot;
                }
            }

            node.Parent = pivot;
            node.Right = grandSon;
            pivot.Parent = parent;
            pivot.Left = node;
            if (grandSon != null)
            {
                grandSon.Parent = node;
            }

            node.UpdateHeight();
            pivot.UpdateHeight();
        }


        /// <summary>
        /// RightRotate(A) 
        ///                 
        ///              A                       B        
        ///            /   \                   /   \
        ///           B     z      ->         x     A 
        ///         /   \                          / \
        ///        x     y                        y   z
        /// </summary>
        /// <param name="node"></param>
        private void RightRotate(AvlTreeNode<T> node)
        {
            var pivot = node.Left;
            if (pivot == null)
            {
                throw new ArgumentException("Cannot perform RightRotate for current node since its left child is null.");
            }
            var parent = node.Parent;
            var grandson = pivot.Right;

            if (parent == null)
            {
                Root = pivot;
            }
            else
            {
                if (node.IsLeftChild())
                {
                    parent.Left = pivot;
                }
                else
                {
                    parent.Right = pivot;
                }
            }

            node.Parent = pivot;
            node.Left = grandson;
            pivot.Parent = parent;
            pivot.Right = node;
            if (grandson != null)
            {
                grandson.Parent = node;
            }

            node.UpdateHeight();
            pivot.UpdateHeight();
        }

        public override void Delete(T data)
        {
            var nodeToDelete = (AvlTreeNode<T>)base._Delete(new AvlTreeNode<T>() { data = data });

            var current = nodeToDelete.Parent;

            while (current != null)
            {
                current.UpdateHeight();

                if (!current.IsBallance())
                {
                    if (nodeToDelete.IsLeftChild(current))
                    {
                        if (current.Right.Right == null)
                        {
                            RightRotate(current.Right);
                        }

                        LeftRotate(current);
                    }
                    else
                    {
                        if (current.Left.Left == null)
                        {
                            LeftRotate(current.Left);
                        }
                        RightRotate(current);
                    }
                }

                current = current.Parent;
            }
        }

        public bool IsBallance()
        {
            return this._IsBallance(Root);
        }

        protected bool _IsBallance(AvlTreeNode<T> node)
        {
            if (node == null)
                return true;
            else
            {
                return node.IsBallance() && _IsBallance(node.Left) && _IsBallance(node.Right);
            }
        }
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

        public override bool IsValid()
        {
            return this.IsBallance() && base.IsValid();
        }
    }
}
