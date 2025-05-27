using CrudCT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CrudCT.Application.DTOs
{
    public class TelefoneDTO
    {
        public int TelefoneId { get; private set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(15)]
        public string NumeroTelefone { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MinLength(1)]
        public int TipoTelefoneId { get; set; }

        [JsonIgnore]
        public TipoTelefone TipoTelefone { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(50)]
        public string Operadora { get; set; }

        public bool Ativo { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public int ClienteId { get; set; }

        [JsonIgnore]
        public Cliente Cliente { get; set; }
    }
}
