using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicoOnlineBusiness.pagamento
{
    internal class NumeroDocumento
    {
        private string numeroDocumento = string.Empty;

        private NumeroDocumento(String nome,String telefone)
        {
            gerarNumeroDocumento(nome, telefone);
        }

        internal static NumeroDocumento Create(String nome, String telefone)
        {
            return new NumeroDocumento(nome, telefone);
        }

        internal string getNumeroDocumento()
        {
            return this.numeroDocumento;
        }
        private void gerarNumeroDocumento(String nome, String telefone)
        {
            string _nome = nome.Substring(0,3).Replace(" ","").ToUpper();
            string _telefone = telefone.Replace("-", "").Replace(".", "");
            string _data = DateTime.Now.ToShortDateString().Replace("/", "");
            string _hora = DateTime.Now.ToShortTimeString().Replace(":", "");
            string _caracterRandon = alfanumericoAleatorio(4);

            string _numero = string.Format("{0}{1}{2}{3}{4}", _nome, _telefone, _data, _hora, _caracterRandon);
            this.numeroDocumento = _numero;
        }

        private string alfanumericoAleatorio(int tamanho)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, tamanho)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
    }
}
