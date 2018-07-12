using ServicoOnlineUsuario.empresa.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ServicoOnlineUsuario.empresa.dominio.entidade
{
    public class EmpresaUsuario : IEmpresaUsuario
    {
        protected EmpresaUsuario() { }
        internal static EmpresaUsuario Create()
        {
            return new EmpresaUsuario();
        }
        public virtual Guid EmpresaId { get ; set ; }
        public virtual Empresa Empresa { get; set; }
        [NotMapped]
        public IEmpresa IEmpresa { get ; set ; }
        public string UsuarioId { get ; set ; }
        public string Status { get ; set ; }
        public string Key { get ; set ; }
    }
}
