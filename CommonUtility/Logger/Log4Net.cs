namespace ZhijieLi.CommonUtility.Logger
{
    using System;
    using log4net;

    public class Log4Net : ILogger
    {
        public Log4Net(string loggerName)
        {
            this.LoggerName = loggerName;
            this.Init();
        }

        public string LoggerName { get; set; }
        
        public ILog Logger { get; set; }
        private void Init()
        {
            this.Logger = LogManager.GetLogger(this.LoggerName);
        }

        public void LogInfo(string message)
        {
           this.Logger.Info(message);
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
