﻿using Employee_CRUD_Operations.BLL.IRepositories;
using Employee_CRUD_Operations.DAL.Data.StoreContext;
using Employee_CRUD_Operations.DAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_CRUD_Operations.BLL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _context;
        private Hashtable _repostories;

        public UnitOfWork(StoreContext context)
        {
            _context = context;
        }
        public async Task<int> Complete()
            => await _context.SaveChangesAsync();

        public void Dispose()
            => _context.Dispose();

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repostories == null) _repostories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repostories.ContainsKey(type))
            {
                var repository = new GenericRepository<TEntity>(_context);
                _repostories.Add(type, repository);
            }

            return (IGenericRepository<TEntity>)_repostories[type];
        }
    }
}
