using ConsoleProject.DAL;
using ConsoleProject.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.BLL
{
    public  class AppTradeBusinessLogic
    {
        public static void ConvertCoinToCoin(User user, Wallet wallet, double amountOfCoinSold, string boughtCoinAbreviation)
        {
            if (amountOfCoinSold > wallet.CoinAmount)
            {
                Console.WriteLine("Amount selected is greater than the amount available!");
                return;
            }
            double soldAmountInBTC = wallet.CoinType.ValueInBTC * amountOfCoinSold;

            if (user.Wallets.Any(x => x.CoinType.Abreviation == boughtCoinAbreviation))
            {
                double amountOfCoinBought = soldAmountInBTC * user.Wallets.Single(x => x.CoinType.Abreviation == boughtCoinAbreviation).CoinType.ValueInBTC;
                user.Wallets.Single(x => x.CoinType.Abreviation == boughtCoinAbreviation).CoinAmount += amountOfCoinBought;
            }
            else
            {
                if (CoinDB.Coins.Any(x => x.Abreviation == boughtCoinAbreviation))
                {
                    double amountOfCoinBought = soldAmountInBTC * CoinDB.Coins.Single(x => x.Abreviation == boughtCoinAbreviation).ValueInBTC;
                    user.Wallets.Add(new Wallet(CoinDB.Coins.Single(x => x.Abreviation == boughtCoinAbreviation), amountOfCoinBought));
                }
            }
            wallet.CoinAmount -= amountOfCoinSold;
        }   
        
    }
}
