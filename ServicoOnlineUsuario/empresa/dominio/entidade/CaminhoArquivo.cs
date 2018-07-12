using ServicoOnlineUsuario.empresa.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoOnlineUsuario.empresa.dominio.entidade
{
    public class CaminhoArquivo : ICaminhoArquivo
    {
        protected CaminhoArquivo() { }
        internal static CaminhoArquivo Create()
        {
            return new CaminhoArquivo();
        }
        public long Id { get; set; }
        public string CaminhoBaseImagem { get; set; }
        public string CaminhoBaseDownload { get; set; }
        public Guid EmpresaId { get; set; }
        public IEmpresa IEmpresa { get; set; }
        public string Status { get; set; }
    }
}
