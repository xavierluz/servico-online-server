﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServicoOnlineUsuario.usuario.contexto;

namespace ServicoOnlineUsuario.Migrations
{
    [DbContext(typeof(UsuarioContexto))]
    partial class UsuarioContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasMaxLength(50);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnName("TempoConcorrencia");

                    b.Property<string>("Name")
                        .HasColumnName("Nome")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnName("NomeNormalizado")
                        .HasMaxLength(256);

                    b.HasKey("Id")
                        .HasName("PK_Funcao");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NomeNormalizado] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnName("TipoRequisicao")
                        .HasMaxLength(256);

                    b.Property<string>("ClaimValue")
                        .HasColumnName("ValorRequisicao")
                        .HasMaxLength(256);

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnName("RequisicaoFuncaoId")
                        .HasMaxLength(50);

                    b.HasKey("Id")
                        .HasName("PK_FuncaoRequisicao");

                    b.HasIndex("RoleId")
                        .HasName("FuncaoRequisicaoFuncaoIndex");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasMaxLength(50);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnName("ContagemAcessoFalho");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnName("TempoConcorrencia")
                        .HasMaxLength(256);

                    b.Property<string>("Email")
                        .HasColumnName("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnName("EmailConfirmado");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnName("BloqueioAtivo");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnName("BloqueioFinalizado");

                    b.Property<string>("NormalizedEmail")
                        .IsRequired()
                        .HasColumnName("EmailNormalizado")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .IsRequired()
                        .HasColumnName("NomeNormalizado")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnName("Senha")
                        .HasMaxLength(256);

                    b.Property<string>("PhoneNumber")
                        .HasColumnName("Telefone")
                        .HasMaxLength(20);

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnName("TelefoneCofirmado");

                    b.Property<string>("SecurityStamp")
                        .HasColumnName("CodigoSeguranca")
                        .HasMaxLength(256);

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnName("MultiploAcessoHabilitado");

                    b.Property<string>("UserName")
                        .HasColumnName("Nome")
                        .HasMaxLength(256);

                    b.HasKey("Id")
                        .HasName("PK_Usuario");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NomeNormalizado] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnName("TipoRequisicao")
                        .HasMaxLength(256);

                    b.Property<string>("ClaimValue")
                        .HasColumnName("ValorRequisicao")
                        .HasMaxLength(256);

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnName("UsuarioId")
                        .HasMaxLength(50);

                    b.HasKey("Id")
                        .HasName("PK_UsuarioRequisicaoId");

                    b.HasIndex("UserId")
                        .HasName("UsuarioIdIndex");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnName("ProvedorLogin")
                        .HasMaxLength(256);

                    b.Property<string>("ProviderKey")
                        .HasColumnName("ChaveProvedor")
                        .HasMaxLength(256);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnName("NomeProvedor")
                        .HasMaxLength(256);

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnName("UsuarioId")
                        .HasMaxLength(50);

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("PK_UsuarioLogin");

                    b.HasIndex("UserId")
                        .HasName("UsuarioIdIndex");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnName("UsuarioId")
                        .HasMaxLength(256);

                    b.Property<string>("RoleId")
                        .HasColumnName("FuncaoId")
                        .HasMaxLength(50);

                    b.HasKey("UserId", "RoleId")
                        .HasName("PK_UsuarioFuncao");

                    b.HasIndex("RoleId")
                        .HasName("FuncaoIdIndex");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnName("UsuarioId")
                        .HasMaxLength(50);

                    b.Property<string>("LoginProvider")
                        .HasColumnName("ProvedorLogin")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .HasColumnName("Nome")
                        .HasMaxLength(256);

                    b.Property<string>("Value")
                        .HasColumnName("Valor")
                        .HasMaxLength(256);

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("PK_UsuarioToken");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_FuncaoRequisicao_Funcao")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UsuarioRequisicao_Usuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UsuarioLogin_Usuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_UsuarioFuncao_Funcao")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UsuarioFuncao_Usuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UsuarioToken_Usuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
