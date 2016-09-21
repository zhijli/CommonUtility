using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CommonUtility
{
    public class TraceLogger : ILogger
    {
        public TraceLogger(string loggerName)
        {
            LoggerName = loggerName;
            Init();
        }

        public string LoggerName { get; set; }

        private TraceSource _traceSource { get; set; }

        private int _id { get; set; }

        private void Init()
        {
            _traceSource = new TraceSource(LoggerName);
            _id = 0;
        }

        public void LogInfo(string message)
        {
            _traceSource.TraceEvent(TraceEventType.Information, _id++ , message);
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
