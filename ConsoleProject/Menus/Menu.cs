using ConsoleProject.Menus.UserInfoMenus;
using ConsoleProject.StrategyPatterm;
using ConsoleProject.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    public class Menu
    {
        public static void Start()
        {
            //Console.Clear();
            //while (true)
            //{
                Console.WriteLine();
                Console.WriteLine("WELCOME TO CRYPTO AVENUE! ...THE BEST CRYPTO TRADING APP!");
                Console.WriteLine("For logging in, press 1!");
                Console.WriteLine("For registering, press 2!");
                Console.WriteLine("For displaying the user database, press 3!");
                Console.WriteLine("For exiting the program, press 0!");

                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 0:
                    {
                        Console.WriteLine("Exiting the program...");
                        return;
                        //break;
                    }
                    case 1:
                        {
                            LoginMenu.LoggingIn(); 

                            break;
                        }
                    case 2:
                        {
                            RegisterMenu.Register();
                            break;
                        }
                    case 3:
                    {
                        Console.WriteLine("The USER DATABASE is:");
                        DBContext.DisplayUSers();
                        Start();
                        break;
                    }
                    default:
                        {
                            Console.WriteLine("Invalid choice! Please try again!");
                            Start();
                            break;
                        }
                }
            //}
        }
       
    }
}
