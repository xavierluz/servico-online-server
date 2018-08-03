using Microsoft.AspNetCore.Identity;
using ServicoOnlineServer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoOnlineServer.usuario
{
    internal class UsuarioConfiguracao
    {
        internal static List<UsuarioTableViewModel> ordenacaoTableUsuario(int ordenacao, string ordenacaoAscDesc, IList<UsuarioTableViewModel> tableUsuario)
        {
            List<UsuarioTableViewModel> _tableUsuario = new List<UsuarioTableViewModel>();

            try
            {
                // Sorting
                switch (ordenacao)
                {
                    case 0:
                        _tableUsuario = ordenacaoAscDesc.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? tableUsuario.OrderByDescending(p => p.UserName).ToList() : tableUsuario.OrderBy(p => p.UserName).ToList();
                        break;
                    case 1:
                        _tableUsuario = ordenacaoAscDesc.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? tableUsuario.OrderByDescending(p => p.Email).ToList() : tableUsuario.OrderBy(p => p.Email).ToList();
                        break;
                    case 2:
                        _tableUsuario = ordenacaoAscDesc.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? tableUsuario.OrderByDescending(p => p.PhoneNumber).ToList() : tableUsuario.OrderBy(p => p.PhoneNumber).ToList();
                        break;
                    case 3:
                        _tableUsuario = ordenacaoAscDesc.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? tableUsuario.OrderByDescending(p => p.TwoFactorEnabled).ToList() : tableUsuario.OrderBy(p => p.TwoFactorEnabled).ToList();
                        break;

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return _tableUsuario;
        }
        internal static List<RequisicaoTableViewModel> ordenacaoTableUsuarioRequisicoes(int ordenacao, string ordenacaoAscDesc, IList<RequisicaoTableViewModel> tableUsuarioRequisicao)
        {
            List<RequisicaoTableViewModel> _tableUsuarioRequisicoes = new List<RequisicaoTableViewModel>();

            try
            {
                // Sorting
                switch (ordenacao)
                {
                    case 0:
                        _tableUsuarioRequisicoes = ordenacaoAscDesc.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? tableUsuarioRequisicao.OrderByDescending(p => p.Type).ToList() : tableUsuarioRequisicao.OrderBy(p => p.Type).ToList();
                        break;
                    case 1:
                        _tableUsuarioRequisicoes = ordenacaoAscDesc.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? tableUsuarioRequisicao.OrderByDescending(p => p.ValueType).ToList() : tableUsuarioRequisicao.OrderBy(p => p.ValueType).ToList();
                        break;
                    case 2:
                        _tableUsuarioRequisicoes = ordenacaoAscDesc.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? tableUsuarioRequisicao.OrderByDescending(p => p.Value).ToList() : tableUsuarioRequisicao.OrderBy(p => p.Value).ToList();
                        break;

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return _tableUsuarioRequisicoes;
        }
    }
}
