using AutoMapper;
using CrudCT.Application.DTOs;
using CrudCT.Application.Interfaces;
using CrudCT.Domain.Entities;
using CrudCT.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCT.Application.Services
{
    public class TipoTelefoneService : ITipoTelefoneService
    {
        private ITipoTelefoneRepository _tipoTelefoneRepository;
        private readonly IMapper _mapper;

        public TipoTelefoneService(ITipoTelefoneRepository tipoTelefoneRepository, IMapper mapper)
        {
            _tipoTelefoneRepository = tipoTelefoneRepository;
            _mapper = mapper;
        }

        public async Task<bool> AdicionarTipoTelefoneAsync(TipoTelefoneDTO tipoTelefoneDTO)
        {
            if (tipoTelefoneDTO == null)
            {
                throw new ArgumentNullException(nameof(tipoTelefoneDTO));
            }

            var tipoTelefone = _mapper.Map<TipoTelefone>(tipoTelefoneDTO);
            return await _tipoTelefoneRepository.AdicionarTipoTelefone(tipoTelefone);
        }

        public async Task<bool> AtualizarTipoTelefoneAsync(TipoTelefoneDTO tipoTelefoneDTO)
        {
            if (tipoTelefoneDTO == null)
            {
                throw new ArgumentNullException(nameof(tipoTelefoneDTO));
            }

            var tipoTelefone = _mapper.Map<TipoTelefone>(tipoTelefoneDTO);
            return await _tipoTelefoneRepository.AtualizarTipoTelefone(tipoTelefone);
        }

        public async Task<bool> ExcluirTipoTelefoneAsync(int tipoTelefoneId)
        {
            var tipoTelefone = await _tipoTelefoneRepository.ObterTipoTelefonePorId(tipoTelefoneId);
            
            if (tipoTelefone == null)
            {
                throw new KeyNotFoundException($"Tipo de telefone com ID {tipoTelefoneId} não encontrado.");
            }

            return await _tipoTelefoneRepository.ExcluirTipoTelefone(tipoTelefone);
        }

        public async Task<TipoTelefoneDTO> ObterTipoTelefonePorIdAsync(int tipoTelefoneId)
        {
            var tipoTelefone = await _tipoTelefoneRepository.ObterTipoTelefonePorId(tipoTelefoneId);

            if (tipoTelefone == null)
            {
                return null;
            }

            return _mapper.Map<TipoTelefoneDTO>(tipoTelefone);
        }

        public async Task<IEnumerable<TipoTelefoneDTO>> ObterTiposTelefonesAsync()
        {
            var tiposTelefones = await _tipoTelefoneRepository.ObterTiposTelefones();

            if (tiposTelefones == null || !tiposTelefones.Any())
            {
                return new List<TipoTelefoneDTO>();
            }

            return _mapper.Map<IEnumerable<TipoTelefoneDTO>>(tiposTelefones);
        }
    }
}
