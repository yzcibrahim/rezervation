using AutoMapper;
using DtoLayer;
using rezMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rezMvc.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<RezUserDto, RezUserViewModel>();
            CreateMap<RezUserViewModel, RezUserDto>();

            CreateMap<RezRightDto, RezRightViewModel>();
            CreateMap<RezRightViewModel, RezRightDto>();

            CreateMap<PlaceDto, PlaceViewModel>();
            CreateMap<PlaceViewModel, PlaceDto>();
        }
    }
}
