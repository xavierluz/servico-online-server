using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoOnlineServer.ViewModels
{
    public class RequisicaoTableViewModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string ValueType { get; set; }
        public string Value { get; set; }
    }
}
