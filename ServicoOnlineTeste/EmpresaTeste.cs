using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServicoOnlineUsuario;
using ServicoOnlineUsuario.empresa.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServicoOnlineTeste
{
    [TestClass]
    public class EmpresaTeste
    {
        [TestMethod]
        public void CreateTeste()
        {
            IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted;

            Services<IEmpresa> services = Services<IEmpresa>.Create(FactoryServices.Create(isolationLevel).getEmpresa());
            IEmpresa empresa = new EmpresaViewModel();
            empresa.CnpjCpf = "5475778787";
            empresa.Email = "xavierluz@gmail.com";
            empresa.Nome = "Teste";
            empresa.NomeFantasia = "Teste";
            empresa.Status = "AT";

           services.IncluirAsync(empresa);
        }
        [TestMethod]
        public void CreateHash()
        {
            IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted;

            Services<IEmpresa> services = Services<IEmpresa>.Create(FactoryServices.Create(isolationLevel).getEmpresa());

           string codigoHash = services.createHashCodigo("bhhhghghggh").Result;

           

        }
    }
}
