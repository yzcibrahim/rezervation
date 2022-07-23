using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public abstract class BaseRepository<T> where T:class
    {
        protected RezContext _ctx;
        public BaseRepository(RezContext context)
        {
            _ctx = context;
        }
        public List<T> List()
        {
            var liste= _ctx.Set<T>().ToList();
            return liste;
        }

        public T Create(T usr)
        {
            _ctx.Set<T>().Add(usr);
            _ctx.SaveChanges();
            return usr;
        }

        public T GetById(int id)
        {
            return _ctx.Set<T>().Find(id);
        }

        public void Delete(T usr)
        {
            _ctx.Set<T>().Remove(usr);
            _ctx.SaveChanges();
        }
    }
}
