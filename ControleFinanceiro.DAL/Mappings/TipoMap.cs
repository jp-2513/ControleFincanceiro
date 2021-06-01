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
    public class TipoMap : IEntityTypeConfiguration<Tipo>
    {
        public void Configure(EntityTypeBuilder<Tipo> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Nome).IsRequired().HasMaxLength(20);

            //Criando o relacionamento falando que uma categoria so tem um tipo
            builder.HasMany(t => t.Categorias).WithOne(t => t.Tipo);
            //Populando ja o banco de dados quando for criado
            builder.HasData(
                new Tipo
                {
                    Id = 1,
                    Nome = "Despesa" 
                },
                new Tipo
                {
                    Id = 2,
                    Nome = "Ganho"
                });
            //Quando o banco de dado for criar a tabela ela tera o nome "Tipos"
            builder.ToTable("Tipos");
        }
    }
}
