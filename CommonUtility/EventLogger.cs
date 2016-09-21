using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtility
{
    /// <summary>
    /// Adaptor for Eventlog -> ILogger
    /// </summary>
    public class EventLogger : ILogger
    {
        private EventLog _eventLog;

        public EventLogger(string loggerName)
        {
            LoggerName = loggerName;
            Init();
        }

        public string LoggerName { get; set; }

        private void Init()
        {
            try
            {
                _eventLog = new EventLog();
                _eventLog.BeginInit();

                //An event log source should not be created and immediately used.
                //There is a latency time to enable the source, it should be created
                //prior to executing the application that uses the source.
                //Execute this sample a second time to use the new source.
                if (!EventLog.Exists(LoggerName))
                {
                    //Need Admin credencial
                    EventLog.CreateEventSource(LoggerName, LoggerName);
                }

                _eventLog.Source = LoggerName;
                _eventLog.EndInit();
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", string.Format("Failed to create event log source with exception:\r\n{0}", ex), EventLogEntryType.Error);
            }
        }

        public void LogInfo(string message)
        {
            _eventLog.WriteEntry(message,EventLogEntryType.Information);
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
