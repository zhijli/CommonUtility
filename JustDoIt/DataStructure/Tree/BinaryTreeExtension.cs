// -----------------------------------------------------------------------
//  <copyright company="Microsoft">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace ZhijieLi.JustDoIt.DataStructure.Tree
{
    using System;
    using System.Collections.Generic;
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
