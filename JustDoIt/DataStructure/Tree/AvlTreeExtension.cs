// -----------------------------------------------------------------------
//  <copyright company="Microsoft">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace ZhijieLi.JustDoIt.DataStructure.Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ZhijieLi.CommonUtility.DataStructure.Tree;

    public static class  AvlTreeExtension
    {
        public static bool IsValid<T>(this AvlTree<T> tree, Action<T> action) where T : IComparable<T>
        {
            if (tree == null)
                return true;

            return _IsValid(tree.Root);
        }

        private static bool _IsValid<T>(this AvlTreeNode<T> node) where T : IComparable<T>
        {
            if (node == null)
            {
                return true;
            }
            else
            {
                return node.IsValid() && _IsValid<T>(node.Left) && _IsValid<T>(node.Right);
            }
        }
    }
}
