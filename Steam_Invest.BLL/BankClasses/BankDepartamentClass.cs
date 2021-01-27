using Steam_Invest.BLL.ContainerClasses;
using Steam_Invest.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam_Invest.BLL.BankClasses
{
    public class BankDepartamentClass
    {
        public BankDepartament BankDepartament { get; set; } = new BankDepartament();
        public MyQueueStatic<BankEmployeeClass> BankEmployees { get; set; } = new MyQueueStatic<BankEmployeeClass>();
    }
}
