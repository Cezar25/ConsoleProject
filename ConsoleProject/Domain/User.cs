using ConsoleProject.DAL;
using ConsoleProject.Domain;
using ConsoleProject.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Domain
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public Guid UserID { get; set; } = Guid.NewGuid();
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public bool PrivateProfile { get; set; } = false;
        public List<Wallet> Wallets { get; set; } = new List<Wallet>()
        {
            new Wallet(CoinDB.Coins.Single(x => x.Abreviation == "EUR").CoinID,0),
            new Wallet(CoinDB.Coins.Single(x => x.Abreviation == "USD").CoinID,0)
        };
        public List<TradeOffer> Offers { get; set; } = new();
        public User(string email, string password, int age, string securityQuestion, string securityAnswer)
        {
            Email = email;
            Password = password;
            Age = age;
            SecurityQuestion = securityQuestion;
            SecurityAnswer = securityAnswer;
        }
        public User(string email, string password, int age, string securityQuestion, string securityAnswer, bool privateProfile) : this(email, password, age, securityQuestion, securityAnswer)
        {
            PrivateProfile = privateProfile;
        }
        public override string ToString()
        {
            return $"Email: {Email}\nPassword: {Password}\nAge: {Age}\nUserID: {UserID}\nSecurity Question: {SecurityQuestion}\nSecurity Answer: {SecurityAnswer}\nPrivate profile:{PrivateProfile}\n";
        }
    }
}
