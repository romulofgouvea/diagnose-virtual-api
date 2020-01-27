﻿using DiagnoseVirtual.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace DiagnoseVirtual.Infra.Data.Mapping
{
    public class FazendaMap : ClassMapping<Fazenda>, IEntityTypeConfiguration<Fazenda>
    {

        public FazendaMap()
        {
            Table("fazenda");
            Schema("diagnose_virtual");

            Id(x => x.Id, id =>
            {
                id.Generator(Generators.Increment);
            });

            //NHibernate.Mapping.ByCode.Impl.Manytoone

            
            Property(x => x.Concluida, p =>
            {
                p.Column("concluida");
            });

            Property(x => x.Ativa, p =>
            {
                p.Column("ativa");
            });
        }
        
        public void Configure(EntityTypeBuilder<Fazenda> builder)
        {
            //Tabela
            builder.ToTable("fazenda");
            builder.HasKey(x => x.Id);

            //Proriedades
            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("id")
                .ValueGeneratedOnAdd();
            builder.Property(x => x.Demarcacao)
                .HasColumnName("demarcacao_geom");
            builder.Property(x => x.Concluida)
                .HasDefaultValue(false)
                .HasColumnName("concluida");
            builder.Property(x => x.Ativa)
                .HasDefaultValue(true)
                .HasColumnName("ativa");

            //Relacoes
            builder.Property(x => x.IdUsuario)
                .IsRequired()
                .HasColumnName("id_usuario");
            builder.HasOne(x => x.LocalizacaoFazenda)
                .WithOne(l => l.Fazenda)
                .HasForeignKey<LocalizacaoFazenda>(l => l.IdFazenda);
            builder.HasOne(x => x.DadosFazenda)
                .WithOne(d => d.Fazenda)
                .HasForeignKey<DadosFazenda>(d => d.IdFazenda);
            builder.HasMany(x => x.Lavouras)
                .WithOne(l => l.Fazenda)
                .HasForeignKey(l => l.IdFazenda);

            //Indices
            builder.HasIndex(x => x.Id).IsUnique();
            builder.HasIndex(x => x.IdUsuario);

        }
    }
}
