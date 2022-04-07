using ConsoleProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.BLL
{
    public class WithdrawBusinessLogic
    {
        public static void RemoveCoin(User user, string coinAbreviation, double amount)
        {
            if (user.Wallets.Any(x => x.CoinType.Abreviation == coinAbreviation))  //Check if there is a wallet coitaining the inserted coin type
            {
                if(user.Wallets.Single(x => x.CoinType.Abreviation == coinAbreviation).CoinAmount >= amount)
                {
                    user.Wallets.Single(x => x.CoinType.Abreviation == coinAbreviation).CoinAmount -= amount;
                }
                else
                {
                    Console.WriteLine("Coin could not be removed!");
                }
            }
            else
            {
                Console.WriteLine("Coin could not be removed!");
            }
        }
    }
}
