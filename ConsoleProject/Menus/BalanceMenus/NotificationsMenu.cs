using ConsoleProject.BLL;
using ConsoleProject.Domain;
using ConsoleProject.StrategyPatterm;
using ConsoleProject.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Menus.BalanceMenus
{
    public class NotificationsMenu
    {
        public static void ShowNotifications(User user)
        {
            var context = new ShowBalanceContext();
            context.SetStrategy(new ShownBalanceStrategy());

            Console.WriteLine();
            Console.WriteLine("NOTIFICATIONS MENU");

            if(DBContext.Offers.Any(x => x.RecipientID == user.UserID))
            {
                if (DBContext.Offers.Where(x => x.RecipientID == user.UserID).ToList().Count() == 0)
                {
                    Console.WriteLine("You don't have any notifications!");
                }
                else
                {
                    int index = 1;
                    foreach (var offer in DBContext.Offers.Where(x => x.RecipientID == user.UserID))
                    {
                        Console.WriteLine($"Trade offer number {index}: \n{offer.ToString()}");
                        index++;
                    }

                    Console.WriteLine();
                    Console.WriteLine("Type in the index value of an offer to select it:");
                    Console.WriteLine($"Or {index} to go back to the BALANCE page.");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    if (choice < 0 || choice > index)
                    {
                        Console.WriteLine("Wrong choice! Please try again!");
                        ShowNotifications(user);
                    }
                    else if (choice == index)
                    {
                        Console.WriteLine("Going back to BALANCE page...");
                        context.ShowBalance(user.Email);

                    }
                    else
                    {
                        Console.WriteLine($"The offer is:\n{DBContext.Offers.Where(x => x.RecipientID == user.UserID).ToList()[choice].ToString()}");
                        Console.WriteLine("Press 1 to ACCEPT the offer.");
                        Console.WriteLine("Press 2 to DENY the offer.");

                        int choice2 = Convert.ToInt32(Console.ReadLine());

                        switch (choice2)
                        {
                            case 1:
                                {
                                    Console.WriteLine("Trade offer accepted!");
                                    UserToUserTradeBusinessLogic.ApplyTrade(DBContext.Offers.Where(x => x.RecipientID == user.UserID).ToList()[choice]);
                                    var offerToRemove = DBContext.Offers.Where(x => x.RecipientID == user.UserID).ToList()[choice];

                                    DBContext.Offers.Remove(offerToRemove);

                                    context.ShowBalance(user.Email);
                                    break;
                                }
                            case 2:
                                {
                                    Console.WriteLine("Trade offer denied!");
                                    var offerToRemove = DBContext.Offers.Where(x => x.RecipientID == user.UserID).ToList()[choice];

                                    DBContext.Offers.Remove(offerToRemove);

                                    context.ShowBalance(user.Email);
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Wrong choice! Please try again!");
                                    ShowNotifications(user);
                                    break;
                                }
                        }
                    }
                }
            }

            
            
        }
    }
}
