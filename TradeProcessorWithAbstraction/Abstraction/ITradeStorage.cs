using System.Collections.Generic;

namespace TradeProcessorWithAbstraction
{
    public interface ITradeStorage
    {
       void Persist(IEnumerable<TradeRecord> record);
    }
}