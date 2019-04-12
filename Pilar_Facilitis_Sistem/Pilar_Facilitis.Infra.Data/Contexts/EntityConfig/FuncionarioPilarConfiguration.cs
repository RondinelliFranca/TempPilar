using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pilar_Facilitis.Domain.Entities;

namespace Pilar_Facilitis.Infra.Data.Contexts.EntityConfig
{
    public class FuncionarioPilarConfiguration : IEntityTypeConfiguration<Funcionario>
    {      
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(c => c.Id);

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
                .HasMaxLength(20);

            builder.Property(c => c.Telefone_Cel)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.Telefone_Fixo)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.Qtd_Dependentes)
                .IsRequired();

            builder.HasOne(x => x.Endereco)
                .WithOne()
                .HasForeignKey<Endereco>(e => e.IdFuncionario);
        }
    }
}
