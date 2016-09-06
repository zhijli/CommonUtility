using System.Threading;
using CommonUtility;

namespace CommonUtilityTest
{
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.Remoting.Contexts;
    using System.Runtime.Remoting.Messaging;
    using Kid.CommonUtility;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LoggerTest
    {
        [TestMethod]
        public void LoggerTest_Method()
        {
           Console.Write(Thread.CurrentPrincipal.Identity.DebugInfoTest(false));
           MyFunc();
        }

        private void MyFunc()
        {
            LoggerManager.Init("LoggerTest");
            LoggerManager.LogInfo("hello");
        }
    }
}
