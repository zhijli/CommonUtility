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
            var a = new List<int>(2*count);
            var result = new List<BinaryTreeNode<T>>(count);

            for (int i = 0; i < 2 * count; i++)
                a.Insert(i,0);

            for (int i = 0; i <  count; i++)
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
        /// Traverse all nodes at a given level
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static void TraverseAtTreeLevel<T>(this BinaryTree<T>  tree,  Action<T> action, int level)
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
                        throw new ArgumentOutOfRangeException
                         ($"The level parameter is lager than the tree's height. The height of tree:{currentLevel - 1}, level:{level}.");
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
    }
}
