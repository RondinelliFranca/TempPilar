using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pilar_Facilitis.Domain.Entities;

namespace Pilar_Facilitis.Infra.Data.Contexts.EntityConfig
{
    public class FuncionarioPilarConfiguration : IEntityTypeConfiguration<FuncionarioPilar>
    {      
        public void Configure(EntityTypeBuilder<FuncionarioPilar> builder)
        {
            builder.HasKey(c => c.FuncId);

            builder.Property(c => c.CPF)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(c => c.Escolaridade)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(c => c.Nome)
                .IsRequired();

            builder.Property(c => c.RG)
                .IsRequired()
                .HasMaxLength(8);

            builder.Property(c => c.Telefone_Cel)
                .IsRequired()
                .HasMaxLength(9);

            builder.Property(c => c.Telefone_Fixo)
                .IsRequired()
                .HasMaxLength(8);

            builder.Property(c => c.Qtd_Dependentes)
                .IsRequired();
        }
    }
}
