using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pilar_Facilitis.Domain.Entities;

namespace Pilar_Facilitis.Infra.Data.Contexts.EntityConfig
{
    public class EnderecoFuncionarioConfiguration : IEntityTypeConfiguration<EnderecoFuncionario>
    {
        public EnderecoFuncionarioConfiguration()
        {
            HasKey(c => c.EnderecoId);

            Property(e => e.RuaAv)
                .IsRequired()
                .HasMaxLength(200);

            Property(e => e.Numero)
                .IsRequired();

            Property(e => e.Pais)
                .IsRequired();

            Property(e => e.Estado)
                .IsRequired();

            Property(e => e.Cidade)
                .IsRequired();

            Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(200);

            HasRequired(e => e.FuncionarioPilar)
                .WithMany()
                .HasForeignKey(e => e.FuncId);

        }

        public void Configure(EntityTypeBuilder<EnderecoFuncionario> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}
