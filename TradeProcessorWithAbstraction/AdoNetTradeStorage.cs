using System;
using System.Collections.Generic;
using System.Text;
using TradeProcessorWithAbstraction.Abstraction;

namespace TradeProcessorWithAbstraction
{
    public class AdoNetTradeStorage : ITradeStorage
    {
        private ILogger logger;

        public AdoNetTradeStorage(ILogger logger)
        {
            this.logger = logger;
        }
        public void Persist(IEnumerable<TradeRecord> record)
        {
            throw new NotImplementedException();
        }
    }
}
