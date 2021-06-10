using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Interface
{
    public interface IRepositoryGeneric<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(int id);
        Task<TEntity> GetById(string id);
        Task Add(TEntity entity);
        Task Add(List<TEntity> entity);
        Task Update(TEntity entity);
        Task Delete(int id);
        Task Delete(string id);
    }
}
