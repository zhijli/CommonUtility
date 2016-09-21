using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            TryExecute(
                () => AddLogger(new EventLogger(logName)),
                ex => EventLog.WriteEntry("Application", string.Format("Add EventLogger {0} failed with exception:{1}{2}", Environment.NewLine, logName, ex), EventLogEntryType.Error)
            );

            TryExecute(
               () => AddLogger(new TraceLogger(logName)),
               ex => EventLog.WriteEntry("Application", string.Format("Add TraceLogger {0} failed with exception:{1}{2}", Environment.NewLine, logName, ex), EventLogEntryType.Error)
           );

            TryExecute(
                () => AddLogger(new Log4Net(logName)),
                ex => EventLog.WriteEntry("Application", string.Format("Add Log4Net {0} failed with exception:{1}{2}", Environment.NewLine, logName, ex), EventLogEntryType.Error)
            );

            TryExecute(
                () => AddLogger(new DbLogger()),
                ex => EventLog.WriteEntry("Application", string.Format("Add DbLogger {0} failed with exception:{1}{2}", Environment.NewLine, logName, ex), EventLogEntryType.Error)
            );

            //TryExecute(
            //    () => AddLogger(new TraceSource(logName)),
            //    ex => EventLog.WriteEntry("Application", string.Format("Add Log4Net {0} failed with exception:{1}{2}", Environment.NewLine, logName, ex), EventLogEntryType.Error)
            //);
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

        public static void TryExecute(Action action, Action<Exception> handleExcetipn = null)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                if (handleExcetipn != null)
                {
                    handleExcetipn(ex);
                }
                else
                {
                    EventLog.WriteEntry("Application", ex.ToString(), EventLogEntryType.Error);
                }
            }
        }

        public static void LogInfo(string message)
        {
            TryExecute(() =>
            {
                _loggers.ForEach(logger => logger.LogInfo(message));
            });
        }
    }
}
