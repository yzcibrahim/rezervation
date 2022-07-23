using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class RezUserRepository:BaseRepository<RezUser>
    {

        public RezUserRepository(RezContext context) : base(context)
        {
           
        }
        
    }
}
