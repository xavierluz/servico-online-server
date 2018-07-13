using System;
using System.Collections.Generic;
using ServicoOnlineUsuario.empresa.dominio.interfaces;

namespace ServicoOnlineTeste
{
    internal class EmpresaViewModel : IEmpresa
    {
        public EmpresaViewModel()
        {
            IEmpresaUsuarios = new List<IEmpresaUsuario>();
        }
        public Guid Id { get; set; }
        public string CnpjCpf { get; set; }
        public string Nome { get; set; }
        public string NomeFantasia { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public ICollection<IEmpresaUsuario> IEmpresaUsuarios { get; set; }
    }
}