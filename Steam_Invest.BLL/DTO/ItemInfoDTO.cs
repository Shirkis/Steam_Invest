using System;
using System.Collections.Generic;
using System.Text;

namespace Steam_Invest.BLL.DTO
{
    public class ItemInfoDTO
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemNameCode { get; set; }
        public int PortfolioId { get; set; }
        public int? GameId { get; set; }
        public decimal? AvgBuyPrice { get; set; }
        public DateTime? FirstBuyDate { get; set; }
        public int? AllBuyCount { get; set; }
        public decimal? SumBuyPrice { get; set; }
    }
}
