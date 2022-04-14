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
            var db = new CryptoAvenueContext();

            var actualUser = db.Users.Where(x => x.Equals(user)).FirstOrDefault();

            if (actualUser.Wallets.Any(x => x.CoinType.Abreviation == coinAbreviation))  //Check if there is a wallet coitaining the inserted coin type
            {
                actualUser.Wallets.Single(x => x.CoinType.Abreviation == coinAbreviation).CoinAmount += amount;
            }
            else
            {
                if (db.Coins.Any(x => x.Abreviation == coinAbreviation))
                {
                    actualUser.Wallets.Add(new Wallet(db.Coins.Single(x => x.Abreviation == coinAbreviation).CoinID, amount));
                }
            }
            db.SaveChanges();
        }
    }
}
