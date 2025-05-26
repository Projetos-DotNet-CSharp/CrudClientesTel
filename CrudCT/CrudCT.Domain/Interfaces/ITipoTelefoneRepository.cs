using CrudCT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCT.Domain.Interfaces
{
    public interface ITipoTelefoneRepository
    {
        Task<IEnumerable<TipoTelefone>> ObterTiposTelefones();
        Task<TipoTelefone> ObterTipoTelefonePorId(int id);
        Task<TipoTelefone> ObterTipoTelefonePorDescricao(string descricao);
        Task<bool> AdicionarTipoTelefone(TipoTelefone tipoTelefone);
        Task<bool> AtualizarTipoTelefone(TipoTelefone tipoTelefone);
        Task<bool> ExcluirTipoTelefone(TipoTelefone tipoTelefone);
    }
}
