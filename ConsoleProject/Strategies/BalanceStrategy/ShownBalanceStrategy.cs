using ConsoleProject.BLL;
using ConsoleProject.Menus.AppTradeMenus;
using ConsoleProject.Menus.BalanceMenus;
using ConsoleProject.Menus.UserInfoMenus;
using ConsoleProject.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.StrategyPatterm
{
    public class ShownBalanceStrategy : IShowBalanceStrategy
    {
        public void ShowBalance(string userEmail)
        {
            //Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("BALANCE PAGE");

            if (DBContext.Users.Any(x => x.Email == userEmail))
            {
                var balanceOwner = DBContext.Users.Single(x => x.Email == userEmail);

                Console.WriteLine($"Welcome {balanceOwner.Email}!");
                Console.WriteLine($"Your total balance amount is:    {UserPortofolioBusinessLogic.GetTotalPortofolioValueInEUR(balanceOwner)} EUR");
                AccountBusinessLogic.DisplayPrivacy(balanceOwner);

                Console.WriteLine();
                Console.WriteLine("Below you have a list of all the coins in your portofolio");
                AccountBusinessLogic.DisplayPortofolio(balanceOwner);

                Console.WriteLine("\nWhat do you wish to do now?");
                Console.WriteLine("Press 1 for depositing money.");
                Console.WriteLine("Press 2 for withdrawing money.");
                Console.WriteLine("Press 3 for editing your profile");
                Console.WriteLine("Press 4 to hide your balance amount.");
                Console.WriteLine("Press 5 to make your profile private/public");
                Console.WriteLine("Press 6 to trade with the app");
                Console.WriteLine("Press 7 for logging out");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            
                            GetCreditCardInfoMenu.GetCreditCardInfo(balanceOwner);

                            break;
                        }
                    case 2:
                        {
                            GetBankAccountInfoMenu.GetBankAccountInfo(balanceOwner);

                            break;
                        }
                    case 3:
                        {
                            EditProfileMenu.EditProfile(balanceOwner);
                            break;
                        }
                    case 4:
                        {
                            var context = new ShowBalanceContext();
                            context.SetStrategy(new HiddenBalanceStrategy());
                            context.ShowBalance(userEmail);
                            break;
                        }
                    case 5:
                        {
                            AccountBusinessLogic.ChangeProfileType(balanceOwner);
                            ShowBalance(userEmail);
                            break;
                        }
                    case 6:
                        {
                            TradeWithAppMenu.TradeWithApp(balanceOwner);
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Logging out......");
                            Menu.Start();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong choice, please try again!");
                            ShowBalance(userEmail);
                            break;
                        }
                }
            }
        }
    }
}
