using Employee_CRUD_Operations.BLL.IRepositories;
using Employee_CRUD_Operations.DAL.Data.StoreContext;
using Employee_CRUD_Operations.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee_CRUD_Operations.BLL.Specifications;

namespace Employee_CRUD_Operations.BLL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;

        public GenericRepository(StoreContext context)
        {
            _context = context;
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


        public async Task<IReadOnlyList<T>> GetAllAsync()
            => await _context.Set<T>().ToListAsync();

        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecifications<T> spec)
            => await ApplySpecifications(spec).ToListAsync();


        public async Task<T> GetByIdAsync(string id)
            => await _context.Set<T>().FindAsync(id);

        public async Task<int> GetCountAsync(ISpecifications<T> spec)
            => await ApplySpecifications(spec).CountAsync();

        public async Task<T> GetEntityWithSpec(ISpecifications<T> spec)
            => await ApplySpecifications(spec).FirstOrDefaultAsync();

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }


            private IQueryable<T> ApplySpecifications(ISpecifications<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>(), spec);
        }
    }
}
