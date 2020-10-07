using System;
using System.Collections.Generic;
using System.Text;

namespace TradeProcessorWithAbstraction.Abstraction
{
   public interface ILog
    {
        void WarnFormat();
        void InfoFormat();
        void ErrorFormat();
    }
}
