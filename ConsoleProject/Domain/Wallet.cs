using ConsoleProject.DAL;
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
        public Guid CoinID { get; set; }

        public Wallet(Guid coinID, double coinAmount)
        {
            CoinID = coinID;
            if (CoinDB.Coins.Any(x => x.CoinID == coinID))
            {
                CoinType = CoinDB.Coins.SingleOrDefault(x => x.CoinID == coinID);
            }
            CoinAmount = coinAmount;
        }
    }

}

