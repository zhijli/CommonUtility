namespace ZhijieLi.CommonUtilityTest.DataStructure.Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ZhijieLi.CommonUtility.DataStructure.Tree;
    using ZhijieLi.JustDoIt.DataStructure.Tree;

    [TestClass]
    public class AvlTreeTest
    {
        [TestMethod]
        public void InsertTest()
        {
            var avlTree = new AvlTree<int>();

            var list = new List<int>() { 1, 2, 13, 5, 6, 11, 8, 9, 3, 7 };
            foreach (var item in list)
            {
                Console.WriteLine("Insert {0} to tree", item);
                avlTree.Insert(item);
                Assert.IsTrue(AvlTreeValidation(avlTree));
                Console.WriteLine("Tree is valid");
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            var avlTree = new AvlTree<int>();

            var list = new List<int>() { 1, 2, 13, 5, 6, 11, 8, 9, 3, 7 };
            avlTree.Insert(list);
            var deleteList = new List<int>() { 6, 2, 13, 7, 5, 11, 8, 9, 3, 1 };
            foreach (var item in deleteList)
            {
                Console.WriteLine("Delete {0} from tree", item);
                avlTree.Delete(item);
                Assert.IsTrue(AvlTreeValidation(avlTree));
                Console.WriteLine("Tree is valid");
            }
        }

        public bool AvlTreeValidation<T>(AvlTree<T> tree) where T : IComparable<T>
        {
            if (tree == null)
                return true;

            return _AvlTreeValidation(tree.Root);
        }

        private bool _AvlTreeValidation<T>(AvlTreeNode<T> node) where T : IComparable<T>
        {
            if (node == null)
            {
                return true;
            }
            else
            {
                return node.IsValid() && _AvlTreeValidation<T>(node.Left) && _AvlTreeValidation<T>(node.Right);
            }
        }
    }
}
