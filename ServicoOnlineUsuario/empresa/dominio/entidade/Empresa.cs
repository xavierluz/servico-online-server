using ServicoOnlineUsuario.empresa.dominio.interfaces;
using ServicoOnlineUsuario.usuario.dominio.entidade;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ServicoOnlineUsuario.empresa.dominio.entidade
{
    public class Empresa : IEmpresa
    {
        protected Empresa() {
            this.IEmpresaUsuarios = new List<IEmpresaUsuario>();
        }
        internal static Empresa Create()
        {
            return new Empresa();
        }
        public Guid Id { get ; set ; }
        public string CnpjCpf { get ; set ; }
        public string Nome { get ; set ; }
        public string NomeFantasia { get ; set ; }
        public string Email { get ; set ; }
        public string Status { get ; set ; }
        [NotMapped]
        public ICollection<IEmpresaUsuario> IEmpresaUsuarios { get; set; }
        public virtual ICollection<EmpresaUsuario> EmpresaUsuarios { get; set; }
    }
}
