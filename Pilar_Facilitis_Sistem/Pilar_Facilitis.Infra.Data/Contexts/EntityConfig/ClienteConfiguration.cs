using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pilar_Facilitis.Domain.Entities;

namespace Pilar_Facilitis.Infra.Data.Contexts.EntityConfig
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(e => e.Id);

            builder.Property(c => c.NomeFantasia)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.NomeResponsavel)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(c => c.CNPJ)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.RazaoSocial)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.Celular)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.Telefone)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(60);

            builder.HasOne(x => x.Endereco)
                .WithOne()
                .HasForeignKey<Endereco>(e => e.IdCliente);

            builder.HasMany(c => c.PontosAtendimento)
                .WithOne(e => e.Cliente);
        }
    }
}
