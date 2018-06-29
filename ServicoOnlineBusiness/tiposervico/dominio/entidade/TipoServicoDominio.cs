using ServicoOnlineBusiness.tiposervico.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoOnlineBusiness.tiposervico.dominio.entidade
{
    public class TipoServicoDominio : ITipoServicoDominio
    {
        protected TipoServicoDominio()
        {

        }
        public static TipoServicoDominio Create()
        {
            return new TipoServicoDominio();
        }
        public int Id { get; set ; }
        public string Nome { get; set; }
        public string Descricao { get; set ; }
        public string caminhoDaImage { get ; set ; }
        public string Status { get ; set ; }
    }
}
