using ServicoOnlineUsuario.empresa.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoOnlineServer.ViewModels
{
    public class EmpresaViewModel : IEmpresa
    {
        public EmpresaViewModel()
        {
            EmpresaUsuarioViewModels = new List<EmpresaUsuarioViewModel>();
            IEmpresaUsuarios = new List<IEmpresaUsuario>();
        }
        public Guid Id { get ; set ; }
        public string CnpjCpf { get ; set ; }
        public string Nome { get ; set ; }
        public string NomeFantasia { get ; set ; }
        public string Email { get ; set ; }
        public string Status { get ; set ; }
        public ICollection<IEmpresaUsuario> IEmpresaUsuarios { get ; set ; }
        public ICollection<EmpresaUsuarioViewModel> EmpresaUsuarioViewModels { get; set; }
        public ICaminhoArquivo ICaminhoArquivo { get ; set ; }
    }
}
