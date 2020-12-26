using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almeida.Core.Entities
{
    public class Cliente : Base
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string CPF { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public int Num { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Email { get; set; }
    }
}
