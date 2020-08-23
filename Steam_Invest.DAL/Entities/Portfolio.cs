using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Steam_Invest.DAL.Entities
{
    public class Portfolio
    {
        public int PortfolioId { get; set; }
        public string PortfolioName { get; set; }
        public int PersonInfoId { get; set; }
        public bool Limited { get; set; }
        public int? LimitCount { get; set; }
        public decimal? Balance { get; set; }
        public int? CurrencyId { get; set; }

        [ForeignKey("PersonInfoId")]
        public virtual PersonInfo PersonInfo { get; set; }

        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
