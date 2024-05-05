using Employee_CRUD_Operations.BLL.Specifications;
using Employee_CRUD_Operations.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_CRUD_Operations.BLL.IRepositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(string id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetEntityWithSpec(ISpecifications<T> spec);
        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecifications<T> spec);

        Task<int> GetCountAsync(ISpecifications<T> spec);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
