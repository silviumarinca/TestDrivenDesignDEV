using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterDesign
{
   public class GoldAccount: AccountBase
    {
        private const int GoldTransactionCostPerPoint = 10;
        private const int GoldBalanceCostPerPoint = 2000;
        public override int CalculateRewardPoints(decimal amount)
        {
            return Math.Max((int)(decimal.Floor(amount / GoldBalanceCostPerPoint)+ (amount / GoldTransactionCostPerPoint)), 0);
        }
    }
}
