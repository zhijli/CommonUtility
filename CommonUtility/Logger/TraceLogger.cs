namespace ZhijieLi.CommonUtility.Logger
{
    using System;
    using System.Diagnostics;

    public class TraceLogger : ILogger
    {
        public TraceLogger(string loggerName)
        {
            this.LoggerName = loggerName;
            this.Init();
        }

        public string LoggerName { get; set; }

        private TraceSource _traceSource { get; set; }

        private int _id { get; set; }

        private void Init()
        {
            this._traceSource = new TraceSource(this.LoggerName);
            this._id = 0;
        }

        public void LogInfo(string message)
        {
            this._traceSource.TraceEvent(TraceEventType.Information, this._id++ , message);
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
