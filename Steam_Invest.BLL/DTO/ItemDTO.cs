using System;
using System.Collections.Generic;
using System.Text;

namespace Steam_Invest.BLL.DTO
{
    public class ItemDTO
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Price { get; set; }
        public decimal? BuyPrice { get; set; }
        public DateTime? BuyDate { get; set; }
        public int? BuyCount { get; set; }
    }
}
