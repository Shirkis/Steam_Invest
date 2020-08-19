using System;
using System.Collections.Generic;
using System.Text;

namespace Steam_Invest.DAL.Entities
{
    public class Game
    {
        public int GameId { get; set; }
        public string GameName { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
