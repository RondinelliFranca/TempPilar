﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pilar_Facilitis.Domain.Entities;

namespace Pilar_Facilitis.Infra.Data.Contexts.EntityConfig
{
    public class ClientePilarConfiguration : IEntityTypeConfiguration<ClientePilar>
    {
        public void Configure(EntityTypeBuilder<ClientePilar> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(e => e.ClienteId);

            builder.Property(c => c.NomeFantasia)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.NomeResponsavel)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(c => c.CNPJ)
                .IsRequired()
                .HasMaxLength(14);

            builder.Property(c => c.RazaoSocial)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.TelefoneCel)
                .IsRequired()
                .HasMaxLength(9);

            builder.Property(c => c.TelefoneFixo)
                .IsRequired()
                .HasMaxLength(8);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(60);
        }
    }
}
