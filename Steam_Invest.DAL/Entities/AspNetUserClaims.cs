using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam_Invest.DAL.Entities
{
    public partial class AspNetUserClaim : IdentityUserClaim<string>
    {
        public AspNetUser User { get; set; }
    }
}
