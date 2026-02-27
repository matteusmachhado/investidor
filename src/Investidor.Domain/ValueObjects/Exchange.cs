using System;
using System.Collections.Generic;
using System.Text;

namespace Investidor.Domain.ValueObjects
{
    public sealed class Exchange
    {
        public string Code { get; }
        public string Name { get; }
        public string Country { get; }

        private Exchange(string code, string name, string country)
        {
            Code = code;
            Name = name;
            Country = country;
        }

        public static readonly Exchange B3 =
            new("B3", "Bolsa Brasileira", "BR");

        public static readonly Exchange Nyse =
            new("NYSE", "New York Stock Exchange", "US");

        public static readonly Exchange Nasdaq =
            new("NASDAQ", "Nasdaq Stock Market", "US");

        public override string ToString() => Code;
    }
}
