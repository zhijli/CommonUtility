﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    using ZhijieLi.CommonUtility.Logger;

    class Program
    {
        static void Main(string[] args)
        {
            LoggerManager.Init("TestConsole");
            LoggerManager.LogInfo("hello");
            Console.Read();
        }
    }
}
