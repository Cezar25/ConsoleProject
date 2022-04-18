using ConsoleProject.DAL;
using ConsoleProject.Domain;
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
            var db = new CryptoAvenueContext();

            amountOfCoinSold = Math.Round(amountOfCoinSold,3);
            if(amountOfCoinSold > wallet.CoinAmount)
            {
                Console.WriteLine("Amount selected is greater than the amount available!");
                return;
            }

            double amountOfCoinSoldInEUR = amountOfCoinSold * wallet.CoinType.ValueInEUR;

            if (db.Wallets.Where(x => x.UserID == user.UserID).Any(x => x.CoinType.Abreviation == boughtCoinAbreviation))
            {
                double amountOfCoinBought = amountOfCoinSoldInEUR / db.Wallets.Where(x => x.UserID == user.UserID).FirstOrDefault(x => x.CoinType.Abreviation == boughtCoinAbreviation).CoinType.ValueInEUR;
                db.Wallets.Where(x => x.UserID == user.UserID).FirstOrDefault(x => x.CoinType.Abreviation == boughtCoinAbreviation).CoinAmount += amountOfCoinBought;
            }
            else
            {
                if(CoinDB.Coins.Any(x => x.Abreviation == boughtCoinAbreviation))
                {
                    double amountOfCoinBought = amountOfCoinSoldInEUR / CoinDB.Coins.FirstOrDefault(x => x.Abreviation == boughtCoinAbreviation).ValueInEUR;
                    db.Wallets.Add(new Wallet() { CoinID = CoinDB.Coins.Single(x => x.Abreviation == boughtCoinAbreviation).CoinID,UserID = user.UserID, CoinAmount =  amountOfCoinBought });
                }
            }

            wallet.CoinAmount -= amountOfCoinSold;

            db.SaveChanges();

        }
        public static double GetBoughtCoinAmount(double soldCoinAmount, string soldCoinAbreviation, string boughtCoinAbreviation)
        {
            if(CoinDB.Coins.Any(x => x.Abreviation == soldCoinAbreviation) && CoinDB.Coins.Any(x => x.Abreviation == boughtCoinAbreviation))
            {
                return (CoinDB.Coins.Single(x => x.Abreviation == soldCoinAbreviation).ValueInEUR * soldCoinAmount) / CoinDB.Coins.Single(x => x.Abreviation == boughtCoinAbreviation).ValueInEUR;
            }
            return 0;
        }
        public static double GetSoldCoinAmount(double boughtCoinAmount, string boughtCoinAbreviation, string soldCoinAbreviation)
        {
            if (CoinDB.Coins.Any(x => x.Abreviation == soldCoinAbreviation) && CoinDB.Coins.Any(x => x.Abreviation == boughtCoinAbreviation))
            {
                return (CoinDB.Coins.Single(x => x.Abreviation == boughtCoinAbreviation).ValueInEUR * boughtCoinAmount) / CoinDB.Coins.Single(x => x.Abreviation == soldCoinAbreviation).ValueInEUR;
            }
            return 0;
        }
        public static void GetConversionRate(string soldCoinAbreviation, string boughtCoinAbreviation)
        {
            if (CoinDB.Coins.Any(x => x.Abreviation == soldCoinAbreviation) && CoinDB.Coins.Any(x => x.Abreviation == boughtCoinAbreviation))
            {
                double rate = CoinDB.Coins.Single(x => x.Abreviation == soldCoinAbreviation).ValueInEUR / CoinDB.Coins.Single(x => x.Abreviation == boughtCoinAbreviation).ValueInEUR;
                Console.WriteLine($"1 {soldCoinAbreviation}  =  {Math.Round(rate, 6)} {boughtCoinAbreviation}");
            }
        }
        public static double GetConversionRateDouble(string soldCoinAbreviation, string boughtCoinAbreviation)
        {
            if (CoinDB.Coins.Any(x => x.Abreviation == soldCoinAbreviation) && CoinDB.Coins.Any(x => x.Abreviation == boughtCoinAbreviation))
            {
                double rate = CoinDB.Coins.Single(x => x.Abreviation == soldCoinAbreviation).ValueInEUR / CoinDB.Coins.Single(x => x.Abreviation == boughtCoinAbreviation).ValueInEUR;
                return rate;
            }
            return 0;
        }
        public static Guid GetIDByAbvreviation(string coinAbreviation)
        {
            return new Guid();
        }

    }
}
