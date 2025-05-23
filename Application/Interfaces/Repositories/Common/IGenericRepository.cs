using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.Common
{
    public interface IGenericRepository<T> where T : class
    {
        T? GetById(params object[] values);
        IQueryable<T> GetAll();

        IQueryable<T> GetAllAsNonTracking();

        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
    }
}
