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
        }
    }
}
