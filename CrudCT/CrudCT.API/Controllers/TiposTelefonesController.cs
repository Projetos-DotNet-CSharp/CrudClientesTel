using CrudCT.Application.DTOs;
using CrudCT.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudCT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposTelefonesController : ControllerBase
    {
        private readonly ITipoTelefoneService _tipoTelefoneService;

        public TiposTelefonesController(ITipoTelefoneService tipoTelefoneService)
        {
            _tipoTelefoneService = tipoTelefoneService;
        }

        [HttpGet]
        // public async Task<ActionResult<IEnumerable<ClienteDTO>>> ObterClientes()
        public async Task<ActionResult<IEnumerable<TipoTelefoneDTO>>> ObterTiposTelefones()
        {
            try
            {
                var tiposTelefones = await _tipoTelefoneService.ObterTiposTelefonesAsync();

                if (tiposTelefones == null)
                {
                    return NotFound("Tipos de telefone não encontrados");
                }

                return Ok(tiposTelefones);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao obter tipos de telefone: {ex.Message}");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TipoTelefoneDTO>> ObterTipoTelefonePorId(int id)
        {
            try
            {
                var tipoTelefone = await _tipoTelefoneService.ObterTipoTelefonePorIdAsync(id);
                if (tipoTelefone == null)
                {
                    return NotFound($"Tipo de telefone com ID {id} não encontrado.");
                }
                return Ok(tipoTelefone);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao obter tipo de telefone: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AdicionarTipoTelefone([FromBody] TipoTelefoneDTO tipoTelefoneDTO)
        {
            if (tipoTelefoneDTO == null)
            {
                return BadRequest("Tipo de telefone não pode ser nulo.");
            }

            try
            {
                await _tipoTelefoneService.AdicionarTipoTelefoneAsync(tipoTelefoneDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adicionar tipo de telefone: {ex.Message}");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> AtualizarTipoTelefone(int id, [FromBody] TipoTelefoneDTO tipoTelefoneDTO)
        {
            if (tipoTelefoneDTO == null || tipoTelefoneDTO.TipoTelefoneId != id)
            {
                return BadRequest("Tipo de telefone inválido.");
            }

            try
            {
                await _tipoTelefoneService.AtualizarTipoTelefoneAsync(tipoTelefoneDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar tipo de telefone: {ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> ExcluirTipoTelefone(int id)
        {
            try
            {
                var tipoTelefoneExistente = await _tipoTelefoneService.ObterTipoTelefonePorIdAsync(id);
                if (tipoTelefoneExistente == null)
                {
                    return NotFound($"Tipo de telefone com ID {id} não encontrado.");
                }

                await _tipoTelefoneService.ExcluirTipoTelefoneAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir tipo de telefone: {ex.Message}");
            }
        }
    }
}
