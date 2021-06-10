using ControleFinanceiro.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace ControleFinanceiro.DAL.Repository
{
    public class RepositoryGeneric<TEntity> : Interface.IRepositoryGeneric<TEntity> where TEntity : class
    {
        private readonly Context _context;
        public RepositoryGeneric (Context context)
        {
            _context = context;
        }
        public async Task Add(TEntity entity)
        {
            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Add(List<TEntity> entity)
        {
            try
            {
                //salvando varios registros quando precisar salvar mais de um
                await _context.AddRangeAsync(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var entity = await GetById(id);
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Delete(string id)
        {
            try
            {
                var entity = await GetById(id);
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return _context.Set<TEntity>();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TEntity> GetById(int id)
        {
            try
            {
                var entity = await _context.Set<TEntity>().FindAsync(id);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TEntity> GetById(string id)
        {
            try
            {
               var entity = await _context.Set<TEntity>().FindAsync(id);
               return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Update(TEntity entity)
        {
            try
            {
                //Atualiza a classe
                var registro = _context.Set<TEntity>().Update(entity);
                //fala que ele foi modificado
                registro.State = EntityState.Modified;
                //Salva o registro 
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
