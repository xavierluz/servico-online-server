using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServicoOnlineUsuario.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    Nome = table.Column<string>(maxLength: 256, nullable: true),
                    NomeNormalizado = table.Column<string>(maxLength: 256, nullable: true),
                    TempoConcorrencia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    Nome = table.Column<string>(maxLength: 256, nullable: true),
                    NomeNormalizado = table.Column<string>(maxLength: 256, nullable: false),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailNormalizado = table.Column<string>(maxLength: 256, nullable: false),
                    EmailConfirmado = table.Column<bool>(nullable: false),
                    Senha = table.Column<string>(maxLength: 256, nullable: true),
                    CodigoSeguranca = table.Column<string>(maxLength: 256, nullable: true),
                    TempoConcorrencia = table.Column<string>(maxLength: 256, nullable: true),
                    Telefone = table.Column<string>(maxLength: 20, nullable: true),
                    TelefoneCofirmado = table.Column<bool>(nullable: false),
                    MultiploAcessoHabilitado = table.Column<bool>(nullable: false),
                    BloqueioFinalizado = table.Column<DateTimeOffset>(nullable: true),
                    BloqueioAtivo = table.Column<bool>(nullable: false),
                    ContagemAcessoFalho = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RequisicaoFuncaoId = table.Column<string>(maxLength: 50, nullable: false),
                    TipoRequisicao = table.Column<string>(maxLength: 256, nullable: true),
                    ValorRequisicao = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncaoRequisicao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuncaoRequisicao_Funcao",
                        column: x => x.RequisicaoFuncaoId,
                        principalSchema: "dbo",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<string>(maxLength: 50, nullable: false),
                    TipoRequisicao = table.Column<string>(maxLength: 256, nullable: true),
                    ValorRequisicao = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRequisicaoId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioRequisicao_Usuario",
                        column: x => x.UsuarioId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "dbo",
                columns: table => new
                {
                    ProvedorLogin = table.Column<string>(maxLength: 256, nullable: false),
                    ChaveProvedor = table.Column<string>(maxLength: 256, nullable: false),
                    NomeProvedor = table.Column<string>(maxLength: 256, nullable: true),
                    UsuarioId = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioLogin", x => new { x.ProvedorLogin, x.ChaveProvedor });
                    table.ForeignKey(
                        name: "FK_UsuarioLogin_Usuario",
                        column: x => x.UsuarioId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "dbo",
                columns: table => new
                {
                    UsuarioId = table.Column<string>(maxLength: 256, nullable: false),
                    FuncaoId = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioFuncao", x => new { x.UsuarioId, x.FuncaoId });
                    table.ForeignKey(
                        name: "FK_UsuarioFuncao_Funcao",
                        column: x => x.FuncaoId,
                        principalSchema: "dbo",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioFuncao_Usuario",
                        column: x => x.UsuarioId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "dbo",
                columns: table => new
                {
                    UsuarioId = table.Column<string>(maxLength: 50, nullable: false),
                    ProvedorLogin = table.Column<string>(maxLength: 256, nullable: false),
                    Nome = table.Column<string>(maxLength: 256, nullable: false),
                    Valor = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioToken", x => new { x.UsuarioId, x.ProvedorLogin, x.Nome });
                    table.ForeignKey(
                        name: "FK_UsuarioToken_Usuario",
                        column: x => x.UsuarioId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "FuncaoRequisicaoFuncaoIndex",
                schema: "dbo",
                table: "AspNetRoleClaims",
                column: "RequisicaoFuncaoId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dbo",
                table: "AspNetRoles",
                column: "NomeNormalizado",
                unique: true,
                filter: "[NomeNormalizado] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UsuarioIdIndex",
                schema: "dbo",
                table: "AspNetUserClaims",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "UsuarioIdIndex",
                schema: "dbo",
                table: "AspNetUserLogins",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "FuncaoIdIndex",
                schema: "dbo",
                table: "AspNetUserRoles",
                column: "FuncaoId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dbo",
                table: "AspNetUsers",
                column: "EmailNormalizado");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbo",
                table: "AspNetUsers",
                column: "NomeNormalizado",
                unique: true,
                filter: "[NomeNormalizado] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "dbo");
        }
    }
}
