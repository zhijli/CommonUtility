// -----------------------------------------------------------------------
//  <copyright company="Microsoft">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace ZhijieLi.JustDoIt.DataStructure.Tree
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using ZhijieLi.CommonUtility.DataStructure.Tree;

    public static class BinaryTreeExtension
    {
        /// <summary>
        /// Recustion version of binary tree preOrder traverse 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tree"></param>
        /// <param name="action"></param>
        public static void PreOrderTraverse_recursion<T>(this BinaryTree<T> tree, Action<T> action)
        {
            if (tree == null)
                return;

            PreOrderTraverse_recursion_imp<T>(tree.Root, action);
        }

        private static void PreOrderTraverse_recursion_imp<T>(BinaryTreeNode<T> node, Action<T> action)
        {
            if (node == null)
                return;
            action(node.data);
            PreOrderTraverse_recursion_imp(node.Left, action);
            PreOrderTraverse_recursion_imp(node.Right, action);
        }

        /// <summary>
        /// Recustion version of binary tree inOrder traverse 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tree"></param>
        /// <param name="action"></param>
        public static void InOrderTraverse_recursion<T>(this BinaryTree<T> tree, Action<T> action)
        {
            if (tree == null)
                return;
            InOrderTravers_recursion_imp(tree.Root, action);
        }

        private static void InOrderTravers_recursion_imp<T>(BinaryTreeNode<T> node, Action<T> action)
        {
            if (node == null)
                return;
            InOrderTravers_recursion_imp<T>(node.Left, action);
            action(node.data);
            InOrderTravers_recursion_imp<T>(node.Right, action);
        }

        /// <summary>
        /// Recustion version of binary tree postOrder traverse 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tree"></param>
        /// <param name="action"></param>
        public static void PostOrderTraverse_recursion<T>(this BinaryTree<T> tree, Action<T> action)
        {
            if (tree == null)
                return;
            PostOrderTravers_recursion_imp(tree.Root, action);
        }

        private static void PostOrderTravers_recursion_imp<T>(BinaryTreeNode<T> node, Action<T> action)
        {
            if (node == null)
                return;
            PostOrderTravers_recursion_imp(node.Left, action);
            PostOrderTravers_recursion_imp(node.Right, action);
            action(node.data);
        }

        /// <summary>
        /// Vertical traverse -- O(n)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tree"></param>
        /// <param name="action"></param>
        public static void VerticalTraverse<T>(this BinaryTree<T> tree, Action<T> action)
        {
            if (tree == null || tree.Root == null)
                return;

            var tuple = Tuple.Create(tree.Root, 0);

            var queue = new Queue<Tuple<BinaryTreeNode<T>, int>>();
            queue.Enqueue(tuple);
            var list = new List<Tuple<BinaryTreeNode<T>, int>>();

            //use breadth treavers to maintain the vertical order
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                list.Add(current);

                if (current.Item1.Left != null)
                {
                    queue.Enqueue(Tuple.Create(current.Item1.Left, current.Item2 - 1));
                }
                if (current.Item1.Right != null)
                {
                    queue.Enqueue(Tuple.Create(current.Item1.Right, current.Item2 + 1));
                }
            }

            var result = CountSort(list);
            foreach (var node in result)
            {
                action(node.data);
            }
        }

        private static List<BinaryTreeNode<T>> CountSort<T>(List<Tuple<BinaryTreeNode<T>, int>> list)
        {
            var count = list.Count;
            var a = new List<int>(2 * count);
            var result = new List<BinaryTreeNode<T>>(count);

            for (int i = 0; i < 2 * count; i++)
                a.Insert(i, 0);

            for (int i = 0; i < count; i++)
                result.Insert(i, null);

            foreach (var tuple in list)
            {
                a[tuple.Item2 + count]++;
            }

            for (int i = 1; i < 2 * count; i++)
            {
                a[i] = a[i - 1] + a[i];
            }

            for (int i = count - 1; i >= 0; i--)
            {
                result[a[list[i].Item2 + count] - 1] = list[i].Item1;
                a[list[i].Item2 + count]--;
            }

            return result;
        }

        /// <summary>
        /// Revert Leve Treaverse
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tree"></param>
        /// <param name="action"></param>
        public static void RevertLevelTraverse<T>(this BinaryTree<T> tree, Action<T> action)
        {
            var current = tree.Root;
            var stack = new Stack<BinaryTreeNode<T>>();
            var queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(current);

            while (queue.Count > 0)
            {
                current = queue.Dequeue();

                if (current != null)
                {
                    stack.Push(current);
                    queue.Enqueue(current.Right);
                    queue.Enqueue(current.Left);
                }
            }

            while (stack.Count > 0)
            {
                current = stack.Pop();
                action(current.data);
            }
        }

        /// <summary>
        /// Boundary Traverse -- O(n)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tree"></param>
        /// <param name="action"></param>
        public static void BoundaryTraverse<T>(this BinaryTree<T> tree, Action<T> action)
        {
            if (tree == null || tree.Root == null)
            {
                return;
            }

            bool isLeftTop = true;
            bool isRightTop = true;
            var current = Tuple.Create(tree.Root, isLeftTop, isRightTop);
            var stack = new Stack<Tuple<BinaryTreeNode<T>, bool, bool>>();
            var actionQueue = new Queue<T>();
            var actionStack = new Stack<T>();

            while (current.Item1 != null || stack.Count > 0)
            {
                while (current.Item1 != null)
                {
                    if (current.Item2 == true || (current.Item1.Left == null && current.Item1.Right == null))
                    {
                        //Use queue for leftTop or child node
                        actionQueue.Enqueue(current.Item1.data);
                    }
                    else if (current.Item3 == true)
                    {
                        //Use stack for rightTop node
                        actionStack.Push(current.Item1.data);
                    }

                    stack.Push(current);
                    current = Tuple.Create(current.Item1.Left, current.Item2, false);
                }

                current = stack.Pop();
                while (current.Item1.Right == null && stack.Count > 0)
                {
                    current = stack.Pop();
                }

                current = Tuple.Create(current.Item1.Right, false, current.Item3);
            }

            //Execute action for all boundary node
            while (actionQueue.Count > 0)
            {
                var data = actionQueue.Dequeue();
                action(data);
            }
            while (actionStack.Count > 0)
            {
                var data = actionStack.Pop();
                action(data);
            }
        }



        /// <summary>
        /// Traverse all nodes at a given level
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static void TraverseAtTreeLevel<T>(this BinaryTree<T> tree, Action<T> action, int level)
        {
            var current = tree.Root;
            var queue = new Queue<BinaryTreeNode<T>>();

            if (current == null)
                return;

            int currentLevel = 0;


            //Use null as a flag of new level
            queue.Enqueue(null);
            queue.Enqueue(current);

            while (queue.Count > 0)
            {
                current = queue.Dequeue();
                if (current == null)
                {
                    if (currentLevel == level)
                    {
                        break;
                    }
                    currentLevel++;
                    if (queue.Count > 0)
                    {
                        current = queue.Dequeue();
                        queue.Enqueue(null);
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException(
                            $"The level parameter is lager than the tree's height. The height of tree:{currentLevel - 1}, level:{level}.");
                    }
                }

                if (currentLevel == level)
                {
                    action(current.data);
                }

                if (current.Left != null)
                {
                    queue.Enqueue(current.Left);
                }
                if (current.Right != null)
                {
                    queue.Enqueue(current.Right);
                }
            }
        }

        /// <summary>
        /// Create a binary tree according to its preOrder and inOrder traverse list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="preOrder"></param>
        /// <param name="inOrder"></param>
        /// <returns></returns>
        public static BinaryTree<T> ConstructBinaryTreeWithPreOrderAndInOrder<T>(List<T> preOrder, List<T> inOrder)
        {
            var tree = new BinaryTree<T>()
            {
                Root = new BinaryTreeNode<T>()
            };

            ConstructBinaryTreeWithPreOrderAndInOrder_imp(
                tree.Root,
                preOrder,
                0,
                preOrder.Count - 1,
                inOrder,
                0,
                inOrder.Count - 1);
            return tree;
        }

        private static void ConstructBinaryTreeWithPreOrderAndInOrder_imp<T>(
            BinaryTreeNode<T> node,
            List<T> preOrder,
            int preStart,
            int preEnd,
            List<T> inOrder,
            int inStart,
            int inEnd)
        {
            if (node == null || preStart > preEnd || inStart > inEnd)
                return;

            node.data = preOrder[preStart];

            if (preStart == preEnd || inStart == inEnd)
                return;

            var index = inOrder.FindIndex(d => d.Equals(node.data));

            int leftChildIndex = preStart + 1;
            int rightChildIndex = preEnd + 1;
            bool hasLeftChild = false;
            bool hasRightChild = false;
            bool findRight = false;
            for (int j = inStart; j <= inEnd; j++)
            {
                if (Equals(inOrder[j], preOrder[preStart + 1]))
                {
                    if (j < index)
                    {
                        node.Left = new BinaryTreeNode<T> { data = inOrder[j] };
                        leftChildIndex = preStart + 1;
                        hasLeftChild = true;
                        break;
                    }
                    else
                    {
                        node.Right = new BinaryTreeNode<T> { data = inOrder[j] };
                        rightChildIndex = preStart + 1;
                        hasRightChild = true;
                        break;
                    }
                }
            }

            if (hasLeftChild)
            {
                for (int i = preStart + 2; i <= preEnd && !findRight; i++)
                {
                    for (int k = index + 1; k <= inEnd; k++)
                    {
                        if (Equals(inOrder[k], preOrder[i]))
                        {
                            node.Right = new BinaryTreeNode<T> { data = inOrder[k] };
                            rightChildIndex = i;
                            hasRightChild = true;
                            findRight = true;
                            break;
                        }
                    }
                }
            }

            if (hasLeftChild == true)
            {
                ConstructBinaryTreeWithPreOrderAndInOrder_imp(
                    node.Left,
                    preOrder,
                    leftChildIndex,
                    rightChildIndex - 1,
                    inOrder,
                    inStart,
                    index - 1);
            }

            if (hasRightChild == true)
            {
                ConstructBinaryTreeWithPreOrderAndInOrder_imp(
                    node.Right,
                    preOrder,
                    rightChildIndex,
                    preEnd,
                    inOrder,
                    index + 1,
                    inEnd);
            }
        }

    }


}
