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
                    stack.Push(current.Right);
                    current = current.Left;
                }

                current = stack.Pop();
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
                if (current == null)
                {
                    //Return from Richt child
                    current = stack.Pop();
                    action(current.data);
                    //go back to while loop again
                    current = null;
                }
                else
                {
                    //Return from Left child
                    stack.Push(current);
                    //use null as a flag to indicate the next node in stack is return from right child
                    stack.Push(null);
                    current = current.Right;
                }
            }
        }

        //Breadth First Traverses
        public void BreadthTraverse(Action<T> action)
        {
            var current = Root;
            var queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(current);

            while (queue.Count > 0)
            {
                current = queue.Dequeue();
                if (current != null)
                {
                    action(current.data);
                    queue.Enqueue(current.Left);
                    queue.Enqueue(current.Right);
                }
            }
        }

        public bool Equals(BinaryTree<T> obj)
        {
            return base.Equals(obj);
        }

        //public override string ToString()
        //{
            
        //}

    }

    public class BinaryTreeNode<T>
    {
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }
        public T data { get; set; }
    }
}
