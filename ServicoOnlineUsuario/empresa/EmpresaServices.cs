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
using System.Linq;
using System.Security.Cryptography;
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

        internal override async Task<IList<IEmpresa>> GetsAsync(int paginaIndex, string filtro, int registroPorPagina)
        {
            var connection = this.repositorio.Contexto.Database.GetDbConnection();
            if (connection.State == ConnectionState.Closed)
                this.repositorio.Contexto.Database.GetDbConnection().Open();


            if (paginaIndex < 0)
                paginaIndex = 0;
            if (!string.IsNullOrEmpty(filtro) &&
                   !string.IsNullOrWhiteSpace(filtro))
            {
                this.repositorio.createTransacao();
                IQueryable<Empresa> query = (from q in this.repositorio.Contexto.Set<Empresa>()
                                             where q.Status != "INA"
                                              && q.CnpjCpf.ToUpper().Contains(filtro.ToUpper())
                                              && q.Nome.ToUpper().Contains(filtro.ToUpper())
                                              && q.NomeFantasia.ToUpper().Contains(filtro.ToUpper())
                                              && q.Status.ToUpper().Contains(filtro.ToUpper())
                                             select q
                                            );
                _totalRegistro = repositorio.Set(query).Get().Count();

                query = (from q in this.repositorio.Contexto.Set<Empresa>()
                         where q.Status != "INA"
                          && q.CnpjCpf.ToUpper().Contains(filtro.ToUpper())
                          && q.Nome.ToUpper().Contains(filtro.ToUpper())
                          && q.NomeFantasia.ToUpper().Contains(filtro.ToUpper())
                          && q.Status.ToUpper().Contains(filtro.ToUpper())
                         select q
                        ).Skip(paginaIndex).Distinct();
            }
            else
            {
                this.repositorio.createTransacao();
                IQueryable<Empresa> query = (from q in this.repositorio.Contexto.Set<Empresa>()
                                             where q.Status != "INA"
                                             select q
                                            );
                _totalRegistro = repositorio.Set(query).Get().Count();

                query = (from q in this.repositorio.Contexto.Set<Empresa>()
                         where q.Status != "INA"
                         select q
                        ).Skip(paginaIndex).Distinct();
            }
            List<Empresa> empresas = await repositorio.Get().ToListAsync();

            IList<IEmpresa> IEmpresas = empresas.ConvertAll(new Converter<Empresa, IEmpresa>(ConverterEmpresa.converterEmpresaParaIEmpresa));
           
            return IEmpresas;
        }
        internal override IList<IEmpresa> Gets(int paginaIndex, string filtro, int registroPorPagina)
        {
            var connection = this.repositorio.Contexto.Database.GetDbConnection();
            if (connection.State == ConnectionState.Closed)
                this.repositorio.Contexto.Database.GetDbConnection().Open();

            this.repositorio.createTransacao();
            IQueryable<Empresa> query = null;

            if (paginaIndex < 0)
                paginaIndex = 0;
            if (!string.IsNullOrEmpty(filtro) &&
                   !string.IsNullOrWhiteSpace(filtro))
            {

                query = (from q in this.repositorio.Contexto.Set<Empresa>()
                                             where q.Status != "INA"
                                              &&( q.CnpjCpf.ToUpper().Contains(filtro.ToUpper())
                                              || q.Nome.ToUpper().Contains(filtro.ToUpper())
                                              || q.NomeFantasia.ToUpper().Contains(filtro.ToUpper())
                                              || q.Status.ToUpper().Contains(filtro.ToUpper()))
                                             select q
                                            );
                this._totalRegistro = repositorio.Set(query).Get().Count();

                query = (from q in this.repositorio.Contexto.Set<Empresa>()
                         where q.Status != "INA"
                          &&(q.CnpjCpf.ToUpper().Contains(filtro.ToUpper())
                          || q.Nome.ToUpper().Contains(filtro.ToUpper())
                          || q.NomeFantasia.ToUpper().Contains(filtro.ToUpper())
                          || q.Status.ToUpper().Contains(filtro.ToUpper()))
                         select q
                        ).Skip(paginaIndex).Take(registroPorPagina).Distinct();
            }
            else
            {
                query = (from q in this.repositorio.Contexto.Set<Empresa>()
                                             where q.Status != "INA"
                                             select q
                                            );
                this._totalRegistro = repositorio.Set(query).Get().Count();

                query = (from q in this.repositorio.Contexto.Set<Empresa>()
                         where q.Status != "INA"
                         select q
                        ).Skip(paginaIndex).Take(registroPorPagina).Distinct();
            }

            List<Empresa> empresas = repositorio.Set(query).Get().ToList();
            this.repositorio.Commit();
            IList<IEmpresa> IEmpresas = empresas.ConvertAll(new Converter<Empresa, IEmpresa>(ConverterEmpresa.converterEmpresaParaIEmpresa));

            return IEmpresas;
        }
        internal async override Task<IEmpresa> IncluirAsync(IEmpresa entidade)
        {
            this.repositorio.createTransacao();
            try
            {
                Empresa empresa = ConverterEmpresa.converterIEmpresaParaEmpresa(entidade);
 
                this.repositorio.Adicionar(empresa);
                Task<int> registrosAfetados = this.repositorio.SalvarAsync();
                if (registrosAfetados.Result > 0)
                {
                    ICaminhoArquivo caminhoArquivo = CaminhoArquivo.Create();
                    caminhoArquivo.CaminhoBaseImagem = empresa.Id.ToString().Replace("-","");
                    caminhoArquivo.CaminhoBaseDownload = string.Format("{0}/Download", empresa.Id.ToString().Replace("-", ""));
                    caminhoArquivo.EmpresaId = empresa.Id;
                    this.repositorio.Contexto.Set<CaminhoArquivo>().Add(ConverterEmpresa.converterICaminhoArquivoParaCaminhoArquivo(caminhoArquivo));
                    this.repositorio.Contexto.SaveChanges();
                    this.repositorio.Commit();
                }
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

        internal async override Task<string> createHashCodigo(String valorParaCriptografar)
        {
            if (string.IsNullOrWhiteSpace(valorParaCriptografar))
            {
                throw new ArgumentException("Valor está vazio", nameof(valorParaCriptografar));
            }

            string codigoCliente = string.Format("{0}:{1}", Guid.NewGuid().ToString(), DateTime.Now.ToLongDateString());
            String codigoCriptografado = string.Empty;
            await Task.Run(() => codigoCriptografado = Criptografia.Encrypt(codigoCliente));

            return codigoCriptografado;
        }

        internal override IEmpresa Incluir(IEmpresa entidade)
        {
            this.repositorio.createTransacao();
            try
            {
                string cnn = this.repositorio.Contexto.Database.GetDbConnection().ConnectionString;
                Empresa empresa = ConverterEmpresa.converterIEmpresaParaEmpresa(entidade);

                this.repositorio.Adicionar(empresa);
                int registrosAfetados = this.repositorio.Salvar();
                if (registrosAfetados > 0)
                {
                    ICaminhoArquivo caminhoArquivo = CaminhoArquivo.Create();
                    caminhoArquivo.CaminhoBaseImagem = empresa.Id.ToString().Replace("-", "");
                    caminhoArquivo.CaminhoBaseDownload = string.Format("{0}/Download", empresa.Id.ToString().Replace("-", ""));
                    caminhoArquivo.EmpresaId = empresa.Id;
                    
                    this.repositorio.Contexto.Set<CaminhoArquivo>().Add(ConverterEmpresa.converterICaminhoArquivoParaCaminhoArquivo(caminhoArquivo));
                    this.repositorio.Contexto.SaveChanges();
                    this.repositorio.Commit();
                }
                else
                    this.repositorio.Rollback();

                _Empresa = ConverterEmpresa.converterEmpresaParaIEmpresa(empresa);
                return _Empresa;
            }
            catch (Exception ex)
            {
                this.repositorio.Rollback();
                throw ex;
            }
        }

        internal override int getTotalDeRegistros()
        {
            return this._totalRegistro;
        }
    }
}
