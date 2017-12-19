// -----------------------------------------------------------------------
//  <copyright company="Microsoft">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace ZhijieLi.CommonUtility.DataStructure.Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BinaryTree<T>
    {
        public BinaryTreeNode<T> Root { get; set; }


        //Depth First Traverses- PreOrder
        public void PreOrderTraverse(Action<T> action)
        {
            var stack = new Stack<BinaryTreeNode<T>>();
            var current = Root;

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    action(current.data);
                    stack.Push(current);
                    current = current.Left;
                }

                current = stack.Pop();
                while (current.Right == null && stack.Count > 0)
                {
                    current = stack.Pop();
                }

                current = current.Right;
            }
        }

        //Depth First Traverses- InOrder
        public void InOrderTraverse(Action<T> action)
        {
            var stack = new Stack<BinaryTreeNode<T>>();
            var current = Root;

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                current = stack.Pop();
                action(current.data);

                while (current.Right == null && stack.Count > 0)
                {
                    current = stack.Pop();
                    action(current.data);
                }

                current = current.Right;
            }
        }

        //Depth First Traverses- PostOrder
        public void PostOrderTraverse(Action<T> action)
        {
            var stack = new Stack<BinaryTreeNode<T>>();
            var current = Root;

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                current = stack.Pop();

                while (current.Right == null && stack.Count > 0)
                {
                    action(current.data);
                    current = stack.Pop();
                }

                stack.Push(current);
                current = current.Right;
            }
        }

        //Breadth First Traverses
        public void BreadthTraverse(Action<T> action)
        {

        }
    }

    public class BinaryTreeNode<T>
    {
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }
        public T data { get; set; }
    }
}
