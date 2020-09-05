using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Steam_Invest.DAL.Entities
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public decimal? BuyPrice { get; set; }
        public DateTime? BuyDate { get; set; }
        public int? BuyCount { get; set; }
        public int ItemId { get; set; }
        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }
    }
}
