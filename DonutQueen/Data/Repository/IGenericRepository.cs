using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DonutQueen.Data
{
    public interface IGenericRepository <TEntity> where TEntity : class
    {
 
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(int id);

        void Create(TEntity entity);
        void Update(TEntity entity);

        void Delete(TEntity entity);

        public IQueryable<TEntity> GetAll(params string[] including);

        public IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] including);
        //public IQueryable<T> Include<T>(Expression<Func<T, Object>> criteria) where T : class;
    }
}
