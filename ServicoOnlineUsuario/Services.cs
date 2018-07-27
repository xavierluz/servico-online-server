using ServicoOnlineUsuario.bases;
using ServicoOnlineUsuario.empresa;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicoOnlineUsuario
{
    public class Services<T>
    {
        private ServicesStrategy<T> _strategy = null;
        public int totalDeRegistros { get; private set; }

        private Services(ServicesStrategy<T> strategy)
        {
            this._strategy = strategy;
        }
        public static Services<T> Create(ServicesStrategy<T> strategy)
        {
            return new Services<T>(strategy);
        }

        public Task<T> IncluirAsync(T entidade)
        {
            return this._strategy.IncluirAsync(entidade);
        }
        public T Incluir(T entidade)
        {
            return this._strategy.Incluir(entidade);
        }
        public Task<IList<T>> GetsAsync(int paginaIndex, string filtro, int registroPorPagina)
        {
            return this._strategy.GetsAsync(paginaIndex,filtro,registroPorPagina);
        }
        public IList<T> Gets(int paginaIndex, string filtro, int registroPorPagina)
        {
            IList<T> retorno = this._strategy.Gets(paginaIndex, filtro, registroPorPagina);
            this.totalDeRegistros = this._strategy.getTotalDeRegistros();
            return retorno;
        }
        public Task<string> createHashCodigo()
        {
            return this._strategy.createHashCodigo();
        }
    }
}

