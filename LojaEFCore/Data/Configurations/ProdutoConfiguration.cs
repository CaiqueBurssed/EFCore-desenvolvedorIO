﻿using LojaEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEFCore.Data.Configurations
{
    class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.CodigoBarras).HasColumnType("VARCHAR(14)").IsRequired();
            builder.Property(p => p.Descricao).HasColumnType("VARCHAR(60)").IsRequired();
            builder.Property(p => p.Valor).IsRequired();
            builder.Property(p => p.TipoProduto).HasConversion<string>();
        }
    }
}
