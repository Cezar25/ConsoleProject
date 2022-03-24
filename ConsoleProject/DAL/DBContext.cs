using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Users
{
    public class DBContext
    {
        public static List<User> Users { get; set; }
        public static List<User> GetUsers()
        {
            return new List<User>() {
                new User("cezar.buna25@gmail.com","cacamaca",20,"aaa111","dog name?","snowy"),
                new User("andi.popescu@yahoo.com","tralala",30,"bbb222","cat name?","freckles"),
                new User("andrei.ionescu@gmail.com","alabala",25,"ccc222","fish name?","nemo"),
            };
        }
    }   
}
