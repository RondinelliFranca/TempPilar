using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pilar_Facilitis.Infra.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    CidadeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Sigla = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.CidadeId);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(nullable: false),
                    RazaoSocial = table.Column<string>(maxLength: 200, nullable: false),
                    NomeFantasia = table.Column<string>(maxLength: 200, nullable: false),
                    CNPJ = table.Column<string>(maxLength: 14, nullable: false),
                    Telefone = table.Column<string>(maxLength: 8, nullable: false),
                    Celular = table.Column<string>(maxLength: 9, nullable: false),
                    NomeResponsavel = table.Column<string>(maxLength: 60, nullable: false),
                    Email = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    EquipamentoId = table.Column<Guid>(nullable: false),
                    Desc_Equip = table.Column<string>(maxLength: 200, nullable: false),
                    Capacidade = table.Column<float>(nullable: false),
                    Fabricante = table.Column<string>(maxLength: 200, nullable: false),
                    NumDeSerie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamentos", x => x.EquipamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    EstadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Sigla = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    FuncId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    RG = table.Column<string>(maxLength: 8, nullable: false),
                    CPF = table.Column<string>(maxLength: 11, nullable: false),
                    Telefone_Fixo = table.Column<string>(maxLength: 8, nullable: false),
                    Telefone_Cel = table.Column<string>(maxLength: 9, nullable: false),
                    Email = table.Column<string>(maxLength: 60, nullable: false),
                    Escolaridade = table.Column<string>(maxLength: 40, nullable: false),
                    Qtd_Dependentes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.FuncId);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    PaisId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Sigla = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.PaisId);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    ServicosId = table.Column<Guid>(nullable: false),
                    Desc_Servicos = table.Column<string>(maxLength: 200, nullable: false),
                    Area = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.ServicosId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(maxLength: 60, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Tipo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "PontosAtendimento",
                columns: table => new
                {
                    PontoAtendId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Sigla = table.Column<string>(maxLength: 20, nullable: false),
                    NomeResponsavel = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 60, nullable: false),
                    ClienteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontosAtendimento", x => x.PontoAtendId);
                    table.ForeignKey(
                        name: "FK_PontosAtendimento_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    EnderecoId = table.Column<Guid>(nullable: false),
                    RuaAv = table.Column<string>(nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    Bairro = table.Column<string>(nullable: true),
                    Pais = table.Column<int>(nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    Cidade = table.Column<int>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: true),
                    FuncionarioId = table.Column<Guid>(nullable: true),
                    PontoAtendimentoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.EnderecoId);
                    table.ForeignKey(
                        name: "FK_Enderecos_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enderecos_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enderecos_PontosAtendimento_PontoAtendimentoId",
                        column: x => x.PontoAtendimentoId,
                        principalTable: "PontosAtendimento",
                        principalColumn: "PontoAtendId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_ClienteId",
                table: "Enderecos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_FuncionarioId",
                table: "Enderecos",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_PontoAtendimentoId",
                table: "Enderecos",
                column: "PontoAtendimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_PontosAtendimento_ClienteId",
                table: "PontosAtendimento",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cidade");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Equipamentos");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "PontosAtendimento");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
