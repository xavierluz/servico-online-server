using ServicoOnlineUsuario.bases;
using ServicoOnlineUsuario.bases.banco.interfaces;
using ServicoOnlineUsuario.bases.banco.sqlServer;
using ServicoOnlineUsuario.empresa;
using ServicoOnlineUsuario.empresa.dominio.interfaces;
using ServicoOnlineUsuario.perfil;
using ServicoOnlineUsuario.usuario;
using ServicoOnlineUsuario.usuario.dominio.entidade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ServicoOnlineUsuario
{
    public class FactoryServices
    {
        private IsolationLevel isolationLevel = IsolationLevel.Unspecified;
        private ISqlBase sqlBase = null;

        private FactoryServices(IsolationLevel isolationLevel) {
            sqlBase = SqlServerFactory.Create();
            this.isolationLevel = isolationLevel;
        }

        public static FactoryServices Create(IsolationLevel isolationLevel)
        {
            return new FactoryServices(isolationLevel);
        }

        public UsuarioServices getUsuario()
        {
            return UsuarioServices.Create(this.sqlBase, this.isolationLevel);
        }
        public EmpresaServices getEmpresa()
        {
            return EmpresaServices.Create(this.sqlBase, this.isolationLevel);
        }
        public FuncaoServices getFuncao()
        {
            return FuncaoServices.Create(this.sqlBase, this.isolationLevel);
        }
    }
}
