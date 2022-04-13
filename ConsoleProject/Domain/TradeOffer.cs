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
        public Guid? SentCoinID { get; set; }
        public Guid? ReceivedCoinID { get; set; }
        public static int Counter { get; set; } = 0;

        public TradeOffer(Guid senderID, Guid recipientID, Guid sentCoinID, double sentAmount, Guid receivedCoinID, double receivedAmount)
        {
            SenderID = senderID;
            Sender = DBContext.Users.SingleOrDefault(x => x.UserID == senderID);

            RecipientID = recipientID;
            Recipient = DBContext.Users.SingleOrDefault(x => x.UserID == recipientID);

            SentCoinID = sentCoinID;
            SentCoin = CoinDB.Coins.SingleOrDefault(x => x.CoinID == sentCoinID);

            SentAmount = sentAmount;
            ReceivedCoinID = receivedCoinID;
            ReceivedCoin = CoinDB.Coins.SingleOrDefault(x => x.CoinID == receivedCoinID);
            ReceivedAmount = receivedAmount;

            Counter++;
        }

        //public TradeOffer(User sender, User recipient, Coin sentCoin, double sentAmount, Coin receivedCoin, double receivedAmount)
        //{
        //    Sender = sender;
        //    Recipient = recipient;
        //    SentCoin = sentCoin;
        //    SentAmount = sentAmount;
        //    ReceivedCoin = receivedCoin;
        //    ReceivedAmount = receivedAmount;

        //}

        public override string ToString()
        {
            return $"From {Sender.Email} to {Recipient.Email}:\nCoin type: {SentCoin.Abreviation} amount: {SentAmount} for\nCoin type: {ReceivedCoin.Abreviation} amount: {ReceivedAmount}";
        }

        public override bool Equals(object obj)
        {
            return obj is TradeOffer offer &&
                   EqualityComparer<User>.Default.Equals(Sender, offer.Sender) &&
                   EqualityComparer<User>.Default.Equals(Recipient, offer.Recipient) &&
                   EqualityComparer<Coin>.Default.Equals(SentCoin, offer.SentCoin) &&
                   SentAmount == offer.SentAmount &&
                   EqualityComparer<Coin>.Default.Equals(ReceivedCoin, offer.ReceivedCoin) &&
                   ReceivedAmount == offer.ReceivedAmount;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Sender, Recipient, SentCoin, SentAmount, ReceivedCoin, ReceivedAmount);
        }
    }
}
