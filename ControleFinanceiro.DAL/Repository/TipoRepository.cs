using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Repository
{
    public class TipoRepository : RepositoryGeneric<Tipo>, ITipoRepository
    {
        public TipoRepository(Context context) : base(context)
        {
        }
    }
}
