using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Pilar_Facilitis.Domain.Entities;
using Pilar_Facilitis.Infra.Data.Contexts.EntityConfig;

namespace Pilar_Facilitis.Infra.Data.Contexts.Base
{
    public class ContextPilarFacilitis : DbContext
    {
        public ContextPilarFacilitis(DbContextOptions<ContextPilarFacilitis> options)
        : base(options)
        {         
        }

        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Equipamentos> Equipamentos{ get; set; }
        public DbSet<Estado> Estados{ get; set; }
        public DbSet<Funcionario> Funcionarios{ get; set; }
        public DbSet<Pais> Paises{ get; set; }
        public DbSet<PontoAtendimentos> PontosAtendimento { get; set; }
        public DbSet<Servicos> Servicos{ get; set; }
        public DbSet<Usuarios> Usuarios{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ForSqlServerUseIdentityColumns();
            CidadeConfiguration.Mapper()
        }


    }
}