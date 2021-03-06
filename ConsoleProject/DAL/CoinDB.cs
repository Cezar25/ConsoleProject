using ConsoleProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.DAL
{
    public class CoinDB
    {
        public static List<Coin> Coins { get; set; } =
            new List<Coin>()
            {
                //Main currencies
                new Coin("Euro","EUR",1,1.15,0.000023),
                new Coin("US dollar","USD",0.85,1,0.000021),                
                new Coin("Bitcoin","BTC",42000,47400,1),

                //Other currencies
                new Coin("Ethereum","ETH",3074,3370,0.071),
                new Coin("Cardano","ADA",1.13,1.24,0.000026),
                new Coin("Solana","SOL",100,111,0.0037),
                new Coin("Sandbox","SAND",3.13,3.61,0.00007),
                new Coin("Dogecoin","DOGE",0.14,0.16,0.0000032),
                new Coin("BinanceCoin", "BNB", 393.7, 427.6, 0.1),
                new Coin("Ripple", "XRP", 0.7, 0.77, 0.000018)
            };
    }
}
