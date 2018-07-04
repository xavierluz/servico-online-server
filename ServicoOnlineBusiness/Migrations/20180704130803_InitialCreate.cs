using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServicoOnlineBusiness.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "db");

            migrationBuilder.CreateTable(
                name: "Pagamento",
                schema: "db",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValue: new Guid("4d4822f3-78a4-4ae4-95f5-4d312f36fae0")),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Telefone = table.Column<string>(maxLength: 12, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    FormaPagamento = table.Column<string>(maxLength: 3, nullable: false, defaultValue: "DHR"),
                    Descricao = table.Column<string>(maxLength: 1000, nullable: true),
                    Status = table.Column<string>(maxLength: 2, nullable: true, defaultValue: "AT")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoServico",
                schema: "db",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(maxLength: 500, nullable: true),
                    caminhoDaImage = table.Column<string>(maxLength: 200, nullable: true),
                    Status = table.Column<string>(maxLength: 2, nullable: true, defaultValue: "AT")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoServico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servico",
                schema: "db",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Indicacao = table.Column<string>(maxLength: 150, nullable: true),
                    Descricao = table.Column<string>(maxLength: 1000, nullable: true),
                    Preco = table.Column<decimal>(nullable: false),
                    tipoServicoDominioId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(maxLength: 2, nullable: true, defaultValue: "AT")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servico_TipoServico_tipoServicoDominioId",
                        column: x => x.tipoServicoDominioId,
                        principalSchema: "db",
                        principalTable: "TipoServico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PagamentoItem",
                schema: "db",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValue: new Guid("10652d6f-6d06-4d4a-9cf6-066d0422ed69")),
                    PagamentoDominioId = table.Column<Guid>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    Status = table.Column<string>(maxLength: 2, nullable: true, defaultValue: "AT"),
                    ServicoDominioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagamentoItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PagamentoItem_Pagamento_PagamentoDominioId",
                        column: x => x.PagamentoDominioId,
                        principalSchema: "db",
                        principalTable: "Pagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PagamentoItem_Servico_ServicoDominioId",
                        column: x => x.ServicoDominioId,
                        principalSchema: "db",
                        principalTable: "Servico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoItem_PagamentoDominioId",
                schema: "db",
                table: "PagamentoItem",
                column: "PagamentoDominioId");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoItem_ServicoDominioId",
                schema: "db",
                table: "PagamentoItem",
                column: "ServicoDominioId");

            migrationBuilder.CreateIndex(
                name: "IX_Servico_tipoServicoDominioId",
                schema: "db",
                table: "Servico",
                column: "tipoServicoDominioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PagamentoItem",
                schema: "db");

            migrationBuilder.DropTable(
                name: "Pagamento",
                schema: "db");

            migrationBuilder.DropTable(
                name: "Servico",
                schema: "db");

            migrationBuilder.DropTable(
                name: "TipoServico",
                schema: "db");
        }
    }
}
