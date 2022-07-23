using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class RezRightRepository:BaseRepository<RezRight>
    {
        public RezRightRepository(RezContext context):base(context)
        {
        }
       
    }
}
