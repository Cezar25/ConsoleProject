using ConsoleProject.StrategyPatterm;
using ConsoleProject.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Menus.UserInfoMenus
{
    public class EditProfileMenu
    {
        public static void EditProfile(string email)
        {
            //Console.Clear();
            Console.WriteLine();
            Console.WriteLine("PROFILE EDITING PAGE");
            Console.WriteLine();

            Console.WriteLine("Your current credentials are:");
            if(DBContext.Users.Any(x => x.Email == email))
            {
                var currentUser = DBContext.Users.Single(x => x.Email == email);
                Console.WriteLine(currentUser.ToString());
            }

            Console.WriteLine("What do you wish to change?");
            Console.WriteLine("Press 1 for changing your email.");
            Console.WriteLine("Press 2 for changing your password.");
            Console.WriteLine("Press 3 for changing your user ID.");
            Console.WriteLine("Press 4 for changing your security question and answer.");

            Console.WriteLine("Press 0 for going back to the Balance page");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 0:
                    {
                        BalanceMenu.Balance(email);
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("Please enter your new email adress:");
                        var newEmail = Console.ReadLine();

                        if (DBContext.Users.Any(x => x.Email == email))
                        {
                            var currentUser = DBContext.Users.Single(x => x.Email == email);
                            currentUser.Email = newEmail;
                            int foundIndex = DBContext.Users.IndexOf(currentUser);

                            DBContext.Users[foundIndex] = currentUser;
                        }

                        Console.WriteLine("Email succesfully changed!");
                        EditProfile(newEmail);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Please enter your new email password:");
                        var newPassword = Console.ReadLine();

                        if (DBContext.Users.Any(x => x.Email == email))
                        {
                            var currentUser = DBContext.Users.Single(x => x.Email == email);
                            currentUser.Password = newPassword;
                            int foundIndex = DBContext.Users.IndexOf(currentUser);

                            DBContext.Users[foundIndex] = currentUser;
                        }

                        Console.WriteLine("Password succesfully changed!");
                        EditProfile(email);
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Please enter your new user ID:");
                        var newUserID = Console.ReadLine();

                        if (DBContext.Users.Any(x => x.Email == email))
                        {
                            var currentUser = DBContext.Users.Single(x => x.Email == email);
                            currentUser.UserID = newUserID;
                            int foundIndex = DBContext.Users.IndexOf(currentUser);

                            DBContext.Users[foundIndex] = currentUser;
                        }

                        Console.WriteLine("User ID succesfully changed!");
                        EditProfile(email);
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Please enter your new security question:");
                        var newQuestion = Console.ReadLine();

                        Console.WriteLine("Please enter your new security answer:");
                        var newAnswer = Console.ReadLine();

                        if (DBContext.Users.Any(x => x.Email == email))
                        {
                            var currentUser = DBContext.Users.Single(x => x.Email == email);
                            currentUser.SecurityQuestion = newQuestion;
                            currentUser.SecurityAnswer = newAnswer;
                            int foundIndex = DBContext.Users.IndexOf(currentUser);

                            DBContext.Users[foundIndex] = currentUser;
                        }

                        Console.WriteLine("Security question and answer succesfully changed!");
                        EditProfile(email);
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Wrong choice, please try again!");
                        EditProfile(email);
                        break;
                    }
            }
        }
    }
}
