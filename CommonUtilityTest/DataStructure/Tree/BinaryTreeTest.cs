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
            Assert.AreEqual("1 2 4 7 5 8 9 10 3 6 ", output.ToString());
        }

        [TestMethod]
        public void InOrderTest()
        {
            var tree = this.CreateBinaryTree();
            var output = new StringBuilder();
            tree.InOrderTraverse(data => output.Append(data + " "));
            Assert.AreEqual("7 4 2 8 5 9 10 1 3 6 ", output.ToString());
        }

        [TestMethod]
        public void PostOrderTest()
        {
            var tree = this.CreateBinaryTree();
            var output = new StringBuilder();
            tree.PostOrderTraverse(data => output.Append(data + " "));
            Assert.AreEqual("7 4 8 10 9 5 2 6 3 1 ", output.ToString());
        }

        [TestMethod]
        public void BreadthTraverseTest()
        {
            var tree = this.CreateBinaryTree();
            var output = new StringBuilder();
            tree.BreadthTraverse(data => output.Append(data + " "));
            Assert.AreEqual("1 2 3 4 5 6 7 8 9 10 ", output.ToString());
        }

        private BinaryTree<int> CreateBinaryTree()
        {
            //         1
            //      2     3
            //   4    5      6
            // 7     8  9
            //           10
            var tree = new BinaryTree<int>();
            tree.Root = new BinaryTreeNode<int> { data = 1 };
            tree.Root.Left = new BinaryTreeNode < int > { data = 2};
            tree.Root.Right = new BinaryTreeNode<int> { data = 3 };
            tree.Root.Left.Left = new BinaryTreeNode<int> { data = 4 };
            tree.Root.Left.Right = new BinaryTreeNode<int> { data = 5 };
            tree.Root.Right.Right = new BinaryTreeNode<int> { data = 6 };
            tree.Root.Left.Left.Left = new BinaryTreeNode<int> { data = 7 };
            tree.Root.Left.Right.Left = new BinaryTreeNode<int> { data = 8 };
            tree.Root.Left.Right.Right = new BinaryTreeNode<int> { data = 9 };
            tree.Root.Left.Right.Right.Right = new BinaryTreeNode<int> { data = 10 };
            return tree;
        }
    }
}
