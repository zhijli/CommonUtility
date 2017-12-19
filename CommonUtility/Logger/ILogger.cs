namespace ZhijieLi.CommonUtility.Logger
{
    using System;

    public interface ILogger
    {
        string LoggerName { get; set; }

        void LogInfo(string message);

        void LogMessage(string message);

        void LogVerbose(string message);

        void LogError(string message);

        void LogException(Exception ex);
    }
}
