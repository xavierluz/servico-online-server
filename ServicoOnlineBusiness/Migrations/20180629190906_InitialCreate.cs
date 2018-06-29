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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoServico",
                schema: "db");
        }
    }
}
