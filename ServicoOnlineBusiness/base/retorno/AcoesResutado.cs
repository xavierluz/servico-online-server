using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoOnlineBusiness.bases.retorno
{
    public class AcoesResutado
    {
        public AcoesResutado() {
            Succeeded = true;
        }

        public static AcoesResutado Success { get; }
       
        public bool Succeeded { get; protected set; }
        
        public IEnumerable<Exception> Errors { get; private set; }

        public AcoesResutado Falhou(params Exception[] errors)
        {
            Succeeded = false;
            var resultado = new AcoesResutado();
            IList<Exception> exceptions = new List<Exception>();
            
            foreach (var ex in errors)
            {
                exceptions.Add(ex);
            }
            resultado.Errors = exceptions;

            return resultado;
        }
       
        public override string ToString()
        {
            return this.Errors.ToString();
        }
    }
}
