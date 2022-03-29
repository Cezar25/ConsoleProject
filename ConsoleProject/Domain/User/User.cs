using ConsoleProject.DAL;
using ConsoleProject.Domain.Currency;
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
        public (List<Coin>, List<double>) CoinAmount { get; set; } = new(CoinDB.Coins, new List<double>(new double[CoinDB.Coins.Count]));

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

        public void AddCoins(string coinAbreviation, double amount)
        {
            
            if (CoinAmount.Item1.Any(x => x.Abreviation == coinAbreviation))
            {
                int foundIndex = CoinAmount.Item1.FindIndex(x => x.Abreviation == coinAbreviation);
                
                CoinAmount.Item2[foundIndex] += amount;
            }
        }

        public void DeleteCoins(string coinAbreviation,double amount)
        {
            if (CoinAmount.Item1.Any(x => x.Abreviation == coinAbreviation))
            {
                int foundIndex = CoinAmount.Item1.FindIndex(x => x.Abreviation == coinAbreviation);

                CoinAmount.Item2[foundIndex] -= amount;
            }
        }

        public void DisplayPortofolio()
        {
            int index = 0;
            foreach (var item in CoinAmount.Item1)
            {
                Console.WriteLine($"Coin:  {item.Name}        amount:   {CoinAmount.Item2[index]}");
                index ++;
            }
        }

        public void DisplayHiddenPortofolio()
        {
            int index = 0;
            foreach (var item in CoinAmount.Item1)
            {
                Console.WriteLine($"Coin:  {item.Name}        amount:   ---");
                index++;
            }
        }

        public override string ToString()
        {
            return $"Email: {Email}\nPassword: {Password}\nAge: {Age}\nUserID: {UserID}\nSecurity Question: {SecurityQuestion}\nSecurity Answer: {SecurityAnswer}\n";
        }
    }
}
