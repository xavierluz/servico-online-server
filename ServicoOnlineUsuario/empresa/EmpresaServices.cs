using Microsoft.EntityFrameworkCore;
using ServicoOnlineUsuario.bases;
using ServicoOnlineUsuario.bases.banco.interfaces;
using ServicoOnlineUsuario.empresa.configuracao;
using ServicoOnlineUsuario.empresa.contexto;
using ServicoOnlineUsuario.empresa.dominio.entidade;
using ServicoOnlineUsuario.empresa.dominio.interfaces;
using ServicoOnlineUsuario.empresa.repositorio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ServicoOnlineUsuario.empresa
{
    public class EmpresaServices: ServicesStrategy<IEmpresa>
    {
        private IEmpresa _Empresa = null;
        private DbContextOptionsBuilder<EmpresaContexto> optionsBuilder;
        protected IsolationLevel isolationLevel;
        private EmpresaRepositorio repositorio = null;

        private EmpresaServices(ISqlBase sqlBase, IsolationLevel isolationLevel){
            this.isolationLevel = isolationLevel;
            this.optionsBuilder = new DbContextOptionsBuilder<EmpresaContexto>();
            this.optionsBuilder.UseSqlServer(sqlBase.getConnection());

            this.repositorio = EmpresaRepositorio.Create(this.optionsBuilder.Options, isolationLevel);
        }
        internal static EmpresaServices Create(ISqlBase sqlBase, IsolationLevel isolationLevel)
        {
            return new EmpresaServices(sqlBase, isolationLevel);
        }

        internal async override Task<IEmpresa> Incluir(IEmpresa entidade)
        {
            this.repositorio.createTransacao();
            try
            {
                string cnn = this.repositorio.Contexto.Database.GetDbConnection().ConnectionString;
                Empresa empresa = ConverterEmpresa.converterIEmpresaParaEmpresa(entidade);

                this.repositorio.Adicionar(empresa);
                Task<int> registrosAfetados = this.repositorio.SalvarAsync();
                if (registrosAfetados.Result > 0)
                    this.repositorio.Commit();
                else
                    this.repositorio.Rollback();

                await registrosAfetados;
                _Empresa = ConverterEmpresa.converterEmpresaParaIEmpresa(empresa);
                return _Empresa;
            }
            catch (Exception ex)
            {
                this.repositorio.Rollback();
                throw ex;
            }
        }
    }
}
