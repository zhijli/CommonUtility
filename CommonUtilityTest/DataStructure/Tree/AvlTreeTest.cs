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
    public class AvlTreeTest
    {
        [TestMethod]
        public void InsertTest()
        {
            var avlTree = new AvlTree<int>();

            var list = new List<int>() { 1, 2, 3, 5, 6, 7, 8, 9, 11, 13 };
            avlTree.Insert(list);

            Assert.IsTrue(avlTree.Root.IsBallance());
        }

        [TestMethod]
        public void DeleteTest()
        {
            var avlTree = new AvlTree<int>();

            var list = new List<int>() { 1, 2, 3, 5, 6, 7, 8, 9, 11, 13 };
            avlTree.Insert(list);

            avlTree.Delete(5);
            avlTree.Delete(2);
            avlTree.Delete(1);
            avlTree.Delete(3);
            Assert.IsTrue(avlTree.Root.IsBallance());
        }
    }
}
