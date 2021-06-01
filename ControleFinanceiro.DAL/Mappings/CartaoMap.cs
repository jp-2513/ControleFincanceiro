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
    public class CartaoMap : IEntityTypeConfiguration<Cartao>
    {
        public void Configure(EntityTypeBuilder<Cartao> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c=> c.Nome).IsRequired().HasMaxLength(20);
            builder.HasIndex(c => c.Nome).IsUnique();

            builder.Property(c => c.Bandeira).IsRequired().HasMaxLength(15);
            builder.Property(c => c.Numero).IsRequired().HasMaxLength(20);
            builder.HasIndex(c => c.Numero).IsUnique();
            builder.Property(c => c.Limite).IsRequired();

            //aqui estamos relacioando o Cartão ao usuario onde um Cartão vai pertercer apenas um usuario e caso ele for deletado nada acontece
            builder.HasOne(c => c.Usuario).WithMany(c => c.Cartaos).HasForeignKey(c => c.UsuarioId).IsRequired().OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(c => c.Despesas).WithOne(c => c.Cartao);
            builder.ToTable("Cartoes");
        }
    }
}
