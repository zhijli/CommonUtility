using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommonUtility
{
    public class LoggerManager
    {
        private List<ILogger> _loggers = new List<ILogger>();

        private object _lock;

        public void AddLogger(ILogger logger)
        {
            _loggers.Add(logger);
        }

        public void Execute(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                foreach (var logger in _loggers)
                {
                    logger.LogException(ex);
                }
            }

        }

        public void LogInfo(string message)
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
