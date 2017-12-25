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

            while (current != null)
            {
                while (current.Left != null)
                {
                    action(current.data);
                    stack.Push(current);
                    current = current.Left;
                }

                action(current.data);
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

            while (current != null)
            {
                while (current.Left != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                
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
            bool rightReturn = false;
            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                current = stack.Pop();
                if (current.Right == null)
                {
                    action(current.data);

                    while (stack.Count > 0)
                    {
                        current = stack.Pop();
                        if (current == null)
                        {
                            //Return from Right child
                            rightReturn = true;
                            current = stack.Pop();
                            action(current.data);
                        }
                        else
                        {
                            //Return from Left child
                            rightReturn = false;    
                            if (current.Right != null)
                            {
                                break;
                            }
                            else
                            {
                                action(current.data);
                            }
                        }
                    }
                }

                if (current.Right != null && rightReturn == false)
                {
                    stack.Push(current);
                    stack.Push(null);
                    current = current.Right;
                }
                else { break; }
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

        public  bool Equals(BinaryTree<T> obj)
        {
            return base.Equals(obj);
        }
        
    }

    public class BinaryTreeNode<T>
    {
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }
        public T data { get; set; }
    }
}
