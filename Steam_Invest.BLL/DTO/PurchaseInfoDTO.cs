using System;
using System.Collections.Generic;
using System.Text;

namespace Steam_Invest.BLL.DTO
{
    public class PurchaseInfoDTO
    {
        public int PurchaseId { get; set; }
        public decimal? BuyPrice { get; set; }
        public DateTime? BuyDate { get; set; }
        public int? BuyCount { get; set; }
        public int ItemId { get; set; }
        public decimal? SumPurchasePrice { get; set; }
    }
}
