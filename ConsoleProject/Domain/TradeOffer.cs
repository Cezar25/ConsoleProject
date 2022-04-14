using ConsoleProject.DAL;
using ConsoleProject.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Domain
{
    public class TradeOffer
    {
        public Guid TradeOfferID { get; set; } = Guid.NewGuid();
        public User Sender { get; set; }
        public User Recipient { get; set; }
        public Coin SentCoin { get; set; }
        public double SentAmount { get; set; }
        public Coin ReceivedCoin { get; set; }
        public double ReceivedAmount { get; set; }
        public Guid SenderID { get; set; }
        public Guid RecipientID { get; set; }
        public Guid SentCoinID { get; set; }
        public Guid ReceivedCoinID { get; set; }
        public static int Counter { get; set; } = 0;

        public TradeOffer()
        {
            SentCoin = CoinDB.Coins.SingleOrDefault(x => x.CoinID == SentCoinID);
            ReceivedCoin = CoinDB.Coins.SingleOrDefault(x => x.CoinID == ReceivedCoinID);
             
            Counter++;
        }

        public override string ToString()
        {
            return $"From {Sender.Email} to {Recipient.Email}:\nCoin type: {SentCoin.Abreviation} amount: {SentAmount} for\nCoin type: {ReceivedCoin.Abreviation} amount: {ReceivedAmount}";
        }
    }
}
