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

        private Services(ServicesStrategy<T> strategy)
        {
            this._strategy = strategy;
        }
        public static Services<T> Create(ServicesStrategy<T> strategy)
        {
            return new Services<T>(strategy);
        }

        public Task<T> Incluir(T entidade)
        {
            return this._strategy.Incluir(entidade);
        }
    }
}

