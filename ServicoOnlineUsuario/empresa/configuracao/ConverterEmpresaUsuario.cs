using ServicoOnlineUsuario.empresa.dominio.entidade;
using ServicoOnlineUsuario.empresa.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoOnlineUsuario.empresa.configuracao
{
    internal static class ConverterEmpresaUsuario
    {
        internal static EmpresaUsuario converterIEmpresaUsuarioParaEmpresaUsuario(IEmpresaUsuario empresaUsuario)
        {
            EmpresaUsuario _empresaUsuario = null;
            if(empresaUsuario != null)
            {
                _empresaUsuario = EmpresaUsuario.Create();
                _empresaUsuario.EmpresaId = empresaUsuario.EmpresaId;
                _empresaUsuario.Key = empresaUsuario.Key;
                _empresaUsuario.Status = empresaUsuario.Status;
                _empresaUsuario.UsuarioId = empresaUsuario.UsuarioId;
            }

            return _empresaUsuario;
        }
        internal static IEmpresaUsuario converterEmpresaUsuarioParaIEmpresaUsuario(EmpresaUsuario empresaUsuario)
        {
            IEmpresaUsuario _empresaUsuario = null;
            if (empresaUsuario != null)
            {
                _empresaUsuario = EmpresaUsuario.Create();
                _empresaUsuario.EmpresaId = empresaUsuario.EmpresaId;
                _empresaUsuario.Key = empresaUsuario.Key;
                _empresaUsuario.Status = empresaUsuario.Status;
                _empresaUsuario.UsuarioId = empresaUsuario.UsuarioId;
            }

            return _empresaUsuario;
        }
    }
}
