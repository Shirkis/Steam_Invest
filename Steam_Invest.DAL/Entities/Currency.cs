using System;
using System.Collections.Generic;
using System.Text;

namespace Steam_Invest.DAL.Entities
{
    public class Currency
    {
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }

        public virtual ICollection<Portfolio> Portfolios { get; set; }
    }
}
