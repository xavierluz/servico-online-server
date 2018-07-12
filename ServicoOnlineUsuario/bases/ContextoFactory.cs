using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ServicoOnlineUsuario.empresa.contexto;
using ServicoOnlineUsuario.usuario.contexto;

namespace ServicoOnlineUsuario.bases
{
    public class ContextoFactory : IDesignTimeDbContextFactory<EmpresaContexto>
    {
        //migrations
        public EmpresaContexto CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EmpresaContexto>();
            optionsBuilder.UseSqlServer(@"Data Source=D-PROD-BP100906\SQLEXPRESS;Initial Catalog=ServicoOnlineDB;User ID=sa;Password=@Prodesp2018");

            return EmpresaContexto.Create(optionsBuilder.Options);
        }
    }
}
