using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.BLL.Models
{
   public class Usuario : IdentityUser<string>
    {
        public string Cpf { get; set; }
        public string Profissao { get; set; }
        public Byte[] Foto { get; set; }
        public virtual ICollection<Cartao>Cartaos { get; set; }
        public virtual ICollection<Ganho>Ganhos { get; set; }
        public virtual ICollection<Despesa> Despesas { get; set; }

    }
}
