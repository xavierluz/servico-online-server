using ServicoOnlineBusiness.tiposervico.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoOnlineBusiness.servico.dominio.interfaces
{
    public interface IServicoDominio
    {
        Int32 Id { get; set; }
        String Nome { get; set; }
        String Indicacao { get; set; }
        String Descricao { get; set; }
        Decimal Preco { get; set; }
        String Status { get; set; }
        ITipoServicoDominio ITipoServico { get; set; }
        Int32 tipoServicoDominioId { get; set; }

    }
}
