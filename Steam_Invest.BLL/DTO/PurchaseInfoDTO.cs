using System;
using System.Collections.Generic;
using System.Text;

namespace Steam_Invest.BLL.DTO
{
    public class PurchaseInfoDTO
    {
        public int PurchaseId { get; set; }
        public decimal? Price { get; set; }
        public DateTime? Date { get; set; }
        public int? Count { get; set; }
        public int ItemId { get; set; }
        public bool IsSale { get; set; } = false;
        public decimal? SumPrice { get; set; }
    }
}
