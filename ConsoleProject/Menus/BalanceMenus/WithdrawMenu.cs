using ConsoleProject.Menus.UserInfoMenus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Menus.BalanceMenus
{
    public class WithdrawMenu
    {
        public static void WithdrawMoney(User user)
        {

            Console.WriteLine("Please select the fiat currency you want to withdraw:");
            Console.WriteLine("Press 1 for EUR.");
            Console.WriteLine("Press 2 for USD.");
            Console.WriteLine("Press 0 for going back to the balance page.");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 0:
                    {
                        BalanceMenu.Balance(user.Email);
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("Please enter the amount(double) of EUR you want to withdraw:");
                        double amount = Convert.ToDouble(Console.ReadLine());
                        user.RemoveCoin("EUR", amount);
                        Console.WriteLine("Deposit was succesful!");

                        BalanceMenu.Balance(user.Email);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Please enter the amount(double) of USD you want to withddraw:");
                        double amount = Convert.ToDouble(Console.ReadLine());
                        user.RemoveCoin("USD", amount);
                        Console.WriteLine("Deposit was succesful!");

                        BalanceMenu.Balance(user.Email);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Wrong option! Please try again!");
                        WithdrawMoney(user);
                        break;
                    }
            }
        }
    }
}
