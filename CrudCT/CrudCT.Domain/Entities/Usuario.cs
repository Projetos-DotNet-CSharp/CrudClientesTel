using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCT.Domain.Entities
{
    public sealed class Usuario
    {
        public int UsuarioId { get; private set; }
        public string Nome { get; private set; }
    }
}
