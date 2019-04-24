using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pilar_Facilitis.Domain.Entities;

namespace Pilar_Facilitis.Infra.Data.Contexts.EntityConfig
{
    public class ChamadoConfiguration : IEntityTypeConfiguration<Chamado>
    {
        public void Configure(EntityTypeBuilder<Chamado> builder)
        {
            builder.ToTable("Chamado");
            builder.HasKey(e => e.Id);

            builder.HasOne(x => x.Cliente)
                .WithMany(c => c.Chamados);

            builder.HasOne(p=>p.PontoAtendimento)
                .WithMany(c => c.Chamados);

            builder.HasOne(p => p.Servico)
                .WithMany(c => c.Chamados);

        }
    }
}