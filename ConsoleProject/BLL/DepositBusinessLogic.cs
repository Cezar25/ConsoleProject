using ConsoleProject.DAL;
using ConsoleProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.BLL
{
    public class DepositBusinessLogic
    {
        public static void AddCoin(User user, string coinAbreviation, double amount)
        {
            if (user.Wallets.Any(x => x.CoinType.Abreviation == coinAbreviation))  //Check if there is a wallet coitaining the inserted coin type
            {
                user.Wallets.Single(x => x.CoinType.Abreviation == coinAbreviation).CoinAmount += amount;
            }
            else
            {
                if (CoinDB.Coins.Any(x => x.Abreviation == coinAbreviation))
                {
                    user.Wallets.Add(new Wallet(CoinDB.Coins.Single(x => x.Abreviation == coinAbreviation), amount));
                }
            }
        }
    }
}
