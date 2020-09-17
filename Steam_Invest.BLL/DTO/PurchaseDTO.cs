using System;
using System.Collections.Generic;
using System.Text;

namespace Steam_Invest.BLL.DTO
{
    public class PurchaseDTO
    {
        public int PurchaseId { get; set; }
        public decimal? Price { get; set; }
        public DateTime? Date { get; set; }
        public int? Count { get; set; }
        public bool IsSale { get; set; } = false;
        public int ItemId { get; set; }
    }
}
