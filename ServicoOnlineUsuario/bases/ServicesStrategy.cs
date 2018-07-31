using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicoOnlineUsuario.bases
{
    public abstract class ServicesStrategy<T>
    {
        protected int _totalRegistro = 0;
        internal abstract Task<T> IncluirAsync(T entidade);
        internal abstract Task<string> createHashCodigo(String valorParaCriptografar);
        internal abstract T Incluir(T entidade);
        internal abstract Task<IList<T>> GetsAsync(int paginaIndex, string filtro, int registroPorPagina);
        internal abstract IList<T> Gets(int paginaIndex, string filtro, int registroPorPagina);
        internal abstract int getTotalDeRegistros();
    }
}
