using CrudCT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCT.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> ObterClientes();
        Task<Cliente> ObterClientePorId(int id);
        Task<Cliente> ObterClientePorNome(string nome);
        Task<bool> AdicionarCliente(Cliente cliente);
        Task<bool> AtualizarCliente(Cliente cliente);
        Task<bool> ExcluirCliente(Cliente cliente);
    }
}
