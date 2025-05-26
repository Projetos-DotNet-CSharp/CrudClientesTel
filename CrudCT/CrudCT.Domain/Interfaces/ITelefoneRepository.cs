using CrudCT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCT.Domain.Interfaces
{
    public interface ITelefoneRepository
    {
        Task<IEnumerable<Telefone>> ObterTelefonesPorClienteId(int clienteId);
        Task<Telefone> ObterTelefonePorId(int id);
        Task<IEnumerable<Telefone>> ObterTelefones();
        Task<bool> AdicionarTelefone(Telefone telefone);
        Task<bool> AtualizarTelefone(Telefone telefone);
        Task<bool> ExcluirTelefone(Telefone telefone);
    }
}
