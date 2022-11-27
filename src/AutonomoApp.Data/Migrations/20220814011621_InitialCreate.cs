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
                    CatEnumId = table.Column<int>(type: "int", nullable: true),
                    Nome = table.Column<string>(type: "varchar(20)", nullable: true),
                    Descricao = table.Column<string>(type: "varchar(150)", nullable: true),
                    SubcategoriasId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AACategorias", x => x.Id);
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
                    SubCatEnumId = table.Column<int>(type: "int", nullable: true),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    Descricao = table.Column<string>(type: "varchar(150)", nullable: true),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ServicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                name: "AAPessoa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    EnderecoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Documento = table.Column<string>(type: "varchar(100)", nullable: false),
                    TipoDocumentoEnum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AAPessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AAPessoa_AAEnderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "AAEnderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubcategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AAServicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AAServicos_AAPessoa_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "AAPessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AAHistoricoDePedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServicoSolicitadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataConclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataConclusaoEstimada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PessoaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AAHistoricoDePedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AAHistoricoDePedidos_AAPessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "AAPessoa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AAHistoricoDePedidos_AAServicos_ServicoSolicitadoId",
                        column: x => x.ServicoSolicitadoId,
                        principalTable: "AAServicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AAServicoCategoria",
                columns: table => new
                {
                    ServicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AAServicoCategoria", x => new { x.ServicoId, x.CategoriaId });
                    table.ForeignKey(
                        name: "FK_AAServicoCategoria_AACategorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "AACategorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AAServicoCategoria_AAServicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "AAServicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AAServicoSubCategoria",
                columns: table => new
                {
                    ServicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubCategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AAServicoSubCategoria", x => new { x.ServicoId, x.SubCategoriaId });
                    table.ForeignKey(
                        name: "FK_AAServicoSubCategoria_AAServicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "AAServicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AAServicoSubCategoria_AASubCategorias_SubCategoriaId",
                        column: x => x.SubCategoriaId,
                        principalTable: "AASubCategorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AAHistoricoDePedidos_PessoaId",
                table: "AAHistoricoDePedidos",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_AAHistoricoDePedidos_ServicoSolicitadoId",
                table: "AAHistoricoDePedidos",
                column: "ServicoSolicitadoId");

            migrationBuilder.CreateIndex(
                name: "IX_AAPessoa_EnderecoId",
                table: "AAPessoa",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_AAServicoCategoria_CategoriaId",
                table: "AAServicoCategoria",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_AAServicos_ClienteId",
                table: "AAServicos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_AAServicoSubCategoria_SubCategoriaId",
                table: "AAServicoSubCategoria",
                column: "SubCategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_AASubCategorias_CategoriaId",
                table: "AASubCategorias",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AAHistoricoDePedidos");

            migrationBuilder.DropTable(
                name: "AAPessoaFisica");

            migrationBuilder.DropTable(
                name: "AAPessoaJuridica");

            migrationBuilder.DropTable(
                name: "AAServicoCategoria");

            migrationBuilder.DropTable(
                name: "AAServicoSubCategoria");

            migrationBuilder.DropTable(
                name: "AAServicos");

            migrationBuilder.DropTable(
                name: "AASubCategorias");

            migrationBuilder.DropTable(
                name: "AAPessoa");

            migrationBuilder.DropTable(
                name: "AACategorias");

            migrationBuilder.DropTable(
                name: "AAEnderecos");
        }
    }
}
