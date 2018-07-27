using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ServicoOnlineUsuario.usuario.contexto
{
    public class UsuarioContexto : IdentityDbContext
    {
        public UsuarioContexto(DbContextOptions<UsuarioContexto> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasKey(p => p.Id).HasName("PK_Funcao");
            builder.Entity<IdentityRole>().Property(p => p.ConcurrencyStamp).HasColumnName("TempoConcorrencia").IsConcurrencyToken(true).ValueGeneratedOnAddOrUpdate();
            builder.Entity<IdentityRole>().Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd().HasMaxLength(50); ;
            builder.Entity<IdentityRole>().Property(p => p.Name).HasColumnName("Nome").HasMaxLength(256);
            builder.Entity<IdentityRole>().Property(p => p.NormalizedName).HasColumnName("NomeNormalizado").HasMaxLength(256);
            builder.Entity<IdentityRole>().HasIndex(p => p.NormalizedName).IsUnique().HasName("FuncaoNomeIndex").HasFilter("[NomeNormalizado] IS NOT NULL");
            builder.Entity<IdentityRole>().ToTable("Funcao", "dbo");

            builder.Entity<IdentityRoleClaim<string>>().ToTable("FuncaoRequisicao", "dbo");
            builder.Entity<IdentityRoleClaim<string>>().HasKey(p => p.Id).HasName("PK_FuncaoRequisicao");
            builder.Entity<IdentityRoleClaim<string>>().Property(p => p.Id).HasColumnName("Id")
                .ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            builder.Entity<IdentityRoleClaim<string>>().Property(p => p.ClaimType).HasColumnName("TipoRequisicao").HasMaxLength(256);
            builder.Entity<IdentityRoleClaim<string>>().Property(p => p.ClaimValue).HasColumnName("ValorRequisicao").HasMaxLength(256);
            builder.Entity<IdentityRoleClaim<string>>().Property(p => p.RoleId).HasColumnName("RequisicaoFuncaoId").IsRequired().HasMaxLength(50);
            builder.Entity<IdentityRoleClaim<string>>().HasIndex(p => p.RoleId).HasName("FuncaoRequisicaoFuncaoIndex");

            builder.Entity<IdentityUser>().ToTable("Usuario", "dbo");
            builder.Entity<IdentityUser>().HasKey(p => p.Id).HasName("PK_Usuario");
            builder.Entity<IdentityUser>().Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd().HasMaxLength(50);
            builder.Entity<IdentityUser>().Property(p => p.LockoutEnabled).HasColumnName("BloqueioAtivo");
            builder.Entity<IdentityUser>().Property(p => p.LockoutEnd).HasColumnName("BloqueioFinalizado");
            builder.Entity<IdentityUser>().Property(p => p.NormalizedEmail).HasColumnName("EmailNormalizado").IsRequired().HasMaxLength(256);
            builder.Entity<IdentityUser>().Property(p => p.NormalizedUserName).HasColumnName("NomeNormalizado").IsRequired().HasMaxLength(256);
            builder.Entity<IdentityUser>().Property(p => p.PasswordHash).HasColumnName("Senha").HasMaxLength(256);
            builder.Entity<IdentityUser>().Property(p => p.PhoneNumber).HasColumnName("Telefone").HasMaxLength(20);
            builder.Entity<IdentityUser>().Property(p => p.PhoneNumberConfirmed).HasColumnName("TelefoneCofirmado").IsRequired();
            builder.Entity<IdentityUser>().Property(p => p.SecurityStamp).HasColumnName("CodigoSeguranca").HasMaxLength(256);
            builder.Entity<IdentityUser>().Property(p => p.TwoFactorEnabled).HasColumnName("MultiploAcessoHabilitado");
            builder.Entity<IdentityUser>().Property(p => p.UserName).HasColumnName("Nome").HasMaxLength(100);
            builder.Entity<IdentityUser>().Property(p => p.AccessFailedCount).HasColumnName("ContagemAcessoFalho").IsRequired();
            builder.Entity<IdentityUser>().Property(p => p.ConcurrencyStamp).HasColumnName("TempoConcorrencia").HasMaxLength(256);
            builder.Entity<IdentityUser>().Property(p => p.Email).HasColumnName("Email").HasMaxLength(100);
            builder.Entity<IdentityUser>().Property(p => p.EmailConfirmed).HasColumnName("EmailConfirmado");
            builder.Entity<IdentityUser>().HasIndex(p => p.NormalizedEmail).HasName("EmailIndex");
            builder.Entity<IdentityUser>().HasIndex(p => p.NormalizedUserName).IsUnique().HasName("NomeIndex").HasFilter("[NomeNormalizado] IS NOT NULL");

            builder.Entity<IdentityUserClaim<string>>().ToTable("UsuarioRequisicao", "dbo");
            builder.Entity<IdentityUserClaim<string>>().HasKey(p => p.Id).HasName("PK_UsuarioRequisicaoId");
            builder.Entity<IdentityUserClaim<string>>().Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            builder.Entity<IdentityUserClaim<string>>().Property(p => p.ClaimType).HasColumnName("TipoRequisicao").HasMaxLength(256);
            builder.Entity<IdentityUserClaim<string>>().Property(p => p.ClaimValue).HasColumnName("ValorRequisicao").HasMaxLength(256);
            builder.Entity<IdentityUserClaim<string>>().Property(p => p.UserId).HasColumnName("UsuarioId").IsRequired().HasMaxLength(50);
            builder.Entity<IdentityUserClaim<string>>().HasIndex(p => p.UserId).HasName("UsuarioIdIndex");

            builder.Entity<IdentityUserLogin<string>>().ToTable("UsuarioLogin", "dbo");
            builder.Entity<IdentityUserLogin<string>>().HasKey(p => new { p.LoginProvider, p.ProviderKey }).HasName("PK_UsuarioLogin");
            builder.Entity<IdentityUserLogin<string>>().Property(p => p.LoginProvider).HasColumnName("ProvedorLogin").IsRequired().HasMaxLength(256);
            builder.Entity<IdentityUserLogin<string>>().Property(p => p.ProviderKey).HasColumnName("ChaveProvedor").IsRequired().HasMaxLength(256);
            builder.Entity<IdentityUserLogin<string>>().Property(p => p.ProviderDisplayName).HasColumnName("NomeProvedor").HasMaxLength(256);
            builder.Entity<IdentityUserLogin<string>>().Property(p => p.UserId).HasColumnName("UsuarioId").IsRequired().HasMaxLength(50);
            builder.Entity<IdentityUserLogin<string>>().HasIndex(p => p.UserId).HasName("UsuarioIdIndex");

            builder.Entity<IdentityUserRole<string>>().ToTable("UsuarioFuncao", "dbo");
            builder.Entity<IdentityUserRole<string>>().HasKey(p => new { p.UserId, p.RoleId }).HasName("PK_UsuarioFuncao");
            builder.Entity<IdentityUserRole<string>>().Property(p => p.UserId).HasColumnName("UsuarioId").IsRequired().HasMaxLength(256);
            builder.Entity<IdentityUserRole<string>>().Property(p => p.RoleId).HasColumnName("FuncaoId").IsRequired().HasMaxLength(50);
            builder.Entity<IdentityUserRole<string>>().HasIndex(p => p.RoleId).HasName("FuncaoIdIndex");


            builder.Entity<IdentityUserToken<string>>().ToTable("UsuarioToken", "dbo");
            builder.Entity<IdentityUserToken<string>>().HasKey(p => new { p.UserId, p.LoginProvider, p.Name }).HasName("PK_UsuarioToken");
            builder.Entity<IdentityUserToken<string>>().Property(p => p.UserId).HasColumnName("UsuarioId").IsRequired().HasMaxLength(50);
            builder.Entity<IdentityUserToken<string>>().Property(p => p.LoginProvider).HasColumnName("ProvedorLogin").IsRequired().HasMaxLength(256);
            builder.Entity<IdentityUserToken<string>>().Property(p => p.Name).HasColumnName("Nome").IsRequired().HasMaxLength(256);
            builder.Entity<IdentityUserToken<string>>().Property(p => p.Value).HasColumnName("Valor").HasMaxLength(256);

            builder.Entity<IdentityRoleClaim<string>>()
                .HasOne<IdentityRole>()
                .WithMany()
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_FuncaoRequisicao_Funcao");
            builder.Entity<IdentityUserClaim<string>>()
                .HasOne<IdentityUser>()
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_UsuarioRequisicao_Usuario"); ;
            builder.Entity<IdentityUserLogin<string>>()
                .HasOne<IdentityUser>()
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_UsuarioLogin_Usuario"); ;
            builder.Entity<IdentityUserRole<string>>()
                .HasOne<IdentityRole>()
                .WithMany()
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_UsuarioFuncao_Funcao"); ;
            builder.Entity<IdentityUserRole<string>>()
                .HasOne<IdentityUser>()
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_UsuarioFuncao_Usuario"); ;
            builder.Entity<IdentityUserToken<string>>()
                .HasOne<IdentityUser>()
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_UsuarioToken_Usuario");
            builder.HasDefaultSchema("dbo");
           
        }

       
    }
}
