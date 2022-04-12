using ConsoleProject.BLL;
using ConsoleProject.DAL;
using ConsoleProject.Domain;
using ConsoleProject.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestConsoleApp
{
    public class WithdrawMoneyTests
    {
        [Fact]
        public static void RemoveCoin_TestIfCoinIsRemoved()
        {
            // Arrange
            User user = DBContext.Users[0];
            user.Wallets.Add(new Wallet(CoinDB.Coins[2].CoinID, 5));

            double expected = 0;

            // Act
            WithdrawBusinessLogic.RemoveCoin(user, "BTC", 5);

            double actual = user.Wallets[2].CoinAmount;

            // Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public static void RemoveCoin_TestIfCoinIsRemoved_WhenRemovedAmountIsGreaterThanOwnedAmount()
        {
            // Arrange
            User user = DBContext.Users[1];
            user.Wallets.Add(new Wallet(CoinDB.Coins[2].CoinID, 4));

            double expected = 0;

            // Act
            WithdrawBusinessLogic.RemoveCoin(user, "BTC", 5);

            double actual = user.Wallets[2].CoinAmount;

            // Assert
            Assert.Equal(expected, actual);
        }

    }
}
