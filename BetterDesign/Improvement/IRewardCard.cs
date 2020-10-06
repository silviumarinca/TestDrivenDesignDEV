using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterDesign.Improvement
{
    public interface IRewardCard
    {

        int RewardPoints {
            get;
        }
        void CalculateRewardPoints(decimal transactionAmount, decimal acountBalance);
    }
}
