using System.Threading;

namespace CommonUtilityTest
{
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.Remoting.Contexts;
    using System.Runtime.Remoting.Messaging;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ZhijieLi.CommonUtility.Logger;

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
            LoggerManager.Init("TestConsole");
            LoggerManager.LogInfo("hello");
        }
    }
}
