using System;
using CommonUtility;
using Kid.CommonUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonUtilityTest
{
    [TestClass]
    public class DbLoggerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var db = new DbLogger();
            var result = db.ExecuteDb();
            Console.Write(result.DebugInfo());
        }
    }
}
