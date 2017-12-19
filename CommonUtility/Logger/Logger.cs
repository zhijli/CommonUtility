namespace ZhijieLi.CommonUtility.Logger
{
    using System;
    using System.Diagnostics;

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
