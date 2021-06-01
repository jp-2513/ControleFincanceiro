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
    class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Icone).IsRequired().HasMaxLength(15);

            //Relacionando as tabelas pelo a chave Estrangeira
            builder.HasOne(c => c.Tipo).WithMany(c => c.Categorias).HasForeignKey(c => c.TipoId);
            //Estamos relacionado onde um ganho so pode ter uma categoria
            builder.HasMany(c => c.Ganhos).WithOne(c => c.Categoria);
            builder.HasMany(c => c.Despesas).WithOne(c => c.Categoria);
            builder.ToTable("Categorias");



        }
    }
}
