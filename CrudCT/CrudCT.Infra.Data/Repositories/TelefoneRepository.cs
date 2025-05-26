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
    public class TelefoneRepository : ITelefoneRepository
    {
        private ApplicationDbContext _telefoneContext;

        public TelefoneRepository(ApplicationDbContext context)
        {
            _telefoneContext = context;
        }

        public async Task<bool> AdicionarTelefone(Telefone telefone)
        {
            _telefoneContext.Add(telefone);
            int resultado = await _telefoneContext.SaveChangesAsync();
            return resultado > 0;
        }

        public async Task<bool> AtualizarTelefone(Telefone telefone)
        {
            _telefoneContext.Update(telefone);
            int resultado = await _telefoneContext.SaveChangesAsync();
            return resultado > 0;
        }

        public async Task<bool> ExcluirTelefone(Telefone telefone)
        {
            _telefoneContext.Remove(telefone);
            int resultado = await _telefoneContext.SaveChangesAsync();
            return resultado > 0;
        }

        public async Task<Telefone> ObterTelefonePorId(int id)
        {
            var telefone = await _telefoneContext.Telefones.Include(ttel => ttel.TipoTelefone)
                                                           .SingleOrDefaultAsync(t => t.TelefoneId == id);
            return telefone;
        }

        public async Task<IEnumerable<Telefone>> ObterTelefonesPorClienteId(int clienteId)
        {
            var telefones = await _telefoneContext.Telefones.Include(ttel => ttel.TipoTelefone)
                                                            .Include(c => c.Cliente)
                                                            .Where(t => t.Cliente.ClienteId == clienteId)
                                                            .ToListAsync();
            return telefones;
        }

        public async Task<IEnumerable<Telefone>> ObterTelefones()
        {
            var telefones = await _telefoneContext.Telefones.Include(ttel => ttel.TipoTelefone)
                                                            .Include(c => c.Cliente)
                                                            .ToListAsync();
            return telefones;
        }
    }
}
