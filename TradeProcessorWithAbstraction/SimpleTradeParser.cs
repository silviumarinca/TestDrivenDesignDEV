using System;
using System.Collections.Generic;
using System.Text;

namespace TradeProcessorWithAbstraction
{
  public   class SimpleTradeParser : ITradeParser
    {
       private ITradeMapper tradeMapper;
       private ITradeValidator validator;

        public SimpleTradeParser(ITradeMapper tradeMapper, ITradeValidator validator)
        {
            this.validator = validator;
            this.tradeMapper = tradeMapper;
        }

        public IEnumerable<TradeRecord> Parse(IEnumerable<string> tradeData)
        {
            var trades = new List<TradeRecord>();
            var lineCount = 1;
            foreach (var line in tradeData) {
                var fields = line.Split(new char[] { ',' });
                if (!validator.Validate(fields)) {
                    continue;
                }

                var trade = tradeMapper.Map(fields); 
                trades.Add(trade); 
                lineCount++;

            }
            return trades;
        }
    }
}
