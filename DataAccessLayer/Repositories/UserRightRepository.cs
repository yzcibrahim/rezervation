using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserRightRepository:BaseRepository<UserRight>
    {

        public UserRightRepository(RezContext context) : base(context)
        {
           
        }

        public List<RezRight> GetRights(int userId)
        {
            var rights = _ctx.userRights.Where(c => c.UserId == userId).Select(c=>c.RezRightId);

            return _ctx.rezRights.Where(c => rights.Contains(c.Id)).ToList();
        }
        
    }
}
