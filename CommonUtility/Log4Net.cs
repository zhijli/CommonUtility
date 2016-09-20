﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace CommonUtility
{
    public class Log4Net : ILogger
    {
        public Log4Net(string loggerName)
        {
            LoggerName = loggerName;
            Init();
        }

        public string LoggerName { get; set; }
        
        public ILog Logger { get; set; }
        private void Init()
        {
            Logger = LogManager.GetLogger(LoggerName);
        }

        public void LogInfo(string message)
        {
           Logger.Info(message);
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