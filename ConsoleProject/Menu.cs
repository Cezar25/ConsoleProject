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
            Console.Clear();
            Console.WriteLine("WELCOME TO CRYPTO AVENUE! ...THE BEST CRYPTO TRADING APP!");
            Console.WriteLine("For logging in, press 1!");
            Console.WriteLine("For registering, press 2!");

            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    {
                        LoggingIn();
                        break;
                    }
                case 2:
                    {
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid choice! Please try again!");
                        Start();
                        break;
                    }
            }
        }
        public static void LoggingIn()
        {
            List<User> currentUserDatabase = DBContext.GetUsers();

            Console.WriteLine("Please type in your email:");
            string inputEmail = Console.ReadLine();

            if(currentUserDatabase.Any(x => x.Email == inputEmail))
            {
                var found = currentUserDatabase.Single(x => x.Email == inputEmail);

                Console.WriteLine("Please type in your password:");
                string inputPassword = Console.ReadLine();
                
                if(found.Password == inputPassword)
                {
                    Console.WriteLine("You have succesfully logged in!");
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

                                if(found.SecurityQuestion == inputQuestion && found.SecurityAnswer == inputAnswer)
                                {
                                    Console.WriteLine("You have succesfully logged in!");
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
