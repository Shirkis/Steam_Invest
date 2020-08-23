using System;
using System.Collections.Generic;
using System.Text;

namespace Steam_Invest.BLL.DTO.Models
{
    public class TokenResponse
    {
        public string Access_token { get; set; }

        public string Username { get; set; }

        public int? PersonInfoId { get; set; }

        public IList<string> Roles { get; set; }

        public DateTime Start { get; set; }

        public DateTime Finish { get; set; }
    }
}
