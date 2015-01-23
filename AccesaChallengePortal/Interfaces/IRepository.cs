using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AccesaChallengePortal.Interfaces
{
    public interface IRepository<T> where T:IEntity
    {
        List<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T FindById(int id);
        IEnumerable<T> Where(Expression<Func<T, bool>> filter = null);
    }
}
