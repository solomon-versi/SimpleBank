using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SimpleBank.Core.Models;

namespace SimpleBank.Data.Maps
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Data.Models.Account, Account>()
                .ForMember(dest => dest.Balance,
                    opt => opt.MapFrom(src => new Money(src.Currency, src.Balance)));

            CreateMap<Account, Data.Models.Account>()
                .ForMember(dest => dest.Balance,
                    opt => opt.MapFrom(src => src.Balance.Amount))
                .ForMember(dest => dest.Currency,
                    opt => opt.MapFrom(src => src.Balance.Currency));
        }
    }
}