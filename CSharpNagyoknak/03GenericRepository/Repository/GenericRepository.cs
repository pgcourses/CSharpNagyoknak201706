using _01Data.Model;
using _03GenericRepository.AutoMapper;
using _03GenericRepository.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03GenericRepository.Repository
{
    public class GenericRepository<TEntity, TDto, TProfile>
        where TEntity : class, IClassWithId
        where TDto: class, IClassWithId
        where TProfile: Profile, new()
    {
        public GenericRepository()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<TProfile>());
        }

        public void Add(TDto dto)
        {
            //COMMENT: Tervezési kérdés a null érték használata
            //http://netacademia.blog.hu/2017/05/30/miert_ne_hasznaljunk_null-t
            if (null == dto)
            {
                throw new ArgumentOutOfRangeException(nameof(dto));
            }

            using (var db = new TodoContext())
            {

                var item = Mapper.Map<TEntity>(dto);

                db.Set<TEntity>().Add(item);

                db.SaveChanges();

                dto.Id = item.Id;
            }
        }

        public void AddWithId(TDto dto)
        {
            throw new NotImplementedException();
        }

        public TDto Find(int id)
        {
            using (var db = new TodoContext())
            {
                var item = db.Set<TEntity>().Find(id);
                //COMMENT: Tervezési kérdés a null érték használata
                if (null == item)
                {
                    return default(TDto);
                }

                return Mapper.Map<TDto>(item);
            }
        }

        public void Remove(int id)
        {
            using (var db = new TodoContext())
            {
                var item = db.Set<TEntity>().Find(id);
                //COMMENT: null érték használatáról dönteni
                if (null == item)
                {
                    throw new ArgumentOutOfRangeException(nameof(id));
                }

                db.Set<TEntity>().Remove(item);
                db.SaveChanges();
            }
        }

        public void Update(TDto dto)
        {
            using (var db = new TodoContext())
            {
                var item = db.Set<TEntity>().Find(dto.Id);
                //COMMENT: null érték használatáról dönteni
                if (null == item)
                {
                    throw new ArgumentOutOfRangeException(nameof(dto.Id));
                }
                Mapper.Map(dto, item);

                db.SaveChanges();
            }
        }
    }
}
