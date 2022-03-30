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
            //Console.Clear();
            Console.WriteLine("Welcome to the App Trading page!");
            Console.WriteLine("Here you can exchange currencies from your portofolio directly with the app wallet INSTANTLY!");
            Console.WriteLine();
            Console.WriteLine("Please select the coin you want to SELL!");

            int index = 1;
            foreach (var coin in user.CoinAmount.Item1)
            {
                int foundIndex = user.CoinAmount.Item1.IndexOf(coin);
                if(user.CoinAmount.Item2[foundIndex] > 0)
                {
                    Console.WriteLine($"Press {index} to trade {coin.Abreviation}.      (available amount: {user.CoinAmount.Item2[foundIndex]})");
                    index++;
                }
            }

            int choice = Convert.ToInt32(Console.ReadLine());

            if(choice < 1 || choice > index)
            {
                Console.WriteLine("Wrong choice! Please try again!");
                TradeWithApp(user);
            }
            else
            {
                Console.WriteLine($"Please enter the amount of {user.CoinAmount.Item1[choice].Abreviation} you wish to sell:");
                double amountToBeSold = Convert.ToDouble(Console.ReadLine());

                if(amountToBeSold > user.CoinAmount.Item2[choice] || amountToBeSold < 0)
                {
                    Console.WriteLine("Wrong amount! Please try again!");
                    TradeWithApp(user);
                }
                else
                {
                    Console.WriteLine("Please select the coin you want to BUY!");
                }
            }
        }
    }
}
