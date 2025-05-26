using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCT.Domain.Entities
{
    public sealed class TipoTelefone : PropComuns
    {
        public int TipoTelefoneId { get; private set; }
        public string DescricaoTipoTelefone { get; private set; }
        public TipoTelefone(int tipoTelefoneId, string descricaoTipoTelefone)
        {
            TipoTelefoneId = tipoTelefoneId;
            DescricaoTipoTelefone = descricaoTipoTelefone;
            DataInsercao = DateTime.Now;
        }
    }
}
