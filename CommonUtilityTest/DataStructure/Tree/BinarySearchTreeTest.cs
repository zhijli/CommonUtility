using System;
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
            //         9
            //      3     11
            //   2    6      13
            // 1     5  7
            //           8
            var bst = new BinarySearchTree<int>();
            bst.Insert(new List<int>() {9,3 ,2,1,6,5,7,8,11,13});
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
    }
}

