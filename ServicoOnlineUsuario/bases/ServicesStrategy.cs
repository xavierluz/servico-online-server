using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicoOnlineUsuario.bases
{
    public abstract class ServicesStrategy<T>
    {
        internal abstract Task<T> Incluir(T entidade);
    }
}
