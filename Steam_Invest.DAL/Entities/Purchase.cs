using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Steam_Invest.DAL.Entities
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public decimal? Price { get; set; }
        public DateTime? Date { get; set; }
        public int? Count { get; set; }

        public bool IsSale { get; set; } = false;
        public int ItemId { get; set; }
        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }
    }
}
