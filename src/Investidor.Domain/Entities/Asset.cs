using System;
using System.Collections.Generic;
using System.Text;

namespace Investidor.Domain.Entities
{
    public class Asset : Base
    {
        protected Asset() { }

        public Asset(string code, string name, Exchange exchange)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException("Código inválido.");

            Code = code;
            Name = name;
            Exchange = exchange ?? throw new ArgumentNullException(nameof(exchange));
        }

        public string Code { get; private set; }
        public string Name { get; private set; }
        public Exchange Exchange { get; private set; }

        public decimal Quantity { get; private set; }
        public decimal AmountInvested { get; private set; }
        public decimal CurrentPrice { get; private set; }
        public decimal Dividends { get; private set; }

        public decimal AveragePrice =>
            Quantity == 0 ? 0 : AmountInvested / Quantity;

        public decimal Gain =>
            (Quantity * CurrentPrice) - AmountInvested;

        public decimal PercentageGain =>
            AmountInvested == 0 ? 0 : (Gain / AmountInvested) * 100;

        public void Buy(decimal quantity, decimal unitPrice)
        {
            if (quantity <= 0)
                throw new InvalidOperationException("Quantidade inválida.");

            if (unitPrice <= 0)
                throw new InvalidOperationException("Preço inválido.");

            Quantity += quantity;
            AmountInvested += quantity * unitPrice;
        }

        public void Sell(decimal quantity, decimal unitPrice)
        {
            if (quantity <= 0)
                throw new InvalidOperationException("Quantidade inválida.");

            if (quantity > Quantity)
                throw new InvalidOperationException("Não é possível vender mais do que possui.");

            var averagePrice = AveragePrice;

            Quantity -= quantity;
            AmountInvested -= quantity * averagePrice;
        }

        public void UpdateMarketPrice(decimal currentPrice)
        {
            if (currentPrice <= 0)
                throw new InvalidOperationException("Preço inválido.");

            CurrentPrice = currentPrice;
        }

        public void AddDividends(decimal value)
        {
            if (value <= 0)
                throw new InvalidOperationException("Valor inválido.");

            Dividends += value;
        }
    }
}
