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
    public class TelefoneService : ITelefoneService
    {
        private ITelefoneRepository _telefoneRepository;
        private readonly IMapper _mapper;

        public TelefoneService(ITelefoneRepository telefoneRepository, IMapper mapper)
        {
            _telefoneRepository = telefoneRepository;
            _mapper = mapper;
        }

        public async Task<bool> AdicionarTelefoneAsync(TelefoneDTO telefoneDTO)
        {
            if (telefoneDTO == null)
            {
                throw new ArgumentNullException(nameof(telefoneDTO));
            }

            var telefone = _mapper.Map<Telefone>(telefoneDTO);
            return await _telefoneRepository.AdicionarTelefone(telefone);
        }

        public async Task<bool> AtualizarTelefoneAsync(TelefoneDTO telefoneDTO)
        {
            if (telefoneDTO == null)
            {
                throw new ArgumentNullException(nameof(telefoneDTO));
            }

            var telefone = _mapper.Map<Telefone>(telefoneDTO);
            return await _telefoneRepository.AtualizarTelefone(telefone);
        }

        public async Task<bool> ExcluirTelefoneAsync(int telefoneId)
        {
            var telefone = await _telefoneRepository.ObterTelefonePorId(telefoneId);
            return await _telefoneRepository.ExcluirTelefone(telefone);
        }

        public async Task<TelefoneDTO> ObterTelefonePorIdAsync(int telefoneId)
        {
            var telefone = await _telefoneRepository.ObterTelefonePorId(telefoneId);

            if (telefone == null)
            {
                return null;
            }

            return _mapper.Map<TelefoneDTO>(telefone);
        }

        public async Task<IEnumerable<TelefoneDTO>> ObterTelefonesAsync()
        {
            var telefones = await _telefoneRepository.ObterTelefones();

            if (telefones == null || !telefones.Any())
            {
                return new List<TelefoneDTO>();
            }

            return _mapper.Map<IEnumerable<TelefoneDTO>>(telefones);
        }

        public async Task<IEnumerable<TelefoneDTO>> ObterTelefonesPorClienteIdAsync(int clienteId)
        {
            var telefones = await _telefoneRepository.ObterTelefonesPorClienteId(clienteId);

            if (telefones == null || !telefones.Any())
            {
                return new List<TelefoneDTO>();
            }

            return _mapper.Map<IEnumerable<TelefoneDTO>>(telefones);
        }
    }
}
