using DonutQueen.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DonutQueen.Data
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class { 
        private readonly DonutQueenContext _context;
        public GenericRepository(DonutQueenContext context)
        {
            _context = context;
        }
        
        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        // Navigation property via string .GetAll("Donuts");
        public IQueryable<TEntity> GetAll(params string[] including)
        {
            var query = _context.Set<TEntity>().AsQueryable();
            if (including != null)
                including.ToList().ForEach(include =>{
                    if (!string.IsNullOrEmpty(include))
                        query = query.Include(include);
                });
            return query;
        }

        // Navigation property via lambda/linq x => x.Objectnaam bv  .GetAll(x => x.Donuts)
        public IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] including)
        {
            var query = _context.Set<TEntity>().AsQueryable();
            if (including != null)
                including.ToList().ForEach(include =>{
                    if (include != null)
                        query = query.Include(include);
                });
            return query;
        }

        public void Create (TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
    }
}
