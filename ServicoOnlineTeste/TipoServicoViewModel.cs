using System.Collections.Generic;
using ServicoOnlineBusiness.servico.dominio.interfaces;
using ServicoOnlineBusiness.tiposervico.dominio.interfaces;

namespace ServicoOnlineTeste
{
    internal class TipoServicoViewModel : ITipoServicoDominio
    {
        public int Id { get; set ; }
        public string Nome { get ; set ; }
        public string Descricao { get ; set ; }
        public string caminhoDaImage { get ; set ; }
        public string Status { get ; set ; }
        public ICollection<IServicoDominio> IServicoDominios { get ; set ; }
    }
}