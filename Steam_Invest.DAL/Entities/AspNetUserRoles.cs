using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam_Invest.DAL.Entities
{
    public partial class AspNetUserRole : IdentityUserRole<string>
    {
        public virtual AspNetRole Role { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
