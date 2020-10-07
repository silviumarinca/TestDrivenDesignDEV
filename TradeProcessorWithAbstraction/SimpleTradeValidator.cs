using System;
using System.Collections.Generic;
using System.Text;
using TradeProcessorWithAbstraction.Abstraction;

namespace TradeProcessorWithAbstraction
{
    public class SimpleTradeValidator : ITradeValidator
    {
       private readonly ILogger logger;
        public SimpleTradeValidator(ILogger logger)
        {
            this.logger = logger;
        }
        public bool Validate(string[] tradeData)
        {
            if (tradeData.Length != 3) {

                logger.LogWarning("Lin malformed. only {1}  fields returned",tradeData.Length);
                return false;
            }
            if (tradeData[0].Length != 6) {
                logger.LogWarning("Trade currencies are malformed '{1}' ", tradeData[0]);
                return false;
            }
            int tradeAmount;
            if (!int.TryParse(tradeData[1], out tradeAmount))
            {
                logger.LogWarning("Trade Amount not a valid integer: '{1}'",tradeData[1]);
                return false;

            }
            decimal tradePrice;
            if (!decimal.TryParse(tradeData[2], out tradePrice))
            {
                logger.LogWarning("Warn: Trade price is not a valid decimal: '{1}'", tradeData[2]);
                return false;

            }
            return true;
        }
    }
}
