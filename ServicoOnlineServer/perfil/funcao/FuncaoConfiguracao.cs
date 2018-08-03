using Microsoft.AspNetCore.Identity;
using ServicoOnlineServer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoOnlineServer.perfil.funcao
{
    internal class FuncaoConfiguracao
    {
        internal static List<IdentityRole> ordenacaoTableFuncoes(int ordenacao, string ordenacaoAscDesc, IList<IdentityRole> tableFuncao)
        {
            List<IdentityRole> _tableFuncao = new List<IdentityRole>();

            try
            {
                // Sorting
                switch (ordenacao)
                {
                    case 0:
                        _tableFuncao = ordenacaoAscDesc.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? tableFuncao.OrderByDescending(p => p.Name).ToList() : tableFuncao.OrderBy(p => p.Name).ToList();
                        break;
                    case 1:
                        _tableFuncao = ordenacaoAscDesc.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? tableFuncao.OrderByDescending(p => p.NormalizedName).ToList() : tableFuncao.OrderBy(p => p.NormalizedName).ToList();
                        break;
                    case 2:
                        _tableFuncao = ordenacaoAscDesc.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? tableFuncao.OrderByDescending(p => p.ConcurrencyStamp).ToList() : tableFuncao.OrderBy(p => p.ConcurrencyStamp).ToList();
                        break;

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return _tableFuncao;
        }
        internal static List<RequisicaoTableViewModel> ordenacaoTableFuncoesRequisicoes(int ordenacao, string ordenacaoAscDesc, IList<RequisicaoTableViewModel> tableFuncaoRequisicao)
        {
            List<RequisicaoTableViewModel> _tableFuncaoRequisicoes = new List<RequisicaoTableViewModel>();

            try
            {
                // Sorting
                switch (ordenacao)
                {
                    case 0:
                        _tableFuncaoRequisicoes = ordenacaoAscDesc.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? tableFuncaoRequisicao.OrderByDescending(p => p.Type).ToList() : tableFuncaoRequisicao.OrderBy(p => p.Type).ToList();
                        break;
                    case 1:
                        _tableFuncaoRequisicoes = ordenacaoAscDesc.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? tableFuncaoRequisicao.OrderByDescending(p => p.ValueType).ToList() : tableFuncaoRequisicao.OrderBy(p => p.ValueType).ToList();
                        break;
                    case 2:
                        _tableFuncaoRequisicoes = ordenacaoAscDesc.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? tableFuncaoRequisicao.OrderByDescending(p => p.Value).ToList() : tableFuncaoRequisicao.OrderBy(p => p.Value).ToList();
                        break;

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return _tableFuncaoRequisicoes;
        }
    }
}
