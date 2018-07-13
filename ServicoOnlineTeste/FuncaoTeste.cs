using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServicoOnlineUsuario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ServicoOnlineTeste
{
    [TestClass]
    public class FuncaoTeste
    {
        [TestMethod]
        public void CreateTeste()
        {
            IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted;

            Services<IdentityRole> services = Services<IdentityRole>.Create(FactoryServices.Create(isolationLevel).getFuncao());
            IdentityRole funcao = new IdentityRole();
            funcao.Id = Guid.NewGuid().ToString();
            funcao.ConcurrencyStamp = DateTimeOffset.Now.TimeOfDay.ToString();
            funcao.Name = "Operador do sistema";
            funcao.NormalizedName = "OperadorSistema";


           Task< IdentityRole> retorno =  services.Incluir(funcao);
        }
    }
}
