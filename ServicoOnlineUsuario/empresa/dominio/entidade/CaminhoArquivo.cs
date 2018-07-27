using ServicoOnlineUsuario.empresa.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [NotMapped]
        public IEmpresa IEmpresa { get; set; }
        public virtual Empresa Empresa { get; set; }
        public string Status { get; set; }
    }
}
