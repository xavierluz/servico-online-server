using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ServicoOnlineBusiness.tiposervico.contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoOnlineBusiness.bases
{
    public class ContextoFactory : IDesignTimeDbContextFactory<TipoServicoDbContexto>
    {
        //migrations
        public TipoServicoDbContexto CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TipoServicoDbContexto>();
            optionsBuilder.UseSqlServer(@"Data Source=D-PROD-BP100906\SQLEXPRESS;Initial Catalog=ServicoOnlineDB;User ID=sa;Password=@Prodesp2018");

            return  TipoServicoDbContexto.Create(optionsBuilder.Options);
        }
    }
}
