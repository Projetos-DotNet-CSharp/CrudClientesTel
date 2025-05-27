using CrudCT.Application.DTOs;
using CrudCT.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudCT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> ObterClientes()
        {
            try
            {
                var clientes = await _clienteService.ObterClientesAsync();

                if (clientes == null)
                {
                    return NotFound("Clientes não encontrados");
                }

                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao obter clientes: {ex.Message}");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ClienteDTO>> ObterClientePorId(int id)
        {
            try
            {
                var cliente = await _clienteService.ObterClientePorIdAsync(id);
                if (cliente == null)
                {
                    return NotFound($"Cliente com ID {id} não encontrado.");
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao obter cliente: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AdicionarCliente([FromBody] ClienteDTO clienteDTO)
        {
            if (clienteDTO == null)
            {
                return BadRequest("Cliente não pode ser nulo.");
            }

            try
            {
                await _clienteService.AdicionarClienteAsync(clienteDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adicionar cliente: {ex.Message}");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> AtualizarCliente(int id, [FromBody] ClienteDTO clienteDTO)
        {
            if (clienteDTO == null || clienteDTO.ClienteId != id)
            {
                return BadRequest("Dados do cliente inválidos.");
            }

            try
            {
                var clienteExistente = await _clienteService.ObterClientePorIdAsync(id);
                if (clienteExistente == null)
                {
                    return NotFound($"Cliente com ID {id} não encontrado.");
                }

                await _clienteService.AtualizarClienteAsync(clienteDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar cliente: {ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> ExcluirCliente(int id)
        {
            try
            {
                var clienteExistente = await _clienteService.ObterClientePorIdAsync(id);
                if (clienteExistente == null)
                {
                    return NotFound($"Cliente com ID {id} não encontrado.");
                }

                await _clienteService.ExcluirClienteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir cliente: {ex.Message}");
            }
        }
    }
}
