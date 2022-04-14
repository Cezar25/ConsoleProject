using ConsoleProject.BLL;
using ConsoleProject.Domain;
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
    public class HiddenBalanceStrategy : IShowBalanceStrategy
    {
        public void ShowBalance(string userEmail)
        {
            Console.Clear();
            Console.WriteLine("BALANCE PAGE");

            var cryptoAvenueContext = new CryptoAvenueContext();

            if (cryptoAvenueContext.Users.Any(x => x.Email == userEmail))
            {
                var balanceOwner = cryptoAvenueContext.Users.Single(x => x.Email == userEmail);

                Console.WriteLine($"Welcome {balanceOwner.Email}!");
                Console.WriteLine($"Your total balance amount is ---");
                AccountBusinessLogic.DisplayPrivacy(balanceOwner);
                Console.WriteLine();
                Console.WriteLine("Below you have a list of all the coins in your portofolio");
                UserPortofolioBusinessLogic.DisplayHiddenPortofolio(balanceOwner);

                Console.WriteLine("\nWhat do you wish to do now?");
                Console.WriteLine("Press 1 for depositing money.");
                Console.WriteLine("Press 2 for withdrawing money.");
                Console.WriteLine("Press 3 for editing your profile");
                Console.WriteLine("Press 4 to show your balance amount.");
                Console.WriteLine("Press 5 to make your profile private/public");
                Console.WriteLine("Press 6 for logging out");

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
                            //BalanceMenu.Balance(userEmail);
                            var context = new ShowBalanceContext();
                            context.SetStrategy(new ShownBalanceStrategy());
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
