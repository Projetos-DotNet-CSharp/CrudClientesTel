using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCT.Domain.Entities
{
    public sealed class Telefone : PropComuns
    {
        public int TelefoneId { get; private set; }
        public string NumeroTelefone { get; private set; }
        public int TipoTelefoneId { get; private set; }
        public TipoTelefone TipoTelefone { get; private set; }
        public string Operadora { get; private set; }
        public bool Ativo { get; private set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
