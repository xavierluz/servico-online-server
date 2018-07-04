using ServicoOnlineBusiness.bases.banco.interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace ServicoOnlineBusiness.bases.banco.sqlServer
{
    internal class SqlServerFactory: ISqlBase
    {
        private SqlConnection connection = null;
        private const string CONNECTIONSTRING = @"Data Source=D-PROD-BP100906\SQLEXPRESS;Initial Catalog=ServicoOnlineDB;User ID=sa;Password=@Prodesp2018;MultipleActiveResultSets=True";

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
