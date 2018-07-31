using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ServicoOnlineServer.ViewModels
{
    public class ClaimViewModel
    {
        public string FuncaoId { get; set; }
        public string Type { get; set; }
        public ClaimsIdentity Subject { get; set; }
        public string OriginalIssuer { get; set; }
        public string Issuer { get; set; }
        public string ValueType { get; set; }
        public string Value { get; set; }
        public IDictionary<string, string> Properties { get; set; }
        protected virtual byte[] CustomSerializationData { get; set; }
        public EmpresaUsuarioFuncaoViewModel EmpresaUsuario { get; set; }
        public Claim toClaim()
        {
            Claim claim = new Claim(this.Type, this.Value, this.ValueType);
            return claim;
        }
    }
}
