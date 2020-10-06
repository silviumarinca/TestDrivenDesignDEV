using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterDesign.Improvement
{
   internal  class BronzeRewardCard :IRewardCard
    {
        public int RewardPoints
        {
            get;
            private set;
        }
        public void CalculateRewardPoints(decimal transactionAmount, decimal accountBalance) {

            RewardPoints += Math.Max((int)(decimal.Floor(transactionAmount / BronzeTransactionCostPerPoint)),0); 

        }
        private const int BronzeTransactionCostPerPoint = 20;
    }



    internal class PlatinumRewardCard : IRewardCard
    {
        public int RewardPoints
        {
            get;
            private set;
        }
        public void CalculateRewardPoints(decimal transactionAmount, decimal accountBalance)
        {

            RewardPoints += Math.Max((int)(decimal.Ceiling((transactionAmount / PlatinumTransactionCostPerPoint))
                                        + (transactionAmount/ PlatinumBalanceCostPerPoint)), 0);

        }
        private const int PlatinumTransactionCostPerPoint = 20;
        private const int PlatinumBalanceCostPerPoint = 20;
    }
}
