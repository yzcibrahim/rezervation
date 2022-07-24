using AutoMapper;
using DataAccessLayer;
using DtoLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<RezUser, RezUserDto>();
            CreateMap<RezUserDto, RezUser>();

            CreateMap<RezRight, RezRightDto>();
            CreateMap<RezRightDto, RezRight>();

            CreateMap<Place, PlaceDto>();
            CreateMap<PlaceDto, Place>();
        }
    }
}
