using ConsoleProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Domain
{
    public class Wallet
    {        
        public Coin CoinType { get; set; }
        public double CoinAmount { get; set; }
        public Guid WalletID { get; set; } = Guid.NewGuid();
        public User WalletOwner { get; set; } 

        public Wallet(Coin coinType, double coinAmount)
        {
            CoinType = coinType;
            CoinAmount = coinAmount;
        }
    }
}
