﻿using DiagnoseVirtual.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiagnoseVirtual.Infra.Data.Mapping
{
    public class EstadoMapping : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            //Tabela
            builder.ToTable("estado");
            builder.HasKey(x => x.Id);

            //Proriedades
            builder.Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(x => x.Nome)
                .HasColumnName("nome")
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(x => x.Sigla)
                .HasColumnName("sigla")
                .HasMaxLength(2)
                .IsRequired();

            //Relacoes
            builder.HasMany(x => x.Municipios)
                .WithOne(m => m.Estado)
                .HasForeignKey("id_estado");

            //Indices
            builder.HasIndex(x => x.Id).IsUnique();
        }
    }
}
