using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoOnlineUsuario.empresa.dominio.interfaces
{
    public interface ICaminhoArquivo
    {
        Int64 Id { get; set; }
        String CaminhoBaseImagem { get; set; }
        String CaminhoBaseDownload { get; set; }
        Guid EmpresaId { get; set; }
        IEmpresa IEmpresa { get; set; }
        String Status { get; set; }
    }
}
