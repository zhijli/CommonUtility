﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtility
{
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
