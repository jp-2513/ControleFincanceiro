﻿using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Property(u => u.Cpf).IsRequired().HasMaxLength(11);
            builder.HasIndex(u => u.Cpf).IsUnique();
            builder.Property(u => u.Profissao).IsRequired().HasMaxLength(30);
            builder.HasMany(u => u.Cartaos).WithOne(u => u.Usuario).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(u => u.Despesas).WithOne(u => u.Usuario).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(u => u.Ganhos).WithOne(u => u.Usuario).OnDelete(DeleteBehavior.NoAction);
            builder.ToTable("Usuario");
        }
    }
}
