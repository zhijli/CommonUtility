using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZhijieLi.CommonUtility.DataStructure.Tree;

namespace ZhijieLi.CommonUtilityTest.DataStructure.Tree
{
    [TestClass]
    public class BinarySearchTreeTest
    {
        [TestMethod]
        public void InsertTest()
        {
            var bst = CreateBinarySearchTree();
            var output = new StringBuilder();

            bst.BreadthTraverse(data => output.Append(data + " "));
            Assert.AreEqual("9 3 11 2 6 13 1 5 7 8 ", output.ToString());

            output.Clear();
            bst.PreOrderTraverse(data => output.Append(data + " "));
            Assert.AreEqual("9 3 2 1 6 5 7 8 11 13 ", output.ToString());

            output.Clear();
            bst.InOrderTraverse(data => output.Append(data + " "));
            Assert.AreEqual("1 2 3 5 6 7 8 9 11 13 ", output.ToString());
        }


        [TestMethod]
        public void SearchTest()
        {
            var bst = CreateBinarySearchTree();

            var data = bst.Search(6);
            Assert.AreEqual(6, data);

            data = bst.Search(8);
            Assert.AreEqual(8, data);

            data = bst.Search(14);
            Assert.AreEqual(0, data);
        }

        [TestMethod]
        public void MinimumTest()
        {
            var bst = CreateBinarySearchTree();

            var data = bst.Minimum();
            Assert.AreEqual(1, data);

            data = bst.Minimum(6);
            Assert.AreEqual(5, data);

            data = bst.Minimum(11);
            Assert.AreEqual(11, data);
        }

        [TestMethod]
        public void MaximumTest()
        {
            var bst = CreateBinarySearchTree();

            var data = bst.Maximum();
            Assert.AreEqual(13, data);

            data = bst.Maximum(6);
            Assert.AreEqual(8, data);

            data = bst.Maximum(2);
            Assert.AreEqual(2, data);
        }

        [TestMethod]
        public void SuccessorTest()
        {
            var bst = CreateBinarySearchTree();

            var list = new List<int>() { 1, 2, 3, 5, 6, 7, 8, 9, 11, 13 };
            for (int i = 0; i< list.Count - 1; i++)
            {
                Assert.AreEqual(list[i+1], bst.Successor(list[i]));
            }

        }

        [TestMethod]
        public void PredecessorTest()
        {
            var bst = CreateBinarySearchTree();

            var list = new List<int>() { 1, 2, 3, 5, 6, 7, 8, 9, 11, 13 };
            for (int i = 1; i < list.Count ; i++)
            {
                Assert.AreEqual(list[i -1], bst.Predecessor(list[i]));
            }
        }

        private BinarySearchTree<int> CreateBinarySearchTree()
        {
            //         9
            //      3     11
            //   2    6      13
            // 1     5  7
            //           8
            var bst = new BinarySearchTree<int>();
            bst.Insert(new List<int>() { 9, 3, 2, 1, 6, 5, 7, 8, 11, 13 });
            return bst;
        }
    }
}

