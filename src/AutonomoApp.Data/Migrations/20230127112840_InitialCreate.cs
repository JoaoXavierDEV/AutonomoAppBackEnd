using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutonomoApp.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AACategorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnumId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(20)", nullable: true),
                    Descricao = table.Column<string>(type: "varchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AACategorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AAConta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioVerificado = table.Column<bool>(type: "bit", nullable: false),
                    PremiumAtivo = table.Column<bool>(type: "bit", nullable: false),
                    PlanoVitalicio = table.Column<bool>(type: "bit", nullable: false),
                    RenovacaoAutomatica = table.Column<bool>(type: "bit", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AAConta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AAEnderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(55)", nullable: true),
                    Numero = table.Column<string>(type: "varchar(50)", nullable: true),
                    Complemento = table.Column<string>(type: "varchar(250)", nullable: true),
                    Cep = table.Column<string>(type: "varchar(8)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: true),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: true),
                    Estado = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AAEnderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AASubCategorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnumId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    Descricao = table.Column<string>(type: "varchar(150)", nullable: true),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AASubCategorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AASubCategorias_AACategorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "AACategorias",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AABeneficio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(100)", nullable: false),
                    TipoDeBeneficio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AABeneficio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AABeneficio_AAConta_ContaId",
                        column: x => x.ContaId,
                        principalTable: "AAConta",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AAPessoa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    EnderecoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Documento = table.Column<string>(type: "varchar(100)", nullable: true),
                    TipoDocumento = table.Column<int>(type: "int", nullable: false),
                    ContaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AAPessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AAPessoa_AAConta_ContaId",
                        column: x => x.ContaId,
                        principalTable: "AAConta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AAPessoa_AAEnderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "AAEnderecos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AAPessoaFisica",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AAPessoaFisica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AAPessoaFisica_AAPessoa_Id",
                        column: x => x.Id,
                        principalTable: "AAPessoa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AAPessoaJuridica",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeEmpresa = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AAPessoaJuridica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AAPessoaJuridica_AAPessoa_Id",
                        column: x => x.Id,
                        principalTable: "AAPessoa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AAServicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientePrestadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataPublicada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoDeServico = table.Column<int>(type: "int", nullable: false),
                    AnuncioAtivo = table.Column<bool>(type: "bit", nullable: false),
                    PermiteParcelamento = table.Column<bool>(type: "bit", nullable: false),
                    TemDesconto = table.Column<bool>(type: "bit", nullable: false),
                    Desconto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubcategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AAServicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AAServicos_AACategorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "AACategorias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AAServicos_AAPessoa_ClientePrestadorId",
                        column: x => x.ClientePrestadorId,
                        principalTable: "AAPessoa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AAServicos_AASubCategorias_SubcategoriaId",
                        column: x => x.SubcategoriaId,
                        principalTable: "AASubCategorias",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AAHistoricoDePedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteSolicitanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ServicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataConclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataConclusaoEstimada = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AAHistoricoDePedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AAHistoricoDePedidos_AAPessoa_ClienteSolicitanteId",
                        column: x => x.ClienteSolicitanteId,
                        principalTable: "AAPessoa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AAHistoricoDePedidos_AAServicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "AAServicos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AABeneficio_ContaId",
                table: "AABeneficio",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_AAHistoricoDePedidos_ClienteSolicitanteId",
                table: "AAHistoricoDePedidos",
                column: "ClienteSolicitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_AAHistoricoDePedidos_ServicoId",
                table: "AAHistoricoDePedidos",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_AAPessoa_ContaId",
                table: "AAPessoa",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_AAPessoa_EnderecoId",
                table: "AAPessoa",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_AAServicos_CategoriaId",
                table: "AAServicos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_AAServicos_ClientePrestadorId",
                table: "AAServicos",
                column: "ClientePrestadorId");

            migrationBuilder.CreateIndex(
                name: "IX_AAServicos_SubcategoriaId",
                table: "AAServicos",
                column: "SubcategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_AASubCategorias_CategoriaId",
                table: "AASubCategorias",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AABeneficio");

            migrationBuilder.DropTable(
                name: "AAHistoricoDePedidos");

            migrationBuilder.DropTable(
                name: "AAPessoaFisica");

            migrationBuilder.DropTable(
                name: "AAPessoaJuridica");

            migrationBuilder.DropTable(
                name: "AAServicos");

            migrationBuilder.DropTable(
                name: "AAPessoa");

            migrationBuilder.DropTable(
                name: "AASubCategorias");

            migrationBuilder.DropTable(
                name: "AAConta");

            migrationBuilder.DropTable(
                name: "AAEnderecos");

            migrationBuilder.DropTable(
                name: "AACategorias");
        }
    }
}
