using CrudCT.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCT.Application.Interfaces
{
    public interface ITelefoneService
    {
        Task<bool> AdicionarTelefoneAsync(TelefoneDTO telefoneDTO);
        Task<bool> AtualizarTelefoneAsync(TelefoneDTO telefoneDTO);
        Task<bool> ExcluirTelefoneAsync(int telefoneId);
        Task<TelefoneDTO> ObterTelefonePorIdAsync(int telefoneId);
        Task<IEnumerable<TelefoneDTO>> ObterTelefonesAsync();
        Task<IEnumerable<TelefoneDTO>> ObterTelefonesPorClienteIdAsync(int clienteId);
    }
}
