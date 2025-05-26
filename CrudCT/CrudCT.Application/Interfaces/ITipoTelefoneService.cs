using CrudCT.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCT.Application.Interfaces
{
    public interface ITipoTelefoneService
    {
        Task<bool> AdicionarTipoTelefoneAsync(TipoTelefoneDTO tipoTelefoneDTO);
        Task<bool> AtualizarTipoTelefoneAsync(TipoTelefoneDTO tipoTelefoneDTO);
        Task<bool> ExcluirTipoTelefoneAsync(int tipoTelefoneId);
        Task<TipoTelefoneDTO> ObterTipoTelefonePorIdAsync(int tipoTelefoneId);
        Task<IEnumerable<TipoTelefoneDTO>> ObterTiposTelefonesAsync();
    }
}
