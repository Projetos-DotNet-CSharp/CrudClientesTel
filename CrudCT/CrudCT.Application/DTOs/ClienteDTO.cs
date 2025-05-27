using CrudCT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCT.Application.DTOs
{
    public class ClienteDTO
    {
        public int ClienteId { get; private set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MinLength(2)]
        [MaxLength(100)]
        public string RazaoSocial { get; private set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MinLength(2)]
        [MaxLength(100)]
        public string NomeFantasia { get; private set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(1, MinimumLength = 1)]
        public string TipoPessoa { get; private set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MinLength(2)]
        [MaxLength(14)]
        public string Documento { get; private set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MinLength(2)]
        [MaxLength(100)]
        public string Endereco { get; private set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MinLength(2)]
        [MaxLength(100)]
        public string Complemento { get; private set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MinLength(2)]
        [MaxLength(100)]
        public string Bairro { get; private set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MinLength(2)]
        [MaxLength(100)]
        public string Cidade { get; private set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(2, MinimumLength = 2)]
        public string UF { get; private set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(8, MinimumLength = 8)]
        public string CEP { get; private set; }

        public ICollection<TelefoneDTO> Telefones { get; set; }
    }
}
