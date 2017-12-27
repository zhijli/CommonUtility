// -----------------------------------------------------------------------
//  <copyright company="Microsoft">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace ZhijieLi.JustDoIt.DataStructure.Tree
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ZhijieLi.CommonUtility.DataStructure.Tree;

    [TestClass]
    public class BinaryTreeExtensionTest
    {

        [TestMethod]
        public void TraverseAtTreeLevel_Valid()
        {
            var tree = this.CreateBinaryTree();
            var output = new StringBuilder();
            tree.TraverseAtTreeLevel(data => output.Append(data + " "), 3);
            Assert.AreEqual("4 5 6 ", output.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TraverseAtTreeLevel_Exceed_tree_height()
        {
            var tree = this.CreateBinaryTree();
            var output = new StringBuilder();
            tree.TraverseAtTreeLevel(data => output.Append(data + " "), 6);
        }

        [TestMethod]
        public void PreOrderTraverse_recursion_Test()
        {
            var tree = this.CreateBinaryTree();
            var output = new StringBuilder();
            tree.PreOrderTraverse_recursion(data => output.Append(data + " "));
            Assert.AreEqual("1 2 4 7 5 8 9 10 3 6 ", output.ToString());
        }

        [TestMethod]
        public void InOrder_Traverser_recursion_Test()
        {
            var tree = this.CreateBinaryTree();
            var output = new StringBuilder();
            tree.InOrderTraverse_recursion(data => output.Append(data + " "));
            Assert.AreEqual("7 4 2 8 5 9 10 1 3 6 ", output.ToString());
        }

        [TestMethod]
        public void PostOrder_Traverser_recursion_Test()
        {
            var tree = this.CreateBinaryTree();
            var output = new StringBuilder();
            tree.PostOrderTraverse_recursion(data => output.Append(data + " "));
            Assert.AreEqual("7 4 8 10 9 5 2 6 3 1 ", output.ToString());
        }

        [TestMethod]
        public void Vertical_Traverser_Test()
        {
            var tree = this.CreateBinaryTree();
            var output = new StringBuilder();
            tree.VerticalTraverse(data => output.Append(data + " "));
            Assert.AreEqual("7 4 2 8 1 5 3 9 6 10 ", output.ToString());
        }

        [TestMethod]
        public void Boundary_Traverser_Test()
        {
            var tree = this.CreateBinaryTree();
            var output = new StringBuilder();
            tree.BoundaryTraverse(data => output.Append(data + " "));
            Assert.AreEqual("1 2 4 7 8 10 6 3 ", output.ToString());
        }

        [TestMethod]
        public void Revert_Level_Traverser_Test()
        {
            var tree = this.CreateBinaryTree();
            var output = new StringBuilder();
            tree.RevertLevelTraverse(data => output.Append(data + " "));
            Assert.AreEqual("10 7 8 9 4 5 6 2 3 1 ", output.ToString());
        }

        [TestMethod]
        public void Construct_BinaryTree_With_PreOrder_And_InOrder_Test()
        {
            var preOrder = new List<int>() { 1, 2, 4, 7, 5, 8, 9, 10, 3, 6 };
            var inOrder = new List<int>() { 7, 4, 2, 8, 5, 9, 10, 1, 3, 6 };

            var expected = this.CreateBinaryTree();
            var tree = BinaryTreeExtension.ConstructBinaryTreeWithPreOrderAndInOrder(preOrder, inOrder);

            var output = new StringBuilder();
            tree.PreOrderTraverse(data => output.Append(data + " "));
            Assert.AreEqual("1 2 4 7 5 8 9 10 3 6 ", output.ToString());
            output.Clear();
            tree.InOrderTraverse(data => output.Append(data + " "));
            Assert.AreEqual("7 4 2 8 5 9 10 1 3 6 ", output.ToString());
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
            tree.Root.Left = new BinaryTreeNode<int> { data = 2 };
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
