using ConsoleProject.Menus.UserInfoMenus;
using ConsoleProject.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Menus.BalanceMenus
{
    public class HiddenBalanceMenu
    {
        public static void HiddenBalance(string email)
        {
            Console.Clear();
            Console.WriteLine("BALANCE PAGE");

            if (DBContext.Users.Any(x => x.Email == email))
            {
                var balanceOwner = DBContext.Users.Single(x => x.Email == email);

                Console.WriteLine($"Welcome {balanceOwner.Email}!");
                Console.WriteLine($"Your total balance amount is ---");
                Console.WriteLine();
                Console.WriteLine("Below you have a list of all the coins in your portofolio");
                balanceOwner.DisplayHiddenPortofolio();

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
                            Console.Clear();
                            Console.WriteLine("DEPOSIT PAGE");
                            Console.WriteLine("Please type in your credit card number:");
                            string cardNumber = Console.ReadLine();
                            Console.WriteLine("Please type in your credit card's expiration month(1-12):");
                            int cardExpirationMonth = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Please type in your credit card's expiration year:");
                            int cardExpirationYear = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Please type in your credit card's CVV:");
                            int cardCVV = Convert.ToInt32(Console.ReadLine());

                            DepositMenu.DepositMoney(balanceOwner);

                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("WITHDRAW PAGE");
                            Console.WriteLine("Please type in your credit card number:");
                            string cardNumber = Console.ReadLine();
                            Console.WriteLine("Please type in your credit card's expiration month(1-12):");
                            int cardExpirationMonth = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Please type in your credit card's expiration year:");
                            int cardExpirationYear = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Please type in your credit card's CVV:");
                            int cardCVV = Convert.ToInt32(Console.ReadLine());

                            WithdrawMenu.WithdrawMoney(balanceOwner);

                            break;
                        }
                    case 3:
                        {
                            EditProfileMenu.EditProfile(email);
                            break;
                        }
                    case 4:
                        {
                            BalanceMenu.Balance(email);
                            break;
                        }
                    case 5:
                        {
                            balanceOwner.ChangeProfileType(balanceOwner.PrivateProfile);
                            HiddenBalance(email);
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
                            HiddenBalance(email);
                            break;
                        }
                }
            }
        }
    }
}
