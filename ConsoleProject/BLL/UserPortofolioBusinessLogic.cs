using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.BLL
{
    public class UserPortofolioBusinessLogic
    {
        //public void ChangeProfileType(bool type)
        //{
        //    Console.WriteLine("Press 1 to make your profile");
        //    if (type == false)
        //        Console.WriteLine("Public");
        //    else
        //        Console.WriteLine("Private");

        //    type = !type;
        //    PrivateProfile = type;
        //}

        //public void DisplayPortofolio()
        //{
        //    Console.WriteLine();
        //    foreach (var wallet in Wallets)
        //    {
        //        Console.WriteLine($"Coin:  {wallet.CoinType.Abreviation} ({wallet.CoinType.Name})       amount:    {wallet.CoinAmount}");
        //    }
        //    Console.WriteLine();
        //}

        //public void DisplayHiddenPortofolio()
        //{
        //    Console.WriteLine();
        //    foreach (var wallet in Wallets)
        //    {
        //        Console.WriteLine($"Coin:  {wallet.CoinType.Abreviation} ({wallet.CoinType.Name})       amount:    ---");
        //    }
        //    Console.WriteLine();
        //}
        public static double GetTotalPortofolioValueInEUR(User user)
        {
            double total = 0;
            foreach (var wallet in user.Wallets)
            {
                total += wallet.CoinType.ValueInEUR * wallet.CoinAmount;
            }
            return total;
        }
        public static double GetTotalPortofolioValueInUSD(User user)
        {
            double total = 0;
            foreach (var wallet in user.Wallets)
            {
                total += wallet.CoinType.ValueInUSD * wallet.CoinAmount;
            }
            return total;
        }
        public static double GetTotalPortofolioValueInBTC(User user)
        {
            double total = 0;
            foreach (var wallet in user.Wallets)
            {
                total += wallet.CoinType.ValueInBTC * wallet.CoinAmount;
            }
            return total;
        }
    }
}
