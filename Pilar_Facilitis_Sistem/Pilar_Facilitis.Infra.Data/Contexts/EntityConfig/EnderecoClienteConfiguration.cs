using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pilar_Facilitis.Domain.Entities;

namespace Pilar_Facilitis.Infra.Data.Contexts.EntityConfig
{
    public class EnderecoClienteConfiguration : IEntityTypeConfiguration<EnderecoClientePilar>
    {
        public void Configure(EntityTypeBuilder<EnderecoClientePilar> builder)
        {
            builder.HasKey(c => c.EnderecoId);

            builder.Property(e => e.RuaAv)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Numero)
                .IsRequired();

            builder.Property(e => e.Pais)
                .IsRequired();

            builder.Property(e => e.Estado)
                .IsRequired();

            builder.Property(e => e.Cidade)
                .IsRequired();

            builder.Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}