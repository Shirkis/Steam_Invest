using Steam_Invest.BLL.ContainerClasses;
using Steam_Invest.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam_Invest.BLL.BankClasses
{
    public class BankClass
    {
        public Bank Bank { get; set; } = new Bank();
        public MyList<BankDepartamentClass> BankDepartaments { get; set; } = new MyList<BankDepartamentClass>();
    }
}
