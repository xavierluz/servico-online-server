using ServicoOnlineUsuario.bases.banco.interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace ServicoOnlineUsuario.bases.banco.sqlServer
{
    internal class SqlServerFactory: ISqlBase
    {
        private SqlConnection connection = null;
        private const string CONNECTIONSTRING = @"Data Source=D-PROD-BP100906\SQLEXPRESS;Initial Catalog=ServicoOnlineUsuarioDB;User ID=sa;Password=@Prodesp2018";

        private SqlServerFactory()
        {
            connection = new SqlConnection(CONNECTIONSTRING);

        }
        public static SqlServerFactory Create()
        {
            return new SqlServerFactory();
        }
        public DbConnection getConnection()
        {
            return this.connection;
        }
    }
}
