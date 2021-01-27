using AutoMapper;
using Steam_Invest.BLL.DTO;
using Steam_Invest.BLL.DTO.BindingModel;
using Steam_Invest.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steam_Invest.PRL.Mappings
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            //CreateMap<Groups, GroupStatisticDTO>()
            //    .ForMember(dest => dest.GroupName, s => s.MapFrom(c => c.Name));

            CreateMap<Portfolio, PortfolioDTO>();
            CreateMap<PortfolioDTO, Portfolio>();
            CreateMap<RegisterBindingModel, PersonInfo>();

            CreateMap<Game, GameDTO>();
            CreateMap<GameDTO, Game>();

            CreateMap<Currency, CurrencyDTO>();
            CreateMap<CurrencyDTO, Currency>();

            CreateMap<Item, ItemDTO>();
            CreateMap<ItemDTO, Item>();

            CreateMap<ItemChangeDTO, Item>()
                .ForMember(s => s.AllBuyCount, s => s.MapFrom(c => c.Purchase.Count))
                .ForMember(s => s.AvgBuyPrice, s => s.MapFrom(c => c.Purchase.Price))
                .ForMember(s => s.FirstBuyDate, s => s.MapFrom(c => c.Purchase.Date));

            CreateMap<PurchaseDTO, Purchase>();
            CreateMap<Purchase, PurchaseDTO>();

            CreateMap<Purchase, PurchaseInfoDTO>();
            CreateMap<Item, ItemInfoDTO>();

            CreateMap<Bank, BankDTO>();
            CreateMap<BankDTO, Bank>();

            CreateMap<BankDepartament, BankDepartamentDTO>();
            CreateMap<BankDepartamentDTO, BankDepartament>();

            CreateMap<BankEmployee, BankEmployeeDTO>();
            CreateMap<BankEmployeeDTO, BankEmployee>();
        }
    }
}
