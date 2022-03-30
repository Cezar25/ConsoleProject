using ConsoleProject.DAL;
using ConsoleProject.Domain.Currency;
using ConsoleProject.Domain.User;
using ConsoleProject.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string UserID { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public bool PrivateProfile { get; set; } = false;
        public List<Wallet> Wallets { get; set; } = new List<Wallet>()
        {
            new Wallet(CoinDB.Coins.Single(x => x.Abreviation == "EUR"),0),
            new Wallet(CoinDB.Coins.Single(x => x.Abreviation == "USD"),0)
        };
        public User(string email, string password, int age, string userID, string securityQuestion, string securityAnswer)
        {
            Email = email;
            Password = password;
            Age = age;
            UserID = userID;
            SecurityQuestion = securityQuestion;
            SecurityAnswer = securityAnswer;
        }

        public User(string email, string password, int age, string userID, string securityQuestion, string securityAnswer, bool privateProfile) : this(email, password, age, userID, securityQuestion, securityAnswer)
        {
            PrivateProfile = privateProfile;
        }

        public void AddCoin(string coinAbreviation, double amount)
        {
            if (Wallets.Any(x => x.CoinType.Abreviation == coinAbreviation))  //Check if there is a wallet coitaining the inserted coin type
            {
                Wallets.Single(x => x.CoinType.Abreviation == coinAbreviation).CoinAmount += amount;
            }
            else
            {
                if (CoinDB.Coins.Any(x => x.Abreviation == coinAbreviation))
                {
                    Wallets.Add(new Wallet(CoinDB.Coins.Single(x => x.Abreviation == coinAbreviation), amount));
                }
            }
        }
        public void RemoveCoin(string coinAbreviation, double amount)
        {
            if (Wallets.Any(x => x.CoinType.Abreviation == coinAbreviation))  //Check if there is a wallet coitaining the inserted coin type
            {
                Wallets.Single(x => x.CoinType.Abreviation == coinAbreviation).CoinAmount -= amount;
            }
            else
            {
                Console.WriteLine("Coin could not be removed!");
            }
        }

        public void DisplayPrivacy()
        {
            if(PrivateProfile == true)
                Console.WriteLine("Profile type:   PRIVATE");
            else
                Console.WriteLine("Profile type:   PUBLIC");
        }

        public void ChangeProfileType(bool type)
        {
            Console.WriteLine("Press 1 to make your profile");
            if (type == false)
                Console.WriteLine("Public");
            else
                Console.WriteLine("Private");

            type = !type;
            PrivateProfile = type;
        }

        public void DisplayPortofolio()
        {
            Console.WriteLine();
            foreach (var wallet in Wallets)
            {
                Console.WriteLine($"Coin:  {wallet.CoinType.Abreviation} ({wallet.CoinType.Name})       amount:    {wallet.CoinAmount}");
            }
            Console.WriteLine();
        }

        public void DisplayHiddenPortofolio()
        {
            Console.WriteLine();
            foreach (var wallet in Wallets)
            {
                Console.WriteLine($"Coin:  {wallet.CoinType.Abreviation} ({wallet.CoinType.Name})       amount:    ---");
            }
            Console.WriteLine();
        }

        public override string ToString()
        {
            return $"Email: {Email}\nPassword: {Password}\nAge: {Age}\nUserID: {UserID}\nSecurity Question: {SecurityQuestion}\nSecurity Answer: {SecurityAnswer}\n";
        }
    }
}
