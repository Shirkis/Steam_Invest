using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Steam_Invest.DAL.Entities
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemNameCode { get; set; }
        public int PortfolioId { get; set; }
        public int GameId { get; set; }

        [ForeignKey("PortfolioId")]
        public virtual Portfolio Portfolio { get; set; }

        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }
    }
}
