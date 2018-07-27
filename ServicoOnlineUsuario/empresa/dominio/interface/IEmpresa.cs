using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoOnlineUsuario.empresa.dominio.interfaces
{
    public interface IEmpresa
    {
        Guid Id { get; set; }
        String CnpjCpf { get; set; }
        String Nome { get; set; }
        String NomeFantasia { get; set; }
        String Email { get; set; }
        String Status { get; set; }
        ICaminhoArquivo ICaminhoArquivo { get; set; }
        ICollection<IEmpresaUsuario> IEmpresaUsuarios { get; set; }
    }
}
