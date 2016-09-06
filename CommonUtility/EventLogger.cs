using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtility
{
    public class EventLogger : ILogger
    {
        public EventLogger(string loggerName)
        {
            LoggerName = loggerName;
            Init();
        }

        public string LoggerName { get; set; }

        private void Init()
        {
            if (!EventLog.Exists(LoggerName))
            {
                EventLog.CreateEventSource(LoggerName, LoggerName);
            }
        }

        public void LogInfo(string message)
        {
           EventLog.WriteEntry(LoggerName, message, EventLogEntryType.Information);
        }

        public void LogMessage(string message)
        {
            throw new NotImplementedException();
        }

        public void LogVerbose(string message)
        {
            throw new NotImplementedException();
        }

        public void LogError(string message)
        {
            throw new NotImplementedException();
        }

        public void LogException(Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
