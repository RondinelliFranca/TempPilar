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
            builder.HasKey(e => e.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedNever();

            builder.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100);            

            builder.HasOne(x => x.Estado)
                .WithMany(c => c.Cidades)
                .HasForeignKey(e => e.EstadoId);
        }
    }
}
