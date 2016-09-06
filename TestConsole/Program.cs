using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtility;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggerManager.Init("TestConsole");
            LoggerManager.LogInfo("hello");
        }
    }
}
