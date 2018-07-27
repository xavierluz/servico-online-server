using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServicoOnlineUsuario.Migrations
{
    public partial class InitialEmpresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Empresa",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValue: new Guid("8411b844-84eb-46c8-abc9-c358fa3ca74f")),
                    CnpjCpf = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    NomeFantasia = table.Column<string>(maxLength: 200, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<string>(maxLength: 2, nullable: false, defaultValue: "AT")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaminhoArquivo",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CaminhoBaseImagem = table.Column<string>(maxLength: 200, nullable: false),
                    CaminhoBaseDownload = table.Column<string>(maxLength: 200, nullable: false),
                    EmpresaId = table.Column<Guid>(nullable: false),
                    Status = table.Column<string>(maxLength: 2, nullable: false, defaultValue: "AT")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaminhoArquivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaminhoArquivo_Empresa",
                        column: x => x.EmpresaId,
                        principalSchema: "dbo",
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaUsuario",
                schema: "dbo",
                columns: table => new
                {
                    EmpresaId = table.Column<Guid>(nullable: false),
                    UsuarioId = table.Column<string>(maxLength: 50, nullable: false),
                    Status = table.Column<string>(maxLength: 2, nullable: false, defaultValue: "AT"),
                    Key = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaUsuario", x => new { x.EmpresaId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_EmpresaUsuario_Empresa",
                        column: x => x.EmpresaId,
                        principalSchema: "dbo",
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "EmpresaIdIndex",
                schema: "dbo",
                table: "CaminhoArquivo",
                column: "EmpresaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EmpresaIdIndex",
                schema: "dbo",
                table: "EmpresaUsuario",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "UsuarioIdIndex",
                schema: "dbo",
                table: "EmpresaUsuario",
                column: "UsuarioId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaminhoArquivo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmpresaUsuario",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Empresa",
                schema: "dbo");
        }
    }
}
