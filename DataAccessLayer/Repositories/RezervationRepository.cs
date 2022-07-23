using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class RezervationRepository : BaseRepository<Rezervation>
    {
        public RezervationRepository(RezContext context):base(context)
        {
        }
       
    }
}
