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
    public class TipoTelefoneRepository : ITipoTelefoneRepository
    {
        private ApplicationDbContext _tipoTelefoneContext;

        public TipoTelefoneRepository(ApplicationDbContext tipoTelefoneContext)
        {
            _tipoTelefoneContext = tipoTelefoneContext;
        }

        public async Task<bool> AdicionarTipoTelefone(TipoTelefone tipoTelefone)
        {
            _tipoTelefoneContext.Add(tipoTelefone);
            int resultado = await _tipoTelefoneContext.SaveChangesAsync();
            return resultado > 0;
        }

        public async Task<bool> AtualizarTipoTelefone(TipoTelefone tipoTelefone)
        {
            _tipoTelefoneContext.Update(tipoTelefone);
            int resultado = await _tipoTelefoneContext.SaveChangesAsync();
            return resultado > 0;
        }

        public async Task<bool> ExcluirTipoTelefone(TipoTelefone tipoTelefone)
        {
            _tipoTelefoneContext.Remove(tipoTelefone);
            int resultado = await _tipoTelefoneContext.SaveChangesAsync();
            return resultado > 0;
        }

        public async Task<IEnumerable<TipoTelefone>> ObterTiposTelefones()
        {
            var tiposTelefones = await _tipoTelefoneContext.TiposTelefones.ToListAsync();
            return tiposTelefones;
        }

        public async Task<TipoTelefone> ObterTipoTelefonePorDescricao(string descricao)
        {
            var tipoTelefone = await _tipoTelefoneContext.TiposTelefones
                                     .SingleOrDefaultAsync(t => t.DescricaoTipoTelefone == descricao);
            return tipoTelefone;
        }

        public async Task<TipoTelefone> ObterTipoTelefonePorId(int id)
        {
            var tipoTelefone = await _tipoTelefoneContext.TiposTelefones
                                     .SingleOrDefaultAsync(t => t.TipoTelefoneId == id);
            return tipoTelefone;
        }
    }
}
