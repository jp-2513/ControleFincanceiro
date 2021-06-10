using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Repository
{
    public class CategoriaRepository : RepositoryGeneric<Categoria>,ICategoriaRepository
    {
        private readonly Context _context;
        public CategoriaRepository(Context context) : base(context)
        {
            _context = context;
        }



        public new IQueryable<Categoria> GetAll()
        {
            try
            {
                return _context.Categorias.Include(c => c.Tipo);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public new async Task<Categoria> GetById(int id)
        {
            try
            {
                var entity = await _context.Categorias.Include(c => c.Tipo).FirstOrDefaultAsync(c => c.Id == id);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IQueryable<Categoria> FilterCategoria(string nomeCategoria)
        {
            try
            {
                var entity = _context.Categorias.Include(c => c.Tipo).Where(c => c.Nome.Contains(nomeCategoria));
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
