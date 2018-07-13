using ServicoOnlineUsuario.bases;
using ServicoOnlineUsuario.usuario.dominio.entidade;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicoOnlineUsuario.usuario
{
    public class UsuarioServices : ServicesStrategy<Usuario>
    {
        private UsuarioServices() { }
        internal static UsuarioServices Create()
        {
            return new UsuarioServices();
        }
        internal override Task<Usuario> Incluir(Usuario entidade)
        {
            throw new NotImplementedException();
        }
    }
}
