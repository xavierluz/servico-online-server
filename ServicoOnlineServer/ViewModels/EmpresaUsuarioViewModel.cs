using ServicoOnlineUsuario.empresa.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoOnlineServer.ViewModels
{
    public class EmpresaUsuarioViewModel : IEmpresaUsuario
    {
        public Guid EmpresaId { get; set; }
        public IEmpresa IEmpresa { get; set; }
        public string UsuarioId { get; set; }
        public string Status { get; set; }
        public string Key { get; set; }
    }
}
