using System.Collections.Generic;

namespace TradeProcessorWithAbstraction
{
    public interface ITradeDataProvider
    {

        IEnumerable<string> GetTradeData();
    }
}