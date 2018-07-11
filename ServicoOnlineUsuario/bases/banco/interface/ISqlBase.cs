using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ServicoOnlineUsuario.bases.banco.interfaces
{
    public interface ISqlBase
    {
        DbConnection getConnection();
    }
}
