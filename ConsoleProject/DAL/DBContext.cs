using ConsoleProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Users
{
    public class DBContext
    {
        public static List<User> Users { get; set; } =
        new List<User>() {
                new User("1","1",1,"1","1"),
                new User("cezar.buna25@gmail.com","cacamaca",20,"dog name?","snowy"),
                new User("2","tralala",30,"cat name?","freckles", true),
                new User("3","3",25,"fish name?","nemo"),
                new User("paul.popescu@yahoo.com","asdrwerw",30,"?","!"),
                new User("andrei.ionescu@gmail.com","eweoriwer",21,"yes?","no",true)

        };
        public static void DisplayUSers()
        {
            foreach (var user in Users)
            {
                Console.WriteLine(user.ToString());
            }
        }        
    }   
}
