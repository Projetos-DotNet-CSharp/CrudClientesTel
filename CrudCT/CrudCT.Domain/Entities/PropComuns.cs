using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCT.Domain.Entities
{
    public abstract class PropComuns
    {
        //public int Id { get; protected set; }
        public DateTime DataInsercao { get; protected set; }
        public int UsuarioId { get; protected set; }
    }
}
