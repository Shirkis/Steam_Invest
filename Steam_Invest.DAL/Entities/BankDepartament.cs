using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Steam_Invest.DAL.Entities
{
    public class BankDepartament
    {
        public int BankDepartamentId { get; set; }
        public string BankDepartamentName { get; set; }
        public int BankId { get; set; }

        [ForeignKey("BankId")]
        public virtual Bank Bank { get; set; }

        public virtual ICollection<BankEmployee> BankEmployees { get; set; }
    }
}
