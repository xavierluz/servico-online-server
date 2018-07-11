using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using ServicoOnlineBusiness.servico.dominio.interfaces;
using ServicoOnlineBusiness.tiposervico.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoOnlineServer.ViewModels
{
    public class TipoServicoDominioViewModel : ITipoServicoDominio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string caminhoDaImage { get; set; }
        public string Status { get; set; }
        public FormFile Imagem { get; set; }
        public byte[] Imagens { get; set; }
        public ICollection<IServicoDominio> IServicoDominios { get; set; }
    }
}
