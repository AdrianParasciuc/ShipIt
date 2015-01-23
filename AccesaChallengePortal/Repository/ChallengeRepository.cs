using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AccesaChallengePortal.Interfaces;
using AccesaChallengePortal.DatabaseLink;
using System.Linq.Expressions;

namespace AccesaChallengePortal.Repository
{
    public class ACPRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly ACPDatabaseEntities _context;

        public ACPRepository()
        {
            _context = new ACPDatabaseEntities();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = System.Data.EntityState.Modified;
            _context.SaveChanges();
        }

        public T FindById(int id)
        {
            var result = _context.Set<T>().FirstOrDefault(x => x.Id == id);
            return result;
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> filter = null)
        {
            return _context.Set<T>().Where(filter);
        }
    }
}