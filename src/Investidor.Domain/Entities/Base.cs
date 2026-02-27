using System;
using System.Collections.Generic;
using System.Text;

namespace Investidor.Domain.Entities
{
    public abstract class Base
    {
        protected Base()
        {
            CreateDate = DateTime.UtcNow;
        }

        public Guid Id { get; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
