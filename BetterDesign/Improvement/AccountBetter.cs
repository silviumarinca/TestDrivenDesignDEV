using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterDesign.Improvement
{
   public    class AccountBetter
    {
        public AccountBetter(IRewardCard rewardCard)
        {
            this.rewardCard = rewardCard;

        }
        public decimal Balance {
            get;
            private set;
        }

        public void AddTransaction(decimal amount) {
            rewardCard.CalculateRewardPoints(amount, Balance);
            Balance += amount;

        }

        private readonly IRewardCard rewardCard;
    }
}
