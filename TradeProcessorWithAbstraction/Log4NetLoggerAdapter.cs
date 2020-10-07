using System;
using System.Collections.Generic;
using System.Text;
using TradeProcessorWithAbstraction.Abstraction;

namespace TradeProcessorWithAbstraction
{
    public class Log4NetLoggerAdapter : ILogger
    {
        ILog logger;
        public Log4NetLoggerAdapter(ILog logger)
        {
            this.logger = logger;

        }
        public Log4NetLoggerAdapter()
        {

        }
        public void LogError()
        {
            throw new NotImplementedException();
        }

        public void LogInfo()
        {
            throw new NotImplementedException();
        }

        public void LogWarning()
        {
            throw new NotImplementedException();
        }
    }
}
