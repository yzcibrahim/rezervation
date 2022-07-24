using AutoMapper;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BaseBl<T,S> where T:class where S:class
    {
        protected IMapper mapper;
        protected BaseRepository<T> _repository;
        public BaseBl(BaseRepository<T> repository)
        {
            _repository = repository;
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            mapper = mapperConfig.CreateMapper();
        }

        public virtual List<S> List()
        {
            List<S> result = new List<S>();

            List<T> usrList = _repository.List();

            result = mapper.Map<List<S>>(usrList);

            return result;
        }

        public S Create(S usrDto)
        {
            T entitiy = mapper.Map<T>(usrDto);
            entitiy = _repository.Create(entitiy);

            return mapper.Map<S>(entitiy);
        }

        public S Update(S usrDto)
        {
            T entitiy = mapper.Map<T>(usrDto);
            entitiy = _repository.Update(entitiy);

            return mapper.Map<S>(entitiy);
        }

        public S Get(int id)
        {
            T entitiy = _repository.GetById(id);

            return mapper.Map<S>(entitiy);
        }
        public void Delete(int id)
        {
            T entitiy = _repository.GetById(id);
            _repository.Delete(entitiy);
        }
    }
}
