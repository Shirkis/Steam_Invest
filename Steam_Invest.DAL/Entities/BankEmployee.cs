using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Steam_Invest.DAL.Entities
{
    public class BankEmployee
    {
        public int BankEmployeeId { get; set; }
        public string BankEmployeeName { get; set; }
        public string BankEmployeePosition { get; set; }
        public int BankDepartamentId { get; set; }
        [ForeignKey("BankDepartamentId")]
        public virtual BankDepartament BankDepartament { get; set; }
    }
}
