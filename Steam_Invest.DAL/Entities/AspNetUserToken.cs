using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam_Invest.DAL.Entities
{
    public class AspNetUserToken : IdentityUserToken<string>
    {
        public string Id { get; set; }
    }
}
