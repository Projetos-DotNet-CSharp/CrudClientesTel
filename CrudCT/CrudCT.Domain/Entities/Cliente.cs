using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCT.Domain.Entities
{
    public sealed class Cliente : PropComuns
    {
        public int ClienteId { get; private set; }
        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }
        public string TipoPessoa { get; private set; }
        public string Documento { get; private set; }
        public string Endereco { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string CEP { get; private set; }
        public string UF { get; private set; }
        public ICollection<Telefone> Telefones { get; set; }
    }
}
