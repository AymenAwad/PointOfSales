using Core.Helpers;
using Core.Interfaces;
using Core.Interfaces.BaseService;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using Persistence;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Application.Repository.BaseService
{
    public class BaseServiceRepository<T> : IBaseService<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public BaseServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().AddAsync(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>()
                .Where(expression).AsNoTracking();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(decimal id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(decimal Id, T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedList<T>> GetPagedList(PaginationParams paginationParams)
        {
            var result = _context.Set<T>();

            return await PagedList<T>.CreateAsync(result, paginationParams.PageNumber, paginationParams.PageSize);
        }

       
    }
}
