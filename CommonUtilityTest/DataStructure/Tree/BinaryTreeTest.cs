using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZhijieLi.CommonUtilityTest.DataStructure.Tree
{
    using System.Text;
    using ZhijieLi.CommonUtility.DataStructure.Tree;

    [TestClass]
    public class BinaryTreeTest
    {
        [TestMethod]
        public void PreOrderTest()
        {
            var tree = this.CreateBinaryTree();
            var output = new StringBuilder();
            tree.PreOrderTraverse(data => output.Append(data + " "));
            Assert.AreEqual("1 2 4 5 3 ", output.ToString());
        }

        [TestMethod]
        public void InOrderTest()
        {
            var tree = this.CreateBinaryTree();
            var output = new StringBuilder();
            tree.InOrderTraverse(data => output.Append(data + " "));
            Assert.AreEqual("4 2 5 1 3 ", output.ToString());
        }

        private BinaryTree<int> CreateBinaryTree()
        {
            //    1
            //  2     3
            //4  5
            var tree = new BinaryTree<int>();
            tree.Root = new BinaryTreeNode<int> { data = 1 };
            tree.Root.Left = new BinaryTreeNode < int > { data = 2};
            tree.Root.Right = new BinaryTreeNode<int> { data = 3 };
            tree.Root.Left.Left = new BinaryTreeNode<int> { data = 4 };
            tree.Root.Left.Right = new BinaryTreeNode<int> { data = 5 };

            return tree;
        }
    }
}
