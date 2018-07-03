using ServicoOnlineBusiness.servico.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoOnlineBusiness.tiposervico.dominio.interfaces
{
    public interface ITipoServicoDominio
    {
        Int32 Id { get; set; }
        String Nome { get; set; }
        String Descricao { get; set; }
        String caminhoDaImage { get; set; }
        String Status { get; set; }
        ICollection<IServicoDominio> IServicoDominios { get; set; }
    }
}
