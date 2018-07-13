using ServicoOnlineUsuario.empresa.dominio.entidade;
using ServicoOnlineUsuario.empresa.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicoOnlineUsuario.empresa.configuracao
{
    internal static class ConverterEmpresa
    {
        internal static Empresa converterIEmpresaParaEmpresa(IEmpresa empresa)
        {
            Empresa _empresa = null;
            if(empresa != null)
            {
                _empresa = Empresa.Create();
                _empresa.CnpjCpf = empresa.CnpjCpf;
                _empresa.Email = empresa.Email;
                _empresa.Id = empresa.Id;
                _empresa.Nome = empresa.Nome;
                _empresa.NomeFantasia = empresa.NomeFantasia;
                _empresa.Status = empresa.Status;
                _empresa.EmpresaUsuarios = empresa.IEmpresaUsuarios.ToList().ConvertAll(new Converter<IEmpresaUsuario, EmpresaUsuario>(converterIEmpresaUsuarioParaEmpresaUsuario));

            }

            return _empresa;
        }
        private static EmpresaUsuario converterIEmpresaUsuarioParaEmpresaUsuario(IEmpresaUsuario empresaUsuario)
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

        internal static IEmpresa converterEmpresaParaIEmpresa(Empresa empresa)
        {
            IEmpresa _empresa = null;
            if (empresa != null)
            {
                _empresa = Empresa.Create();
                _empresa.CnpjCpf = empresa.CnpjCpf;
                _empresa.Email = empresa.Email;
                _empresa.Id = empresa.Id;
                _empresa.Nome = empresa.Nome;
                _empresa.NomeFantasia = empresa.NomeFantasia;
                _empresa.Status = empresa.Status;
                _empresa.IEmpresaUsuarios = empresa.EmpresaUsuarios.ToList().ConvertAll(new Converter<EmpresaUsuario, IEmpresaUsuario>(converterEmpresaUsuarioParaIEmpresaUsuario));

            }

            return _empresa;
        }
        private static IEmpresaUsuario converterEmpresaUsuarioParaIEmpresaUsuario(EmpresaUsuario empresaUsuario)
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
