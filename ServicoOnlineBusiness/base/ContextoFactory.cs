﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ServicoOnlineBusiness.bases.contexto;

namespace ServicoOnlineBusiness.bases
{
    public class ContextoFactory : IDesignTimeDbContextFactory<ServicoContexto>
    {
        //migrations
        public ServicoContexto CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ServicoContexto>();
            optionsBuilder.UseSqlServer(@"Data Source=D-PROD-BP100906\SQLEXPRESS;Initial Catalog=ServicoOnlineDB;persist security info=True;User ID=sa;Password=@Prodesp2018;MultipleActiveResultSets=True;App=EntityFramework");

            return ServicoContexto.Create(optionsBuilder.Options);
        }
    }
}
