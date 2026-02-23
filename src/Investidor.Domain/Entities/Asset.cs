using System;
using System.Collections.Generic;
using System.Text;

namespace Investidor.Domain.Entities
{
    public class Asset : Base
    {
        protected Asset()
        {
            
        }

        public Asset(string code, string name, decimal price)
        {
            Code = code;
            Name = name;
            Price = price;
        }

        public string Code { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        
    }
}
