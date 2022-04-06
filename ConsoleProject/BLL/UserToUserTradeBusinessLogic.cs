using ConsoleProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.BLL
{
    public class UserToUserTradeBusinessLogic
    {
        public static void ApplyTrade(TradeOffer offer)
        {
            if(offer.Sender.Wallets.Any(x => x.CoinType == offer.ReceivedCoin) && offer.Recipient.Wallets.Any(x => x.CoinType == offer.SentCoin))
            {
                offer.Sender.Wallets.Single(x => x.CoinType == offer.ReceivedCoin).CoinAmount += offer.ReceivedAmount;
                offer.Recipient.Wallets.Single(x => x.CoinType == offer.SentCoin).CoinAmount += offer.SentAmount;

                offer.Sender.Wallets.Single(x => x.CoinType == offer.SentCoin).CoinAmount -= offer.SentAmount;
                offer.Recipient.Wallets.Single(x => x.CoinType == offer.ReceivedCoin).CoinAmount -= offer.ReceivedAmount;
            }
            else if ( !offer.Sender.Wallets.Any(x => x.CoinType == offer.ReceivedCoin) && offer.Recipient.Wallets.Any(x => x.CoinType == offer.SentCoin))
            {
                offer.Sender.Wallets.Add(new Wallet(offer.ReceivedCoin, offer.ReceivedAmount));
                offer.Recipient.Wallets.Single(x => x.CoinType == offer.SentCoin).CoinAmount += offer.SentAmount;

                offer.Sender.Wallets.Single(x => x.CoinType == offer.SentCoin).CoinAmount -= offer.SentAmount;
                offer.Recipient.Wallets.Single(x => x.CoinType == offer.ReceivedCoin).CoinAmount -= offer.ReceivedAmount;
            }
            else if (offer.Sender.Wallets.Any(x => x.CoinType == offer.ReceivedCoin) && !offer.Recipient.Wallets.Any(x => x.CoinType == offer.SentCoin))
            {
                offer.Sender.Wallets.Single(x => x.CoinType == offer.ReceivedCoin).CoinAmount += offer.ReceivedAmount;
                offer.Recipient.Wallets.Add(new Wallet(offer.SentCoin, offer.SentAmount));

                offer.Sender.Wallets.Single(x => x.CoinType == offer.SentCoin).CoinAmount -= offer.SentAmount;
                offer.Recipient.Wallets.Single(x => x.CoinType == offer.ReceivedCoin).CoinAmount -= offer.ReceivedAmount;
            }
            else
            {
                offer.Sender.Wallets.Add(new Wallet(offer.ReceivedCoin, offer.ReceivedAmount));
                offer.Recipient.Wallets.Add(new Wallet(offer.SentCoin, offer.SentAmount));

                offer.Sender.Wallets.Single(x => x.CoinType == offer.SentCoin).CoinAmount -= offer.SentAmount;
                offer.Recipient.Wallets.Single(x => x.CoinType == offer.ReceivedCoin).CoinAmount -= offer.ReceivedAmount;
            }
        }
    }
}
