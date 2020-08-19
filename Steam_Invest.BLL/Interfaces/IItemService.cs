using Steam_Invest.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Steam_Invest.BLL.Interfaces
{
    public interface IItemService
    {
        Task<ItemDTO> GetItemByName(string itemName, string game);
    }
}
