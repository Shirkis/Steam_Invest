using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Steam_Invest.DAL.Entities
{
    public class PersonInfo
    {
        public int PersonInfoId { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string AspNetUserId { get; set; }

        [ForeignKey("AspNetUserId")]
        public AspNetUser AspNetUser { get; set; }

        public virtual ICollection<Portfolio> Portfolios { get; set; }
    }
}
