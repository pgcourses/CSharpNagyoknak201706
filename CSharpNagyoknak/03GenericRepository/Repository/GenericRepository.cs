using _01Data.Model;
using _03GenericRepository.AutoMapper;
using _03GenericRepository.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using _09PerformanceCounters;

namespace _03GenericRepository.Repository
{
    public class GenericRepository<TEntity, TDto, TProfile>
        where TEntity : class, IClassWithId
        where TDto: class, IClassWithId
        where TProfile: Profile, new()
    {
        private readonly CSharpDDCounters counters;
        private readonly TodoContext db;

        /// <summary>
        /// "Visszamenőleges kompatibilitás": 
        /// ha paraméter nélkül hívják a repo-t, 
        /// biztosítjuk a korábbi működést
        /// TODO: mi lesz a TodoContext : DbContext : IDisposable megoldással, ha 
        ///       itt példányosítok using helyett???
        /// </summary>
        public GenericRepository() : this(new TodoContext())
        {
            counters = new CSharpDDCounters("03GenericRepository.GenericRepository");
        }

        public GenericRepository(TodoContext db)
        {
            this.db = db;
            Mapper.Initialize(cfg => cfg.AddProfile<TProfile>());
        }

        public void Add(TDto dto)
        {
            //counters.BeginOperation();

            //COMMENT: Tervezési kérdés a null érték használata
            //http://netacademia.blog.hu/2017/05/30/miert_ne_hasznaljunk_null-t
            if (null == dto)
            {
                throw new ArgumentOutOfRangeException(nameof(dto));
            }

            var item = Mapper.Map<TEntity>(dto);

            db.Set<TEntity>().Add(item);
            db.SaveChanges();

            dto.Id = item.Id; //visszaküldjük a mentés után visszakapott azonosítót
            //counters.EndOperation();
        }

        public void AddWithId(TDto dto)
        {
            throw new NotImplementedException();
        }

        public TDto Find(int id)
        {
            counters.BeginOperation();
            var item = db.Set<TEntity>().Find(id);
            //COMMENT: Tervezési kérdés a null érték használata
            if (null == item)
            {
                return default(TDto);
            }

            var result = Mapper.Map<TDto>(item);
            counters.EndOperation();
            return result;
        }

        public TDto Find(int id, params Expression<Func<TEntity, object>>[] includeParams)
        {
            var query = db.Set<TEntity>()
                            .AsQueryable();

            foreach (var include in includeParams)
            {
                query = query.Include(include);
            }

            var item = query.SingleOrDefault(x => x.Id == id);
                             
            //COMMENT: Tervezési kérdés a null érték használata
            if (null == item)
            {
                return default(TDto);
            }

            return Mapper.Map<TDto>(item);
        }

        public TDto Find(Expression<Func<TEntity, bool>> filter, 
                        params Expression<Func<TEntity, object>>[] includeParams)
        {
            var query = db.Set<TEntity>()
                            .AsQueryable();

            foreach (var include in includeParams)
            {
                query = query.Include(include);
            }

            var item = query.SingleOrDefault(filter);

            //COMMENT: Tervezési kérdés a null érték használata
            if (null == item)
            {
                return default(TDto);
            }

            return Mapper.Map<TDto>(item);
        }

        public void Remove(int id)
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

        public void Update(TDto dto)
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
