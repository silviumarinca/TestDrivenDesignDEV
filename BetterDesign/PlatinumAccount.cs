using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterDesign
{
    
    public class PlatinumAccount : AccountBase
    {
        private const int PlatinumTransactionCostPerPoint = 10;
        private const int PlatinumBalanceCostPerPoint = 2000;
        public override int CalculateRewardPoints(decimal amount)
        {
            return Math.Max((int)(decimal.Floor(amount / PlatinumBalanceCostPerPoint) + (amount / PlatinumTransactionCostPerPoint)), 0);
        }
    }
}
