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

        public User(string email, string password, int age, string userID, string securityQuestion, string securityAnswer)
        {
            Email = email;
            Password = password;
            Age = age;
            UserID = userID;
            SecurityQuestion = securityQuestion;
            SecurityAnswer = securityAnswer;
        }
    }
}
