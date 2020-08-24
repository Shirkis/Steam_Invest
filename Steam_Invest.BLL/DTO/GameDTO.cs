using System;
using System.Collections.Generic;
using System.Text;

namespace Steam_Invest.BLL.DTO
{
    public class GameDTO
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public int? GameSteamId { get; set; }
    }
}
