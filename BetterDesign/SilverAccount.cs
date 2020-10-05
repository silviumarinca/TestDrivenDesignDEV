using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterDesign
{
    public class SilverAccount : AccountBase
    {
        private const int SilverTransactionCostPerPoint = 10;
        public override int CalculateRewardPoints(decimal amount)
        {
            return Math.Max((int)decimal.Floor(amount / SilverTransactionCostPerPoint), 0);
        }
    }
}
