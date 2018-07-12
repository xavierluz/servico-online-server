using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoOnlineUsuario.empresa.dominio.interfaces
{
    public interface IEmpresaUsuario
    {
        Guid EmpresaId { get; set; }
        IEmpresa IEmpresa { get; set; }
        String UsuarioId { get; set; }
        String Status { get; set; }
        String Key { get; set; }
    }
}
