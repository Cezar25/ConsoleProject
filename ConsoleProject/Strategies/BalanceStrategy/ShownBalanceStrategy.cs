using ConsoleProject.BLL;
using ConsoleProject.Domain;
using ConsoleProject.Menus.AppTradeMenus;
using ConsoleProject.Menus.BalanceMenus;
using ConsoleProject.Menus.UserInfoMenus;
using ConsoleProject.Menus.UserToUserTradeMenus;
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
        public void ShowBalance(User user)
        {
            //Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("BALANCE PAGE");

            var db = new CryptoAvenueContext();

            var actualUser = db.Users.Where(x => x.Equals(user)).FirstOrDefault();

            Console.WriteLine($"Welcome {actualUser.Email}!");
            Console.WriteLine($"Your total balance amount is:    {Math.Round(UserPortofolioBusinessLogic.GetTotalPortofolioValueInEUR(actualUser), 3)} EUR");
            AccountBusinessLogic.DisplayPrivacy(actualUser);

            Console.WriteLine();
            Console.WriteLine("Below you have a list of all the coins in your portofolio");
            UserPortofolioBusinessLogic.DisplayPortofolio(actualUser);

            Console.WriteLine("\nWhat do you wish to do now?");
            Console.WriteLine("Press 1 for depositing money.");
            Console.WriteLine("Press 2 for withdrawing money.");
            Console.WriteLine("Press 3 for editing your profile");
            Console.WriteLine("Press 4 to hide your balance amount.");
            Console.WriteLine("Press 5 to make your profile private/public");
            Console.WriteLine("Press 6 to trade with the app");
            Console.WriteLine("Press 7 to search for another user");
            Console.WriteLine("Press 8 view notifications");
            Console.WriteLine("Press 9 for logging out");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    {
                        GetCreditCardInfoMenu.GetCreditCardInfo(actualUser);

                        break;
                    }
                case 2:
                    {
                        GetBankAccountInfoMenu.GetBankAccountInfo(actualUser);

                        break;
                    }
                case 3:
                    {
                        EditProfileMenu.EditProfile(actualUser);

                        break;
                    }
                case 4:
                    {
                        var context = new ShowBalanceContext();
                        context.SetStrategy(new HiddenBalanceStrategy());
                        context.ShowBalance(actualUser);

                        break;
                    }
                case 5:
                    {
                        AccountBusinessLogic.ChangeProfileType(actualUser);
                        ShowBalance(actualUser);
                        break;
                    }
                case 6:
                    {
                        TradeWithAppMenu.TradeWithApp(actualUser);
                        break;
                    }
                case 7:
                    {
                        SearchForUserMenu.SearchForOtherUser(actualUser);
                        break;
                    }
                case 8:
                    {
                        NotificationsMenu.ShowNotifications(actualUser);
                        break;
                    }
                case 9:
                    {
                        Console.WriteLine("Logging out......");
                        Menu.Start();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Wrong choice, please try again!");
                        ShowBalance(actualUser);
                        break;
                    }
            }

        }
    
    }
}
