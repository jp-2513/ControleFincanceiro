using ControleFinanceiro.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Interface
{
   public interface ICategoriaRepository : IRepositoryGeneric<Categoria>
    {
        new IQueryable<Categoria> GetAll();
        new Task<Categoria> GetById(int id);
        IQueryable<Categoria> FilterCategoria(string nomeCategoria);
    }
}
