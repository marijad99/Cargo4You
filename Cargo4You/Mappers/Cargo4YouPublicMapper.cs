using AutoMapper;
using Cargo4You.DTO;
using Cargo4You.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cargo4You.Mappers
{
    public class Cargo4YouPublicMapper : Profile
    {
        public Cargo4YouPublicMapper()
        {
            CreateMap<UserInputDTO, UserInputViewModel>().ReverseMap();

            CreateMap<CalculatedCourierPriceDTO, CalculatedCourierPriceViewModel>().ReverseMap();

            CreateMap<CalculationViewModel, CalculationDTO>()
                .ForMember(dest => dest.CalculatedCouriesPricesDTO, opt => opt.MapFrom(src => src.CalculatedCouriesPrices))
                  .ForMember(dest => dest.UserInputDTO, opt => opt.MapFrom(src => src.UserInput)).ReverseMap();
        }
        
    }
}
