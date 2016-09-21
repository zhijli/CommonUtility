//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using CommonUtility;

//namespace TestConsole
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //LoggerManager.Init("TestConsole");
//            //LoggerManager.LogInfo("hello");

//            Debug.WriteLine("Error in Widget 42");

//            Trace.WriteLine("Error in Widget 42");

//            var ts = new TraceSource("TraceTest");

//            ts.TraceEvent(TraceEventType.Error, 1, "hello");

//            Console.WriteLine("Press any key to exit.");
//            Console.Read();
//        }

//    }
//}
