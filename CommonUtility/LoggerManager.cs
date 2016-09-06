using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommonUtility
{
    public static class LoggerManager
    {
        public static void Init(string logName)
        {
            AddLogger(new EventLogger(logName));
            AddLogger(new Log4Net(logName));
        }

        private static List<ILogger> _loggers = new List<ILogger>();

        private static object _lock = new object();

        public static void AddLogger(ILogger logger)
        {
            lock (_lock)
            {
                _loggers.Add(logger);
            }
        }

        public static void Execute(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Console.Write(ex);

                //foreach (var logger in _loggers)
                //{
                //    logger.LogException(ex);
                //}
            }
        }

        public static void LogInfo(string message)
        {
            Execute(() =>
            {
                foreach (ILogger log in _loggers)
                {
                    log.LogInfo(message);
                }
            });
        }
    }
}
