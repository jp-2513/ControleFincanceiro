using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Mappings
{
    public class FuncaoMap : IEntityTypeConfiguration<Funcao>
    {
        public void Configure(EntityTypeBuilder<Funcao> builder)
        {
            //como usuario e funcão quem vai cuidar vai ser o Identity ele não gera os valores de id automaticamente , ai colocamos o ValueGenerate para gerar
            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.Property(f => f.Descricao).IsRequired().HasMaxLength(50);
            builder.HasData(
                new Funcao
                {
                    Id = Guid.NewGuid().ToString(),
                    Name= "Administrator",
                    NormalizedName = "ADIMINISTRADOR",
                    Descricao = "Adm"
                },
                new Funcao
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Usuario",
                    NormalizedName = "USUARIO",
                    Descricao="Usuario Normal"
                });
            builder.ToTable("Funcoes");
        }
    }
}
