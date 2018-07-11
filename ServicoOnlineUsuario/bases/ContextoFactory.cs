using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ServicoOnlineUsuario.usuario.contexto;

namespace ServicoOnlineUsuario.bases
{
    public class ContextoFactory : IDesignTimeDbContextFactory<UsuarioContexto>
    {
        //migrations
        public UsuarioContexto CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UsuarioContexto>();
            optionsBuilder.UseSqlServer(@"Data Source=D-PROD-BP100906\SQLEXPRESS;Initial Catalog=ServicoOnlineDB;User ID=sa;Password=@Prodesp2018");

            return UsuarioContexto.Create(optionsBuilder.Options);
        }
    }
}
