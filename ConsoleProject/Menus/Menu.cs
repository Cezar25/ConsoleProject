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
                            LoggingIn();
                            break;
                        }
                    case 2:
                        {
                            Register();
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
        public static void LoggingIn()
        {
            List<User> currentUserDatabase = DBContext.Users;

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
                    Balance(inputEmail);
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
                                    Balance(inputEmail);
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

            Balance(inputEmail);
        }

        public static void EditProfile(string email)
        {
            //Console.Clear();
            Console.WriteLine();
            Console.WriteLine("PROFILE EDITING PAGE");

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
                        Balance(email);
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("Please enter your new email adress:");
                        var newEmail = Console.ReadLine();

                        if(DBContext.Users.Any(x => x.Email == email))
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

        public static void Balance(string email) //Show balance (not hidden)
        {
            Console.Clear();
            Console.WriteLine("BALANCE PAGE");
            
            if(DBContext.Users.Any(x => x.Email == email))
            {
                var balanceOwner = DBContext.Users.Single(x => x.Email == email);

                Console.WriteLine($"Welcome {balanceOwner.Email}!");
                Console.WriteLine($"Your total balance amount is ");
                balanceOwner.DisplayPrivacy();

                Console.WriteLine();
                Console.WriteLine("Below you have a list of all the coins in your portofolio");
                balanceOwner.DisplayPortofolio();

                Console.WriteLine("\nWhat do you wish to do now?");
                Console.WriteLine("Press 1 for depositing money.");
                Console.WriteLine("Press 2 for withdrawing money.");
                Console.WriteLine("Press 3 for editing your profile");
                Console.WriteLine("Press 4 to hide your balance amount.");
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

                            DepositMoney(balanceOwner);

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

                            WithdrawMoney(balanceOwner);

                            break;
                        }
                    case 3:
                        {
                            EditProfile(email);
                            break;
                        }
                    case 4:
                        {
                            HiddenBalance(email);
                            break;
                        }
                    case 5:
                        {
                            balanceOwner.ChangeProfileType(balanceOwner.PrivateProfile);
                            Balance(email);
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Logging out......");
                            Start();
                            break;

                        }
                    default:
                        {
                            Console.WriteLine("Wrong choice, please try again!");
                            Balance(email);
                            break;
                        }
                }
            }

            
        }        

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

                            DepositMoney(balanceOwner);

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

                            WithdrawMoney(balanceOwner);

                            break;
                        }
                    case 3:
                        {
                            EditProfile(email);
                            break;
                        }
                    case 4:
                        {
                            Balance(email);
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
                            Start();
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

        public static void DepositMoney(User user)
        {
            
            Console.WriteLine("Please select the fiat currency you want to deposit:");
            Console.WriteLine("Press 1 for EUR.");
            Console.WriteLine("Press 2 for USD.");
            Console.WriteLine("Press 0 for going back to the balance page.");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 0:
                    {
                        Balance(user.Email);
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("Please enter the amount(double) of EUR you want to deposit:");
                        double amount = Convert.ToDouble(Console.ReadLine());
                        user.AddCoins("EUR", amount);
                        Console.WriteLine("Deposit was succesful!");

                        Balance(user.Email);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Please enter the amount(double) of USD you want to deposit:");
                        double amount = Convert.ToDouble(Console.ReadLine());
                        user.AddCoins("USD", amount);
                        Console.WriteLine("Deposit was succesful!");

                        Balance(user.Email);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Wrong option! Please try again!");
                        DepositMoney(user);
                        break;
                    }
            }
        }

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
                        Balance(user.Email);
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("Please enter the amount(double) of EUR you want to withdraw:");
                        double amount = Convert.ToDouble(Console.ReadLine());
                        user.DeleteCoins("EUR", amount);
                        Console.WriteLine("Deposit was succesful!");

                        Balance(user.Email);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Please enter the amount(double) of USD you want to withddraw:");
                        double amount = Convert.ToDouble(Console.ReadLine());
                        user.DeleteCoins("USD", amount);
                        Console.WriteLine("Deposit was succesful!");

                        Balance(user.Email);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Wrong option! Please try again!");
                        DepositMoney(user);
                        break;
                    }
            }
        }

        public static void GetCreditCardInfo()
        {
            
        }

    }
}
