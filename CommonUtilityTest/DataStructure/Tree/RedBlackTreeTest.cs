using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZhijieLi.CommonUtility.DataStructure.Tree;

namespace ZhijieLi.CommonUtilityTest.DataStructure.Tree
{
    using ZhijieLi.JustDoIt.DataStructure.Tree;

    [TestClass]
    public class RedBlackTreeTest
    {
        [TestMethod]
        public void InsertTest()
        {
            var rbTree = new RedBlackTree<int>();

            var list = new List<int>() { 1, 2, 13, 5, 6, 11, 8, 9, 3, 7 };
            rbTree.Insert(list);

            foreach (var item in list)
            {
                Console.WriteLine("Insert {0} to tree", item);
                rbTree.Insert(item);
                Assert.IsTrue(RbTreeValidation(rbTree));
                Console.WriteLine("Tree is valid");
            }

        }

        [TestMethod]
        public void DeleteTest()
        {
            var rbTree = new RedBlackTree<int>();
            var list = new List<int>() { 1, 2, 13, 5, 6, 11, 8, 9, 3, 7 };
            rbTree.Insert(list);
            var deleteList = new List<int>() { 6, 2, 13, 7, 5, 11, 8, 9, 3, 1 };
            foreach (var item in deleteList)
            {
                Console.WriteLine("Delete {0} from tree", item);
                rbTree.Delete(item);
                Assert.IsTrue(RbTreeValidation(rbTree));
                Console.WriteLine("Tree is valid");
            }
        }

        private bool RbTreeValidation<T>(RedBlackTree<T> tree) where T : IComparable<T>
        {
            if (tree == null)
                return true;

            return _RbTreeValidation(tree.Root);
        }

        private bool _RbTreeValidation<T>(RedBlackTreeNode<T> node) where T : IComparable<T>
        {
            if (node == null)
            {
                return true;
            }
            else
            {
                if (node.Parent == null && node.IsRed)
                    return false;

                if (node.IsRed && (node.Parent != null && node.Parent.IsRed || node.Left != null && node.Left.IsRed || node.Right != null && node.Right.IsRed))
                    return false;

                if (BlackNodeCount(node.Left) != BlackNodeCount(node.Right))
                    return false;

                return node.IsValid() && _RbTreeValidation(node.Left) && _RbTreeValidation<T>(node.Right);
            }
        }

        private int BlackNodeCount<T>(RedBlackTreeNode<T> node) where T : IComparable<T>
        {
            if (node == null)
                return 0;

            var leftCount = BlackNodeCount(node.Left);
            var rightCount = BlackNodeCount(node.Right);
            if (leftCount != rightCount)
            {
                throw new Exception("The left and right tree do not have the same black node number.");
            }
            else
            {
                if (node.IsRed)
                    return leftCount;
                else
                    return leftCount + 1;
            }
        }
    }
}
