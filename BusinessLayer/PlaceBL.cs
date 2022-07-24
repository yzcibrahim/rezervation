using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Repositories;
using DtoLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class PlaceBL : BaseBl<Place, PlaceDto>
    {
        RezUserRepository _userRep;
        public PlaceBL(PlaceRepository repository, RezUserRepository userRep) : base(repository)
        {
            _userRep = userRep;
        }

        public override List<PlaceDto> List()
        {
            List<PlaceDto> result = new List<PlaceDto>();
            List<Place> placeList = _repository.List();
            List<RezUser> rezUsers = _userRep.List();

            foreach (var place in placeList)
            {
                result.Add(new PlaceDto()
                {
                    Id = place.Id,
                    Name = place.Name,
                    Price = place.Price,
                    Owner = place.Owner,
                    OwnerName = rezUsers.First(c => c.Id == place.Owner).UserName
                });
            }
            return result;

        }




    }
}
