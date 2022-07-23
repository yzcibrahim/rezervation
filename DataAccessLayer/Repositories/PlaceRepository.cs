using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class PlaceRepository : BaseRepository<Place>
    {
        public PlaceRepository(RezContext context):base(context)
        {
        }
       
    }
}
