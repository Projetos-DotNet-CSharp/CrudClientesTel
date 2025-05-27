using CrudCT.Application.DTOs;
using CrudCT.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudCT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefonesController : ControllerBase
    {
        private readonly ITelefoneService _telefoneService;
        public TelefonesController(ITelefoneService telefoneService)
        {
            _telefoneService = telefoneService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TelefoneDTO>>> ObterTelefones()
        {
            try
            {
                var telefones = await _telefoneService.ObterTelefonesAsync();

                if (telefones == null)
                {
                    return NotFound("Telefones não encontrados");
                }

                return Ok(telefones);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao obter telefones: {ex.Message}");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TelefoneDTO>> ObterTelefonePorId(int id)
        {
            try
            {
                var telefone = await _telefoneService.ObterTelefonePorIdAsync(id);
                if (telefone == null)
                {
                    return NotFound($"Telefone com ID {id} não encontrado.");
                }
                return Ok(telefone);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao obter telefone: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AdicionarTelefone([FromBody] TelefoneDTO telefoneDTO)
        {
            if (telefoneDTO == null)
            {
                return BadRequest("Dados do telefone não podem ser nulos.");
            }

            try
            {
                await _telefoneService.AdicionarTelefoneAsync(telefoneDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adicionar telefone: {ex.Message}");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> AtualizarTelefone(int id, [FromBody] TelefoneDTO telefoneDTO)
        {
            if (telefoneDTO == null || telefoneDTO.TelefoneId != id)
            {
                return BadRequest("Dados do telefone inválidos.");
            }

            try
            {
                var telefoneExistente = await _telefoneService.ObterTelefonePorIdAsync(id);
                if (telefoneExistente == null)
                {
                    return NotFound($"Telefone com ID {id} não encontrado.");
                }

                await _telefoneService.AtualizarTelefoneAsync(telefoneDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar telefone: {ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> ExcluirTelefone(int id)
        {
            try
            {
                var telefoneExistente = await _telefoneService.ObterTelefonePorIdAsync(id);
                if (telefoneExistente == null)
                {
                    return NotFound($"Telefone com ID {id} não encontrado.");
                }

                await _telefoneService.ExcluirTelefoneAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao deletar telefone: {ex.Message}");
            }
        }
    }
}
