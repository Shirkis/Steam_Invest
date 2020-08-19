using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam_Invest.DAL.Entities
{
    public partial class AspNetUserRole : IdentityUserRole<string>
    {
        public AspNetRole Role { get; set; }
        public AspNetUser User { get; set; }
    }
}
