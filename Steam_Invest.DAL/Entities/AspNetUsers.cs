using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam_Invest.DAL.Entities
{
    public partial class AspNetUser : IdentityUser
    {
        public int? PersonInfoId { get; set; }
        public PersonInfo PersonInfo { get; set; }
    }
}
