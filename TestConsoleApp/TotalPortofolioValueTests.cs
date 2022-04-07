using ConsoleProject.BLL;
using ConsoleProject.DAL;
using ConsoleProject.Domain;
using ConsoleProject.Users;
using Xunit;


namespace TestConsoleApp
{
    //Little inspiration from IAmTimCorey on YT :)
    public class TotalPortofolioValueTests
    {
        //[Fact]
        public void GetTotalPortofolioValueInEUR_TestForEmptyPortofolio()
        {
            // Arrange
            double expected = 0;

            User testedUser = DBContext.Users[0];

            // Act

            double actual = UserPortofolioBusinessLogic.GetTotalPortofolioValueInEUR(testedUser);

            // Assert
            Assert.Equal(expected, actual);
        }
        //[Fact]
        public void GetTotalPortofolioValueInEUR_TestForNonEmptyPortofolio()
        {
            // Arrange
            double expected = 0;

            User testedUser = DBContext.Users[1];
            testedUser.Wallets.Add(new Wallet(CoinDB.Coins[2], 2));
            testedUser.Wallets.Add(new Wallet(CoinDB.Coins[5], 10));

            foreach (var wallet in testedUser.Wallets)
            {
                expected += wallet.CoinAmount * wallet.CoinType.ValueInEUR;
            }

            // Act

            double actual = UserPortofolioBusinessLogic.GetTotalPortofolioValueInEUR(testedUser);

            // Assert
            Assert.Equal(expected, actual);
        }
        //[Fact]
        public void GetTotalPortofolioValueInUSD_TestForEmptyPortofolio()
        {
            // Arrange
            double expected = 0;

            User testedUser = DBContext.Users[2];

            // Act

            double actual = UserPortofolioBusinessLogic.GetTotalPortofolioValueInUSD(testedUser);

            // Assert
            Assert.Equal(expected, actual);
        }
        //[Fact]
        public void GetTotalPortofolioValueInUSD_TestForNonEmptyPortofolio()
        {
            // Arrange
            double expected = 0;

            User testedUser = DBContext.Users[3];
            testedUser.Wallets.Add(new Wallet(CoinDB.Coins[2], 2));
            testedUser.Wallets.Add(new Wallet(CoinDB.Coins[5], 10));

            foreach (var wallet in testedUser.Wallets)
            {
                expected += wallet.CoinAmount * wallet.CoinType.ValueInUSD;
            }

            // Act

            double actual = UserPortofolioBusinessLogic.GetTotalPortofolioValueInUSD(testedUser);

            // Assert
            Assert.Equal(expected, actual);
        }
        //[Fact]
        public void GetTotalPortofolioValueInBTC_TestForEmptyPortofolio()
        {
            // Arrange
            double expected = 0;

            User testedUser = DBContext.Users[4];

            // Act

            double actual = UserPortofolioBusinessLogic.GetTotalPortofolioValueInBTC(testedUser);

            // Assert
            Assert.Equal(expected, actual);
        }
        //[Fact]
        public void GetTotalPortofolioValueInBTC_TestForNonEmptyPortofolio()
        {
            // Arrange
            double expected = 0;

            User testedUser = DBContext.Users[5];
            testedUser.Wallets.Add(new Wallet(CoinDB.Coins[2], 2));
            testedUser.Wallets.Add(new Wallet(CoinDB.Coins[5], 10));

            foreach (var wallet in testedUser.Wallets)
            {
                expected += wallet.CoinAmount * wallet.CoinType.ValueInBTC;
            }

            // Act

            double actual = UserPortofolioBusinessLogic.GetTotalPortofolioValueInBTC(testedUser);

            // Assert
            Assert.Equal(expected, actual);
        }

    }
}
