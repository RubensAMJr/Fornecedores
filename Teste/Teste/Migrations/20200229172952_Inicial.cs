using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Teste.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UF = table.Column<string>(nullable: false),
                    NOME_FANTASIA = table.Column<string>(nullable: false),
                    CNPJ = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaFK = table.Column<int>(nullable: false),
                    NOME = table.Column<string>(nullable: false),
                    TIPO_PESSOA = table.Column<int>(nullable: false),
                    RG = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true),
                    DATA_CADASTRO = table.Column<DateTime>(nullable: false),
                    DATA_NASCIMENTO = table.Column<DateTime>(nullable: false),
                    TELEFONE_COMERCIAL = table.Column<string>(nullable: true),
                    TELEFONE_RESIDENCIAL = table.Column<string>(nullable: true),
                    TELEFONE_PESSOAL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fornecedor_Empresa_EmpresaFK",
                        column: x => x.EmpresaFK,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_EmpresaFK",
                table: "Fornecedor",
                column: "EmpresaFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
