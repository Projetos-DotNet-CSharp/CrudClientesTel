using AutoMapper;
using CrudCT.Application.DTOs;
using CrudCT.Application.Interfaces;
using CrudCT.Domain.Interfaces;
using CrudCT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCT.Application.Services
{
    public class ClienteService : IClienteService
    {
        private IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<bool> AdicionarClienteAsync(ClienteDTO clienteDTO)
        {
            if (clienteDTO == null)
                throw new ArgumentNullException(nameof(clienteDTO));

            var cliente = _mapper.Map<Cliente>(clienteDTO);
            return await _clienteRepository.AdicionarCliente(cliente);
        }

        public async Task<bool> AtualizarClienteAsync(ClienteDTO clienteDTO)
        {
            if (clienteDTO == null)
                throw new ArgumentNullException(nameof(clienteDTO));

            var cliente = _mapper.Map<Cliente>(clienteDTO);
            return await _clienteRepository.AtualizarCliente(cliente);
        }

        public async Task<bool> ExcluirClienteAsync(int clienteId)
        {
            var cliente = await _clienteRepository.ObterClientePorId(clienteId);
            return await _clienteRepository.ExcluirCliente(cliente);
        }

        public async Task<ClienteDTO> ObterClientePorIdAsync(int clienteId)
        {
            var cliente = await _clienteRepository.ObterClientePorId(clienteId);

            if (cliente == null)
            {
                return null;
            }

            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task<IEnumerable<ClienteDTO>> ObterClientesAsync()
        {
            var clientes = await _clienteRepository.ObterClientes();
            if (clientes == null || !clientes.Any())
                return new List<ClienteDTO>();

            return _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
        }

        //public async Task<IEnumerable<TelefoneDTO>> ObterTelefonesPorClienteIdAsync(int clienteId)
        //{
        //}

        //public async Task<bool> AdicionarTelefoneAsync(TelefoneDTO telefoneDTO)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<bool> AtualizarTelefoneAsync(TelefoneDTO telefoneDTO)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<bool> ExcluirTelefoneAsync(int telefoneId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
