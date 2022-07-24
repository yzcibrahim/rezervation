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
    public class RezRightBL : BaseBl<RezRight,RezRightDto>
    {
      
        public RezRightBL(RezRightRepository repository):base(repository)
        {
            
        }
        
        

       
    }
}
