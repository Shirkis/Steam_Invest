using System;
using System.Collections.Generic;
using System.Text;

namespace Steam_Invest.BLL.DTO
{
    public class ItemDTO
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemNameCode { get; set; }
        public int PortfolioId { get; set; }
        public int? GameId { get; set; }
        public decimal? BuyPrice { get; set; }
        public DateTime? BuyDate { get; set; }
        public int? BuyCount { get; set; }
    }
}
