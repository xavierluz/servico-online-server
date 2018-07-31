using Microsoft.EntityFrameworkCore;
using ServicoOnlineUsuario.bases;
using ServicoOnlineUsuario.bases.banco.interfaces;
using ServicoOnlineUsuario.empresa.configuracao;
using ServicoOnlineUsuario.empresa.contexto;
using ServicoOnlineUsuario.empresa.dominio.entidade;
using ServicoOnlineUsuario.empresa.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ServicoOnlineUsuario.empresa
{
    public class EmpresaUsuarioServices : ServicesStrategy<IEmpresaUsuario>
    {
        private IEmpresaUsuario _EmpresaUsuario = null;
        private DbContextOptionsBuilder<EmpresaContexto> optionsBuilder;
        protected EmpresaContexto contexto = null;

        protected IsolationLevel isolationLevel;


        private EmpresaUsuarioServices(ISqlBase sqlBase, IsolationLevel isolationLevel)
        {
            this.isolationLevel = isolationLevel;
            this.optionsBuilder = new DbContextOptionsBuilder<EmpresaContexto>();
            this.optionsBuilder.UseSqlServer(sqlBase.getConnection());

        }
        internal static EmpresaUsuarioServices Create(ISqlBase sqlBase, IsolationLevel isolationLevel)
        {
            return new EmpresaUsuarioServices(sqlBase, isolationLevel);
        }

        internal async override Task<string> createHashCodigo(String valorParaCriptografar)
        {
            if (string.IsNullOrWhiteSpace(valorParaCriptografar))
            {
                throw new ArgumentException("Valor está vazio", nameof(valorParaCriptografar));
            }
            String codigoCriptografado = string.Empty;
            await Task.Run(() => codigoCriptografado = Criptografia.Encrypt(valorParaCriptografar));

            return codigoCriptografado;
        }

        internal override IList<IEmpresaUsuario> Gets(int paginaIndex, string filtro, int registroPorPagina)
        {
            throw new NotImplementedException();
        }

        internal override Task<IList<IEmpresaUsuario>> GetsAsync(int paginaIndex, string filtro, int registroPorPagina)
        {
            throw new NotImplementedException();
        }

        internal override int getTotalDeRegistros()
        {
            throw new NotImplementedException();
        }

        internal override IEmpresaUsuario Incluir(IEmpresaUsuario entidade)
        {
            
            throw new NotImplementedException();
        }

        internal async override Task<IEmpresaUsuario> IncluirAsync(IEmpresaUsuario entidade)
        {
            contexto = EmpresaContexto.Create(this.optionsBuilder.Options);
            EmpresaUsuario empresaUsuario = ConverterEmpresaUsuario.converterIEmpresaUsuarioParaEmpresaUsuario(entidade);

            await contexto.EmpresasUsuarios.AddAsync(empresaUsuario);
            await contexto.SaveChangesAsync();
            return ConverterEmpresaUsuario.converterEmpresaUsuarioParaIEmpresaUsuario(empresaUsuario);
        }
    }
}
