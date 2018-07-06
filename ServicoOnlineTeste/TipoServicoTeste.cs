using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServicoOnlineBusiness.factory;
using ServicoOnlineBusiness.tiposervico.abstracts;
using ServicoOnlineBusiness.tiposervico.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ServicoOnlineTeste
{
    [TestClass]
    public class TipoServicoTeste
    {
        [TestMethod]
        public void Incluir()
        {
            IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted;

            ServicoFactory factory = ServicoFactory.Create(isolationLevel);
            var TipoServico = factory.getTipoServico();

            ITipoServicoDominio tipo = new TipoServicoViewModel();
            tipo.caminhoDaImage = "/teste/teste.jpg";
            tipo.Descricao = "Teste do celso";
            tipo.Nome = "Teste UNIT Inclusão";
            tipo.Status = "AT";
            Task<TipoServicoAbstract> retorno = TipoServico.Incluir(tipo);

        }
        [TestMethod]
        public void Alterar()
        {
            IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted;

            ServicoFactory factory = ServicoFactory.Create(isolationLevel);
            var TipoServico = factory.getTipoServico();

            ITipoServicoDominio tipo = new TipoServicoViewModel();
            tipo.Id = 9;
            tipo.caminhoDaImage = "/teste/teste.jpg";
            tipo.Descricao = "Teste do celso alteração";
            tipo.Nome = "Teste UNIT";
            tipo.Status = "AT";
            Task<TipoServicoAbstract> retorno = TipoServico.Alterar(tipo);


        }
    }
}
