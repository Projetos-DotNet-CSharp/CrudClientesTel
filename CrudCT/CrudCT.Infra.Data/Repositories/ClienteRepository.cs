using CrudCT.Domain.Entities;
using CrudCT.Domain.Interfaces;
using CrudCT.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCT.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private ApplicationDbContext _clienteContext;

        public ClienteRepository(ApplicationDbContext context)
        {
            _clienteContext = context;
        }

        public async Task<bool> AdicionarCliente(Cliente cliente)
        {
            _clienteContext.Add(cliente);
            int resultado = await _clienteContext.SaveChangesAsync();
            return resultado > 0;
        }

        public async Task<bool> AtualizarCliente(Cliente cliente)
        {
            _clienteContext.Update(cliente);
            int resultado = await _clienteContext.SaveChangesAsync();
            return resultado > 0;
        }

        public async Task<bool> ExcluirCliente(Cliente cliente)
        {
            _clienteContext.Remove(cliente);
            int resultado = await _clienteContext.SaveChangesAsync();
            return resultado > 0;
        }

        public async Task<Cliente> ObterClientePorId(int id)
        {
            var cliente = await _clienteContext.Clientes.Include(t => t.Telefones)
                                               .SingleOrDefaultAsync(c => c.ClienteId == id);
            return cliente;
        }

        public async Task<Cliente> ObterClientePorNome(string nomeFantasia)
        {
            var cliente = await _clienteContext.Clientes.Include(t => t.Telefones)
                                               .SingleOrDefaultAsync(c => c.NomeFantasia == nomeFantasia);
            return cliente;
        }

        public async Task<IEnumerable<Cliente>> ObterClientes()
        {
            var clientes = await _clienteContext.Clientes.Include(t => t.Telefones)
                                                .ToListAsync();
            return clientes;
        }
    }
}
