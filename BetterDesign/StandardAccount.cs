﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterDesign
{
    public class StandardAccount : AccountBase
    {
        public override int CalculateRewardPoints(decimal amount)
        {
            return 0;
        }
    }
}
