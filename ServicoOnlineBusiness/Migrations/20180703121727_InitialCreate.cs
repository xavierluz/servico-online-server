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
                    Descricao = table.Column<string>(maxLength: 500, nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_Servico_tipoServicoDominioId",
                schema: "db",
                table: "Servico",
                column: "tipoServicoDominioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servico",
                schema: "db");

            migrationBuilder.DropTable(
                name: "TipoServico",
                schema: "db");
        }
    }
}
