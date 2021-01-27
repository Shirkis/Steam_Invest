using System;
using System.Collections.Generic;
using System.Text;

namespace Steam_Invest.DAL.Entities
{
    public class Bank
    {
        public int BankId { get; set; }
        public string BankName { get; set; }
        public virtual ICollection<BankDepartament> BankDepartaments { get; set; }
    }
}
