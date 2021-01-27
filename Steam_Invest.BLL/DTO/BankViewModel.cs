using Steam_Invest.BLL.BankClasses;
using Steam_Invest.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam_Invest.BLL.DTO
{
    public class BankViewModel
    {
        public BankDTO Bank { get; set; } = new BankDTO();
        public List<BankDepartamentViewModel> BankDepartaments { get; set; } = new List<BankDepartamentViewModel>();
    }

    public class BankDepartamentViewModel
    {
        public BankDepartamentDTO BankDepartament { get; set; } = new BankDepartamentDTO();
        public Queue<BankEmployeeViewModel> BankEmployees { get; set; } = new Queue<BankEmployeeViewModel>();
    }
    public class BankEmployeeViewModel
    {
        public BankEmployeeDTO BankEmployee { get; set; } = new BankEmployeeDTO();
    }
}
