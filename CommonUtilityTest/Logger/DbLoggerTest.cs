using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonUtilityTest
{
    using ZhijieLi.CommonUtility.Logger;

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
