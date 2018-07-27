using ServicoOnlineUsuario.empresa.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoOnlineServer.ViewModels
{
    public class CaminhoArquivoViewModel : ICaminhoArquivo
    {
        public long Id { get; set; }
        public string CaminhoBaseImagem { get; set; }
        public string CaminhoBaseDownload { get; set; }
        public Guid EmpresaId { get; set; }
        public IEmpresa IEmpresa { get; set; }
        public string Status { get; set; }
    }
}
