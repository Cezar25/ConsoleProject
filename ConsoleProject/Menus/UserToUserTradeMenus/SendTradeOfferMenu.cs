using ConsoleProject.BLL;
using ConsoleProject.Domain;
using ConsoleProject.StrategyPatterm;
using ConsoleProject.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Menus.UserToUserTradeMenus
{
    public class SendTradeOfferMenu
    {
        public static void SendTradeOffer(User sender, User recipient)
        {
            var context = new ShowBalanceContext();
            context.SetStrategy(new ShownBalanceStrategy());

            Console.WriteLine("Choose which coin you wish to buy from the user:");
            int boughtIndex = 0;

            foreach (var coin in recipient.Wallets)
            {
                    Console.WriteLine($"Press {boughtIndex} for {coin.CoinType.Abreviation}.");
                    boughtIndex++;    
            }

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice < 0 || choice > boughtIndex)
            {
                Console.WriteLine("Wrong choice! Please try again!");
                SendTradeOffer(sender, recipient);
            }
            else
            {
                Console.WriteLine($"Please type in the amount of {recipient.Wallets[choice].CoinType.Abreviation} you wish to buy from the user   (amount available: {recipient.Wallets[choice].CoinAmount})");
                Console.WriteLine($"Selected coin: {recipient.Wallets[choice].CoinType.Abreviation}");
                double boughtAmount = Convert.ToDouble(Console.ReadLine());

                if(boughtAmount < 0 || boughtAmount > recipient.Wallets[choice].CoinAmount)
                {
                    Console.WriteLine("Wrong choice! Please try again!");
                    SendTradeOffer(sender, recipient);
                }
                else
                {
                    Console.WriteLine("Please select the coin you wish to sell from your portofolio:");
                    int soldIndex = 0;
                    foreach (var coin in sender.Wallets)
                    {
                
                            Console.WriteLine($"Press {soldIndex} for {coin.CoinType.Abreviation}.");
                            soldIndex++;

                    }

                    int choice2 = Convert.ToInt32(Console.ReadLine());

                    if (choice2 < 0 || choice2 > soldIndex)
                    {
                        Console.WriteLine("Wrong choice! Please try again!");
                        SendTradeOffer(sender, recipient);
                    }
                    else
                    {
                        Console.WriteLine($"Buying {boughtAmount} {recipient.Wallets[choice].CoinType.Abreviation} worth {AppTradeBusinessLogic.GetSoldCoinAmount(boughtAmount, recipient.Wallets[choice].CoinType.Abreviation, sender.Wallets[choice2].CoinType.Abreviation)} {sender.Wallets[choice2].CoinType.Abreviation} ");
                        AppTradeBusinessLogic.GetConversionRate(sender.Wallets[choice2].CoinType.Abreviation, recipient.Wallets[choice].CoinType.Abreviation);

                        DBContext.Offers.Add(new TradeOffer
                        {
                            SenderID = sender.UserID,
                            RecipientID = recipient.UserID,
                            SentCoinID = sender.Wallets[choice2].CoinType.CoinID,
                            SentAmount = AppTradeBusinessLogic.GetSoldCoinAmount(boughtAmount, recipient.Wallets[choice].CoinType.Abreviation, sender.Wallets[choice2].CoinType.Abreviation),
                            ReceivedCoinID = recipient.Wallets[choice].CoinType.CoinID,
                            ReceivedAmount = boughtAmount
                        });

                        context.ShowBalance(sender.Email);
                    }
                }
            }
        }
    }
}
