﻿using ConsoleProject.DAL;
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
        public static void ChangeProfileType(User user)
        {
            Console.WriteLine("Press 1 to make your profile");
            if (user.PrivateProfile == false)
                Console.WriteLine("Public");
            else
                Console.WriteLine("Private");

            user.PrivateProfile = !user.PrivateProfile;
        }
        public static void DisplayPortofolio(User user)
        {
            Console.WriteLine();
            foreach (var wallet in user.Wallets)
            {
                Console.WriteLine($"Coin:  {wallet.CoinType.Abreviation} ({wallet.CoinType.Name})       amount:    {wallet.CoinAmount}");
            }
            Console.WriteLine();
        }

        public static void DisplayHiddenPortofolio(User user)
        {
            Console.WriteLine();
            foreach (var wallet in user.Wallets)
            {
                Console.WriteLine($"Coin:  {wallet.CoinType.Abreviation} ({wallet.CoinType.Name})       amount:    ---");
            }
            Console.WriteLine();
        }
    }
}