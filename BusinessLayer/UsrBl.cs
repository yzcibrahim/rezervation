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
    public class UsrBl:BaseBl<RezUser,RezUserDto>
    {
        RezUserRepository _rezUserRepository;
        public UsrBl(RezUserRepository rezUserRepository):base(rezUserRepository)
        {
            _rezUserRepository = rezUserRepository;
        }
        
        

       
    }
}
