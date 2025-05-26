using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCT.Application.DTOs
{
    public class TipoTelefoneDTO
    {
        public int TipoTelefoneId { get; private set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MinLength(2)]
        [MaxLength(50)]
        public string DescricaoTipoTelefone { get; private set; }
    }
}
