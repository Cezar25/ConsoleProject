using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Domain.Currency
{
    public class Coin
    {
        public string Name { get; set; }
        public string Abreviation { get; set; }
        public double ValueInEUR { get; set; }
        public double ValueInUSD { get; set; }
        public double ValueInBTC { get; set; }
        public Guid CoinID { get; set; } = Guid.NewGuid();

        public Coin(string name,string abreviation, double valueInEUR, double valueInUSD, double valueInBTC)
        {
            Name = name;
            Abreviation = abreviation;
            ValueInEUR = valueInEUR;
            ValueInUSD = valueInUSD;
            ValueInBTC = valueInBTC;
        }

        public Coin(string name, string abreviation)
        {
            Name = name;
            Abreviation = abreviation;
        }

        public override bool Equals(object obj)
        {
            return obj is Coin coin &&
                   Name == coin.Name &&
                   Abreviation == coin.Abreviation &&
                   ValueInEUR == coin.ValueInEUR &&
                   ValueInUSD == coin.ValueInUSD &&
                   ValueInBTC == coin.ValueInBTC;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
