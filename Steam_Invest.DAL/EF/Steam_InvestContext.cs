using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Steam_Invest.DAL.Entities;

namespace Steam_Invest.DAL.EF
{
    public class Steam_InvestContext : IdentityDbContext<IdentityUser>
    {
        public Steam_InvestContext(DbContextOptions<Steam_InvestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PersonInfo> PersonInfo { get; set; }
        public virtual DbSet<Portfolio> Portfolios { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
