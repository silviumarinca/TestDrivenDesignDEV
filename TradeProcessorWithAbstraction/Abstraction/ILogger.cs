using System;
using System.Collections.Generic;
using System.Text;

namespace TradeProcessorWithAbstraction.Abstraction
{
   public interface ILogger
    {
        void LogWarning(string text,params object[] items);
        void LogInfo(string text, params object[] items);
        void LogError(string text, params object[] items);
    }
}
