using ConsoleProject.StrategyPatterm;
using ConsoleProject.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Menus.UserInfoMenus
{
    public class LoginMenu
    {
        public static void LoggingIn()
        {
            List<User> currentUserDatabase = DBContext.Users;

            Console.WriteLine("Please type in your email:");
            string inputEmail = Console.ReadLine();

            if (currentUserDatabase.Any(x => x.Email == inputEmail))
            {
                var found = currentUserDatabase.Single(x => x.Email == inputEmail);

                Console.WriteLine("Please type in your password:");
                string inputPassword = Console.ReadLine();

                if (found.Password == inputPassword)
                {
                    Console.WriteLine("You have succesfully logged in!");
                    //BalanceMenu.Balance(inputEmail);

                    BalanceMenu.Balance(inputEmail);
                }
                else
                {
                    Console.WriteLine("Wrong password!");
                    Console.WriteLine("Press 1 for entering the credentials again.");
                    Console.WriteLine("Press 2 for entering the security question and answer");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            {
                                LoggingIn();
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Type in your security question:");
                                string inputQuestion = Console.ReadLine();

                                Console.WriteLine("Type in your security answer:");
                                string inputAnswer = Console.ReadLine();

                                if (found.SecurityQuestion == inputQuestion && found.SecurityAnswer == inputAnswer)
                                {
                                    Console.WriteLine("You have succesfully logged in!");
                                    
                                    BalanceMenu.Balance(inputEmail);
                                }
                                else
                                {
                                    Console.WriteLine("Wrong question or answer! Please try again!");
                                    LoggingIn();
                                    return;
                                }

                                break;
                            }
                    }

                    return;
                }
            }
            else
            {
                Console.WriteLine("Wrong email! Please try again!");
                LoggingIn();
                return;
            }

        }
    }
}
