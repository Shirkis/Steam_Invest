using System;
using System.Collections.Generic;
using System.Text;

namespace Steam_Invest.BLL.DTO
{
    public class PortfolioDTO
    {
        public int PortfolioId { get; set; }
        public string PortfolioName { get; set; }
        public int PersonInfoId { get; set; }
        public bool Limited { get; set; }
        public int LimitCount { get; set; }
        public decimal? Balance { get; set; }
    }
}
