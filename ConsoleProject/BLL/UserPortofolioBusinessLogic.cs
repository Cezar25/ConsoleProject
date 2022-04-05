using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.BLL
{
    public class UserPortofolioBusinessLogic
    {
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
