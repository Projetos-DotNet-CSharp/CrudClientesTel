using CrudCT.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCT.Application.Interfaces
{
    public interface IClienteService
    {
        Task<bool> AdicionarClienteAsync(ClienteDTO clienteDTO);
        Task<bool> AtualizarClienteAsync(ClienteDTO clienteDTO);
        Task<bool> ExcluirClienteAsync(int clienteId);
        Task<ClienteDTO> ObterClientePorIdAsync(int clienteId);
        Task<IEnumerable<ClienteDTO>> ObterClientesAsync();
        //Task<IEnumerable<TelefoneDTO>> ObterTelefonesPorClienteIdAsync(int clienteId);
        //Task<bool> AdicionarTelefoneAsync(TelefoneDTO telefoneDTO);
        //Task<bool> AtualizarTelefoneAsync(TelefoneDTO telefoneDTO);
        //Task<bool> ExcluirTelefoneAsync(int telefoneId);
    }
}
