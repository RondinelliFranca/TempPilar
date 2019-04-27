using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pilar_Facilitis.Infra.Data.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RazaoSocial = table.Column<string>(maxLength: 200, nullable: false),
                    NomeFantasia = table.Column<string>(maxLength: 200, nullable: false),
                    CNPJ = table.Column<string>(maxLength: 20, nullable: false),
                    Telefone = table.Column<string>(maxLength: 20, nullable: false),
                    Celular = table.Column<string>(maxLength: 20, nullable: false),
                    NomeResponsavel = table.Column<string>(maxLength: 60, nullable: false),
                    Email = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Desc_Equip = table.Column<string>(maxLength: 200, nullable: false),
                    Capacidade = table.Column<float>(nullable: false),
                    Fabricante = table.Column<string>(maxLength: 200, nullable: false),
                    NumDeSerie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Sigla = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    RG = table.Column<string>(maxLength: 20, nullable: false),
                    CPF = table.Column<string>(maxLength: 11, nullable: false),
                    Telefone_Fixo = table.Column<string>(maxLength: 20, nullable: false),
                    Telefone_Cel = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 60, nullable: false),
                    Escolaridade = table.Column<string>(maxLength: 40, nullable: false),
                    Qtd_Dependentes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Desc_Servicos = table.Column<string>(maxLength: 200, nullable: false),
                    Area = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(maxLength: 60, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Tipo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PontosAtendimento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Sigla = table.Column<string>(maxLength: 20, nullable: false),
                    NomeResponsavel = table.Column<string>(nullable: false),
                    Telefone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 60, nullable: false),
                    ClienteId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontosAtendimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PontosAtendimento_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    EstadoId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cidade_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chamado",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataSolicitacao = table.Column<DateTime>(nullable: false),
                    Prioridade = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    DescricaoProblema = table.Column<string>(nullable: true),
                    DescricaoAtendimento = table.Column<string>(nullable: true),
                    ClienteId = table.Column<Guid>(nullable: true),
                    PontoAtendimentoId = table.Column<Guid>(nullable: true),
                    ServicoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chamado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chamado_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chamado_PontosAtendimento_PontoAtendimentoId",
                        column: x => x.PontoAtendimentoId,
                        principalTable: "PontosAtendimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chamado_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdCliente = table.Column<Guid>(nullable: true),
                    IdFuncionario = table.Column<Guid>(nullable: true),
                    IdPontoAtendimento = table.Column<Guid>(nullable: true),
                    RuaAv = table.Column<string>(nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    Bairro = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    Pais = table.Column<int>(nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    IdCidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enderecos_Funcionarios_IdFuncionario",
                        column: x => x.IdFuncionario,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enderecos_PontosAtendimento_IdPontoAtendimento",
                        column: x => x.IdPontoAtendimento,
                        principalTable: "PontosAtendimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chamado_ClienteId",
                table: "Chamado",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Chamado_PontoAtendimentoId",
                table: "Chamado",
                column: "PontoAtendimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Chamado_ServicoId",
                table: "Chamado",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_EstadoId",
                table: "Cidade",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_IdCliente",
                table: "Enderecos",
                column: "IdCliente",
                unique: true,
                filter: "[IdCliente] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_IdFuncionario",
                table: "Enderecos",
                column: "IdFuncionario",
                unique: true,
                filter: "[IdFuncionario] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_IdPontoAtendimento",
                table: "Enderecos",
                column: "IdPontoAtendimento",
                unique: true,
                filter: "[IdPontoAtendimento] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PontosAtendimento_ClienteId",
                table: "PontosAtendimento",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chamado");

            migrationBuilder.DropTable(
                name: "Cidade");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Equipamentos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "PontosAtendimento");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
