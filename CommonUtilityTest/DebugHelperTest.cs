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
    public class DebugHelperTest
    {
        [TestMethod]
        public void DebugInfoTest_AppDomain()
        {
            Console.Write(AppDomain.CurrentDomain.DebugInfo());
        }

        [TestMethod]
        public void DebugInfoSimpleTest_AppDomain()
        {
            Console.Write(AppDomain.CurrentDomain.DebugInfo(false));
        }

        [TestMethod]
        public void DebugInfoSimpleTest()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(0);
            
            var method = sf.GetMethod();

            Console.Write(method.DebugInfo());
        }
    }
}
