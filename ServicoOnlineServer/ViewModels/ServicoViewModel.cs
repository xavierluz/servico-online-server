using ServicoOnlineBusiness.pagamento.dominio.interfaces;
using ServicoOnlineBusiness.servico.dominio.interfaces;
using ServicoOnlineBusiness.tiposervico.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoOnlineServer.ViewModels
{
    public class ServicoViewModel : IServicoDominio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Indicacao { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string Status { get; set; }
        public string TipoServicoNome { get; set; }
        public string TipoServicoCaminhoDaImage { get; set; }
        public ITipoServicoDominio ITipoServico { get; set; }
        public int tipoServicoDominioId { get; set; }
        public ICollection<IPagamentoItemDominio> IPagamentoItemDominios { get; set; }
    }
}
