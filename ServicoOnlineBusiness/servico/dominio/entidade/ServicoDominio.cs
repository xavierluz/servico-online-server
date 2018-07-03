using ServicoOnlineBusiness.servico.dominio.interfaces;
using ServicoOnlineBusiness.tiposervico.dominio.entidade;
using ServicoOnlineBusiness.tiposervico.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ServicoOnlineBusiness.servico.dominio.entidade
{
    public class ServicoDominio : IServicoDominio
    {
        protected ServicoDominio() { }

        internal static ServicoDominio Create()
        {
            return new ServicoDominio();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Indicacao { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        [NotMapped]
        public ITipoServicoDominio ITipoServico { get; set; }
        public virtual int tipoServicoDominioId { get; set; }
        public virtual TipoServicoDominio tipoServicoDominio { get; set; }
        public string Status { get; set ; }
    }
}
