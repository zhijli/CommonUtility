using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ZhijieLi.CommonUtility.DataStructure.Tree
{
    public class RedBlackTree<T> : BinarySearchTree<T> where T : IComparable<T>
    {
        public new RedBlackTreeNode<T> Root
        {
            get { return (RedBlackTreeNode<T>)base.Root; }
            set { base.Root = value; }
        }

        public override void Insert(T data)
        {
            _Insert(new RedBlackTreeNode<T>() { data = data });
        }

        private void _Insert(RedBlackTreeNode<T> node)
        {
            if (node == null || Root == null)
            {
                Root = node;
                node.IsRed = false;
                return;
            }

            node.IsRed = true;
            base._Insert(node);

            var current = node;
            while (current != null)
            {
                if (current.Parent == null)
                {
                    current.IsRed = false;
                    break;
                }
                else if (current.Parent.IsRed == false)
                {
                    break;
                }
                else
                {
                    var grandParent = current.Parent.Parent;
                    if (current.IsLeftChild(grandParent))
                    {
                        if (grandParent.Right != null && grandParent.Right.IsRed)
                        {
                            current.Parent.IsRed = false;
                            grandParent.Right.IsRed = false;
                            grandParent.IsRed = true;
                            current = grandParent;
                        }
                        else
                        {
                            if (current.IsRightChild((current.Parent)))
                            {
                                LeftRotate(current, current.Parent);
                            }

                            RightRotate(grandParent.Left, grandParent);
                            grandParent.IsRed = true;
                            grandParent.Parent.IsRed = false;
                            break;
                        }
                    }
                    else
                    {
                        if (grandParent.Left != null && grandParent.Left.IsRed)
                        {
                            current.Parent.IsRed = false;
                            grandParent.Left.IsRed = false;
                            grandParent.IsRed = true;
                            current = grandParent;
                        }
                        else
                        {
                            if (current.IsLeftChild(current.Parent))
                            {
                                RightRotate(current, current.Parent);
                            }

                            LeftRotate(grandParent.Right, grandParent);
                            grandParent.IsRed = true;
                            grandParent.Parent.IsRed = false;
                            break;
                        }
                    }
                }
            }
        }

        private void RightRotate(RedBlackTreeNode<T> node, RedBlackTreeNode<T> parent)
        {
            var grandParent = parent.Parent;
            var son = node.Right;

            if (grandParent == null)
            {
                Root = node;
            }
            else
            {
                if (parent.IsLeftChild(grandParent))
                {
                    grandParent.Left = node;
                }
                else
                {
                    grandParent.Right = node;
                }
            }

            node.Parent = grandParent;
            node.Right = parent;
            parent.Left = son;
            parent.Parent = node;

            if (son != null)
            {
                son.Parent = parent;
            }
        }

        private void LeftRotate(RedBlackTreeNode<T> node, RedBlackTreeNode<T> parent)
        {
            var grandParent = parent.Parent;
            var son = node.Left;

            if (grandParent == null)
            {
                Root = node;
            }
            else
            {
                if (parent.IsLeftChild(grandParent))
                {
                    grandParent.Left = node;
                }
                else
                {
                    grandParent.Right = node;
                }
            }

            node.Parent = grandParent;
            node.Left = parent;
            parent.Right = son;
            parent.Parent = node;

            if (son != null)
            {
                son.Parent = parent;
            }
        }
    }

    public class RedBlackTreeNode<T> : BinarySearchTreeNode<T> where T : IComparable<T>
    {
        //public static RedBlackTreeNode<T> Nil = new RedBlackTreeNode<T>() { IsRed = false };

        public new RedBlackTreeNode<T> Left
        {
            get { return (RedBlackTreeNode<T>)base.Left; }
            set { base.Left = value; }
        }

        public new RedBlackTreeNode<T> Right
        {
            get { return (RedBlackTreeNode<T>)base.Right; }
            set { base.Right = value; }
        }

        public new RedBlackTreeNode<T> Parent
        {
            get { return (RedBlackTreeNode<T>)base.Parent; }
            set { base.Parent = value; }
        }

        public bool IsRed { get; set; }
    }
}
