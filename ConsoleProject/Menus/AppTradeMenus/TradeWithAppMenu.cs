using ConsoleProject.BLL;
using ConsoleProject.DAL;
using ConsoleProject.Domain.Currency;
using ConsoleProject.Menus.UserInfoMenus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Menus.AppTradeMenus
{
    public class TradeWithAppMenu
    {
        public static void TradeWithApp(User user)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the App Trading page!");
            Console.WriteLine("Here you can exchange currencies from your portofolio directly with the app wallet INSTANTLY!");
            Console.WriteLine();
            Console.WriteLine("Please select the coin you want to SELL!");

            int index = 0;

            foreach (var wallet in user.Wallets)
            {
                Console.WriteLine($"Press {index} for {wallet.CoinType.Abreviation}");
                index++;
            }

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice < 0 || choice > index)
            {
                Console.WriteLine("Wrong choice! Please try again!");
                TradeWithApp(user);
            }
            else
            {
                Console.WriteLine($"Please type in the amount of {user.Wallets[choice].CoinType.Abreviation} you wish to sell");
                double sellAmount = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine();
                Console.WriteLine("Please select the coin you with to BUY from the list:");

                int index2 = 0;

                if (user.Wallets[choice].CoinType.Abreviation == "EUR" || user.Wallets[choice].CoinType.Abreviation == "USD" || user.Wallets[choice].CoinType.Abreviation == "BTC")
                {
                    foreach (var coin in CoinDB.Coins)
                    {
                        Console.WriteLine($"Press {index2} for {coin.Abreviation}");
                        index2++;
                    }
                    int choice2 = Convert.ToInt32(Console.ReadLine());

                    if (choice2 < 0 || choice2 > index2)
                    {
                        Console.WriteLine("Wrong choice! Please try again!");
                        TradeWithApp(user);
                    }
                    else
                    {
                        AppTradeBusinessLogic.ConvertCoinToCoin(user, user.Wallets[choice], sellAmount, CoinDB.Coins[choice2].Abreviation);
                        BalanceMenu.Balance(user.Email);
                    }
                }
                else
                {
                    foreach (var coin in CoinDB.Coins)
                    {
                        if(coin.Abreviation != "EUR" || coin.Abreviation != "USD" || coin.Abreviation != "BTC")
                        {
                            Console.WriteLine($"Press {index2} for {coin.Abreviation}");
                            index2++;
                        }
                        
                    }
                    int choice2 = Convert.ToInt32(Console.ReadLine());

                    if (choice2 < 0 || choice2 > index2)
                    {
                        Console.WriteLine("Wrong choice! Please try again!");
                        TradeWithApp(user);
                    }
                    else
                    {
                        AppTradeBusinessLogic.ConvertCoinToCoin(user, user.Wallets[choice], sellAmount, CoinDB.Coins[choice2].Abreviation);
                        BalanceMenu.Balance(user.Email);
                    }
                }

            }
        }


    }
}
