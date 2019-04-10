﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pilar_Facilitis.Infra.Data.Contexts.Base;

namespace Pilar_Facilitis.Infra.Data.Migrations
{
    [DbContext(typeof(ContextPilarFacilitis))]
    partial class ContextPilarFacilitisModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pilar_Facilitis.Domain.Entities.Cidade", b =>
                {
                    b.Property<int>("CidadeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Sigla")
                        .IsRequired();

                    b.HasKey("CidadeId");

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("Pilar_Facilitis.Domain.Entities.Cliente", b =>
                {
                    b.Property<Guid>("ClienteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(14);

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasMaxLength(9);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("NomeResponsavel")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Pilar_Facilitis.Domain.Entities.Endereco", b =>
                {
                    b.Property<Guid>("EnderecoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro");

                    b.Property<int>("Cidade");

                    b.Property<Guid?>("ClienteId");

                    b.Property<int>("Estado");

                    b.Property<Guid?>("FuncionarioId");

                    b.Property<int>("Numero");

                    b.Property<int>("Pais");

                    b.Property<Guid?>("PontoAtendimentoId");

                    b.Property<string>("RuaAv");

                    b.HasKey("EnderecoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FuncionarioId");

                    b.HasIndex("PontoAtendimentoId");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Pilar_Facilitis.Domain.Entities.Equipamentos", b =>
                {
                    b.Property<Guid>("EquipamentoId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Capacidade");

                    b.Property<string>("Desc_Equip")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Fabricante")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("NumDeSerie");

                    b.HasKey("EquipamentoId");

                    b.ToTable("Equipamentos");
                });

            modelBuilder.Entity("Pilar_Facilitis.Domain.Entities.Estado", b =>
                {
                    b.Property<int>("EstadoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Sigla");

                    b.HasKey("EstadoId");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("Pilar_Facilitis.Domain.Entities.Funcionario", b =>
                {
                    b.Property<Guid>("FuncId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Escolaridade")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int>("Qtd_Dependentes");

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.Property<string>("Telefone_Cel")
                        .IsRequired()
                        .HasMaxLength(9);

                    b.Property<string>("Telefone_Fixo")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.HasKey("FuncId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("Pilar_Facilitis.Domain.Entities.Pais", b =>
                {
                    b.Property<int>("PaisId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Sigla");

                    b.HasKey("PaisId");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("Pilar_Facilitis.Domain.Entities.PontoAtendimentos", b =>
                {
                    b.Property<Guid>("PontoAtendId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ClienteId");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("NomeResponsavel")
                        .IsRequired();

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("PontoAtendId");

                    b.HasIndex("ClienteId");

                    b.ToTable("PontosAtendimento");
                });

            modelBuilder.Entity("Pilar_Facilitis.Domain.Entities.Servicos", b =>
                {
                    b.Property<Guid>("ServicosId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Area");

                    b.Property<string>("Desc_Servicos")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("ServicosId");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("Pilar_Facilitis.Domain.Entities.Usuarios", b =>
                {
                    b.Property<string>("UsuarioId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Tipo")
                        .IsRequired();

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Pilar_Facilitis.Domain.Entities.Endereco", b =>
                {
                    b.HasOne("Pilar_Facilitis.Domain.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("Pilar_Facilitis.Domain.Entities.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId");

                    b.HasOne("Pilar_Facilitis.Domain.Entities.PontoAtendimentos", "PontoAtendimento")
                        .WithMany()
                        .HasForeignKey("PontoAtendimentoId");
                });

            modelBuilder.Entity("Pilar_Facilitis.Domain.Entities.PontoAtendimentos", b =>
                {
                    b.HasOne("Pilar_Facilitis.Domain.Entities.Cliente", "Cliente")
                        .WithMany("PontosAtendimento")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
