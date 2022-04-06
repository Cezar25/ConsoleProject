﻿using ConsoleProject.BLL;
using ConsoleProject.Domain;
using ConsoleProject.StrategyPatterm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Menus.UserToUserTradeMenus
{
    public class ViewUserPortofolioPercentageMenu
    {
        public static void PortofolioPercentageMenu(User user, User searchedUser)
        {
            var context = new ShowBalanceContext();
            context.SetStrategy(new ShownBalanceStrategy());

            Console.WriteLine();
            Console.WriteLine($"{searchedUser.Email}'s portofolio % is:\n");
            UserPortofolioBusinessLogic.DisplayCoinPercentage(searchedUser);

            Console.WriteLine("Press 1 to copy the user's portofolio.");
            Console.WriteLine("Press 0 to go back to the BALANCE page.");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 0:
                    {
                        context.ShowBalance(user.Email);
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine();
                        Console.WriteLine("Press 1 to copy portofolio with EUR.");
                        Console.WriteLine("Press 2 to copy portofolio with USD.");
                        Console.WriteLine("Press 0 to go back to the BALANCE page.");

                        int choice2 = Convert.ToInt32(Console.ReadLine());

                        switch (choice2)
                        {
                            case 0:
                                {
                                    context.ShowBalance(user.Email);
                                    break;
                                }
                            case 1:
                                {
                                    if(user.Wallets.Any(x => x.CoinType.Abreviation == "EUR"))
                                    {
                                        if(user.Wallets.Single(x => x.CoinType.Abreviation == "EUR").CoinAmount <= 0)
                                        {
                                            Console.WriteLine("No EUR available! Please try again!");
                                            PortofolioPercentageMenu(user, searchedUser);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Type in the amount of EUR you want to invest:");

                                            double amount = Convert.ToDouble(Console.ReadLine());
                                            if(amount > user.Wallets.Single(x => x.CoinType.Abreviation == "EUR").CoinAmount)
                                            {
                                                Console.WriteLine("You have typed in more than you have in your balance. Please try again!");
                                                
                                                PortofolioPercentageMenu(user, searchedUser);
                                            }
                                            else
                                            {
                                                user.Wallets.Single(x => x.CoinType.Abreviation == "EUR").CoinAmount -= amount;
                                                UserPortofolioBusinessLogic.AddCopiedPortofolio(user, searchedUser, amount);
                                                context.ShowBalance(user.Email);
                                            }
                                        }
                                    }
                                    
                                    break;
                                }
                            case 2:
                                {
                                    if(user.Wallets.Any(x => x.CoinType.Abreviation == "USD"))
                                    {
                                        if (user.Wallets.Single(x => x.CoinType.Abreviation == "USD").CoinAmount <= 0)
                                        {
                                            Console.WriteLine("No USD available! Please try again!");
                                            PortofolioPercentageMenu(user, searchedUser);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Type in the amount of USD you want to invest:");

                                            double amount = Convert.ToDouble(Console.ReadLine());
                                            if (amount > user.Wallets.Single(x => x.CoinType.Abreviation == "USD").CoinAmount)
                                            {
                                                Console.WriteLine("You have typed in more than you have in your balance. Please try again!");
                                                
                                                PortofolioPercentageMenu(user, searchedUser);
                                            }
                                            else
                                            {
                                                user.Wallets.Single(x => x.CoinType.Abreviation == "USD").CoinAmount -= amount;
                                                UserPortofolioBusinessLogic.AddCopiedPortofolio(user, searchedUser, amount);
                                                context.ShowBalance(user.Email);
                                            }
                                        }
                                    }

                                    break;
                                }

                            default:
                                {
                                    Console.WriteLine("Wrong choice! Please try again!");
                                    PortofolioPercentageMenu(user, searchedUser);
                                    break;
                                }
                        }
                        
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Wrong choice! You are being redirected to the BALANCE page.");
                        context.ShowBalance(user.Email);
                        break;
                    }
            }
        }
    }
}