using System;
using Kid.CommonUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonUtilityTest
{
    [TestClass]
    public class DebugHelperTest
    {
        [TestMethod]
        public void DebugInfoTest()
        {
           Console.Write(AppDomain.CurrentDomain.DebugInfo());
        }
    }
}
