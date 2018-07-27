using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoOnlineServer.ViewModels
{
    public class EmpresaTableViewModel
    {
        public String Id { get; set; }
        public String CnpjCpf { get; set; }
        public String Nome { get; set; }
        public String NomeFantasia { get; set; }
        public String Email { get; set; }
        public String Status { get; set; }
    }
}
