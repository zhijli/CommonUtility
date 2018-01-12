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
                                LeftRotate(current.Parent);
                            }

                            RightRotate(grandParent);
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
                                RightRotate(current.Parent);
                            }

                            LeftRotate(grandParent);
                            grandParent.IsRed = true;
                            grandParent.Parent.IsRed = false;
                            break;
                        }
                    }
                }
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
        private void LeftRotate(RedBlackTreeNode<T> node)
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
        private void RightRotate(RedBlackTreeNode<T> node)
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
        }

        public void Delete(T data)
        {
            _Delete(new RedBlackTreeNode<T>() { data = data });
        }

        private RedBlackTreeNode<T> _Delete(RedBlackTreeNode<T> node)
        {
            if (node == null || Root == null)
            {
                return null;
            }

            //Todo: try to reuse the base._Delete. Now the isLeftChild information is lost when use base._Delete
            var current = (RedBlackTreeNode<T>)base._Search(node.data);
            var nodeToDelete = current;
            bool isLeftChild = true;
            if (current != null)
            {
                nodeToDelete = current;
                isLeftChild = nodeToDelete.IsLeftChild();
                if (current.ChildNum() == 2)
                {
                    nodeToDelete = (RedBlackTreeNode<T>)base._Successor(current);
                    isLeftChild = nodeToDelete.IsLeftChild();
                    current.data = nodeToDelete.data;
                }

                //nodeToDetele.ChildNum <= 1
                if (nodeToDelete.Left != null)
                {
                    base._DeleteNode(nodeToDelete.Parent, nodeToDelete, nodeToDelete.Left);
                }
                else
                {
                    base._DeleteNode(nodeToDelete.Parent, nodeToDelete, nodeToDelete.Right);
                }
            }

            if (nodeToDelete != null && nodeToDelete.IsRed != true)
            {
                var parent = nodeToDelete.Parent;

                if (nodeToDelete.Left != null)
                {
                    current = nodeToDelete.Left;
                }
                else
                {
                    current = nodeToDelete.Right;
                }

                while (current != Root && (current == null || current != null && current.IsRed == false))
                {
                    if (isLeftChild)
                    {
                        var brother = parent.Right;
                        if (brother != null && brother.IsRed)
                        {
                            LeftRotate(parent);
                            brother.IsRed = false;
                            parent.IsRed = true;
                            brother = parent.Right;
                        }

                        if ((brother.Right == null || (brother.Right != null && brother.Right.IsRed == false)) &&
                            (brother.Left == null || (brother.Left != null && brother.Left.IsRed == false)))
                        {
                            brother.IsRed = true;
                            current = parent;
                            parent = current.Parent;
                        }
                        else
                        {
                            var brotherLeftChild = brother.Left;
                            if (brother.Right == null || (brother.Right != null && brother.Right.IsRed == false))
                            {
                                RightRotate(brother);
                                brotherLeftChild.IsRed = false;
                                brother.IsRed = true;
                                brother = brotherLeftChild;
                            }

                            LeftRotate(parent);
                            brother.Right.IsRed = false;
                            brother.IsRed = parent.IsRed;
                            parent.IsRed = false;
                            break;
                        }
                    }
                    else
                    {
                        var brother = parent.Left;
                        if (brother != null && brother.IsRed)
                        {
                            RightRotate(parent);
                            brother.IsRed = false;
                            parent.IsRed = true;
                            brother = parent.Left;
                        }

                        if ((brother.Left == null || (brother.Left != null && brother.Left.IsRed == false)) &&
                            (brother.Right == null || (brother.Right != null && brother.Right.IsRed == false)))
                        {
                            brother.IsRed = true;
                            current = parent;
                            parent = current.Parent;
                        }
                        else
                        {
                            var brotherRightChild = brother.Right;
                            if (brother.Left == null || (brother.Left != null && brother.Left.IsRed == false))
                            {
                                LeftRotate(brother);
                                brotherRightChild.IsRed = false;
                                brother.IsRed = true;
                                brother = brotherRightChild;
                            }

                            RightRotate(parent);
                            brother.Left.IsRed = false;
                            brother.IsRed = parent.IsRed;
                            parent.IsRed = false;
                            break;
                        }
                    }
                }
                if (current != null)
                {
                    current.IsRed = false;
                }
            }
            return nodeToDelete;
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
