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
    }
}
