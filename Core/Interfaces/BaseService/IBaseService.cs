using Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.BaseService
{
    public interface IBaseService<T> where T : class
    {
        Task<T> GetById(decimal id);
        Task<IEnumerable<T>> GetAll();
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        Task<bool> SaveChanges();
        void Update(decimal Id, T entity);
        Task<PagedList<T>> GetPagedList(PaginationParams paginationParams);
    
    }
}
