using ConsoleProject.StrategyPatterm;
using ConsoleProject.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Menus.UserInfoMenus
{
    public class RegisterMenu
    {
        public static void Register()
        {
            Console.Clear();
            Console.WriteLine("WELCOME TO THE REGISTER PAGE!");

            Console.WriteLine("Please type in your email:");
            string inputEmail = Console.ReadLine();

            Console.WriteLine("Please type in your password:");
            string inputPassword = Console.ReadLine();

            Console.WriteLine("Please type in your age:");
            int inputAge = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please type in your USer ID:");
            string inputUserID = Console.ReadLine();

            Console.WriteLine("Please type in your security question:");
            string inputQuestion = Console.ReadLine();

            Console.WriteLine("Please type in your security question answer:");
            string inputAnswer = Console.ReadLine();

            DBContext.Users.Add(new User(inputEmail, inputPassword, inputAge, inputUserID, inputQuestion, inputAnswer));

            Console.WriteLine("You have succesfully registered!");
            //DBContext.DisplayUSers();

            var context = new ShowBalanceContext();
            context.SetStrategy(new ShownBalanceStrategy());
            context.ShowBalance(inputEmail);
        }
    }
}
