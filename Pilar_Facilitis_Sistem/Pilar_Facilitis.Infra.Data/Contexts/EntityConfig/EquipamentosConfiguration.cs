﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pilar_Facilitis.Domain.Entities;

namespace Pilar_Facilitis.Infra.Data.Contexts.EntityConfig
{
    public class EquipamentosConfiguration : IEntityTypeConfiguration<Equipamentos>
    {     
        public void Configure(EntityTypeBuilder<Equipamentos> builder)
        {
            builder.HasKey(c => c.EquipamentoId);

            builder.Property(e => e.Desc_Equip)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Fabricante)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.NumDeSerie);

            builder.Property(e => e.Capacidade)
                .IsRequired();
        }
    }
}