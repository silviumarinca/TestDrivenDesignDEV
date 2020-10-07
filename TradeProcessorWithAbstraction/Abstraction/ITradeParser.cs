using System.Collections.Generic;

namespace TradeProcessorWithAbstraction
{
    public interface ITradeParser
    {

        IEnumerable<TradeRecord> Parse(IEnumerable<string> tradeData);
    }
}