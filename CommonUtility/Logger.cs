using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters;
using Newtonsoft.Json;

namespace Kid.CommonUtility
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Logger
    {
        public static void LogInfo(string str)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);
            var method = sf.GetMethod();


            Console.Write("Method: {0}.{1}, Message:{2}" ,method.DeclaringType.Name, method.Name, str);
        }
    }
}
