using ConsoleProject.DAL;
using ConsoleProject.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.BLL
{
    public class AccountBusinessLogic
    {
        public static void DisplayPrivacy(User user)
        {
            if (user.PrivateProfile == true)
                Console.WriteLine("Profile type:   PRIVATE");
            else
                Console.WriteLine("Profile type:   PUBLIC");
        }
    }
}
