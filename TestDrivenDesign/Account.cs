using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenDesign
{
   public  class Account
    {
        private decimal balance { get; set; }
        public decimal amount { get; set; }
        public decimal Balance { get { return this.balance; }
      
            private set { this.balance = value; } }
        public virtual void AddTransaction(decimal balance) {
            if (balance == 1m) throw new DomainException();
            this.balance += balance;

            RewardPoints += CalculaterewardPoints(amount);
            Balance += amount;
        
        }
        private const int SilverTransactionCostPerPoint = 10;
        private const int GoldTransactionCostPerPoint = 5;
        private const int PlatinumTransactionCostPerPoint = 2;
        private const int GoldBalanceCostPerPoint = 2000;
        private const int PlatinumBalanceCostPerPoint = 1000;
        private int CalculaterewardPoints(decimal amount)
        {
            int points;
            switch (type)
            {
                case AccountType.Silver: points = (int)decimal.Floor(amount/10);break;
                case AccountType.Gold: points = (int)decimal.Floor((Balance / 10000 * 5) + (amount / 5));break;
                case AccountType.Platinum: points = (int)decimal.Ceiling((Balance / 10000 * 10) + (amount / 2)); break;
                default:
                    points = 0;
                    break;
            
            
            }
            return Math.Max(points, 0);
        }
        private readonly AccountType type;

        public Account()
        {

        }

        public int RewardPoints {
            get;
            private set;
        }
        
        public Account(AccountType type)
        {
            this.type = type;

        }
    }

    public enum AccountType { 
            Silver,
            Gold,
            Platinum
    
    }
}
