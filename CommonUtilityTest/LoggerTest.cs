using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using Kid.CommonUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonUtilityTest
{
    [TestClass]
    public class LoggerTest
    {
        [TestMethod]
        public void LoggerTest_Method()
        {
           MyFunc();
        }

        private void MyFunc()
        {
            Logger.LogInfo("hello");
        }
    }
}
