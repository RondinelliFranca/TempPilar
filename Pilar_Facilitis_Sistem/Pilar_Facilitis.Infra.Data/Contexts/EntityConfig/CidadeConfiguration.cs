using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pilar_Facilitis.Domain.Entities;

namespace Pilar_Facilitis.Infra.Data.Contexts.EntityConfig
{
    public class CidadeConfiguration : IEntityTypeConfiguration<Cidade>
    {    
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {

            builder.ToTable("Cidade");
            builder.HasKey(e => e.CidadeId);

            builder.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(e => e.Sigla).IsRequired();                    
        }
    }
}
