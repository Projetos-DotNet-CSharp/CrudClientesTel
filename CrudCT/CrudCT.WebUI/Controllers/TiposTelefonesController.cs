using CrudCT.Application.DTOs;
using CrudCT.Application.Interfaces;
using CrudCT.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudCT.WebUI.Controllers
{
    public class TiposTelefonesController : Controller
    {
        private readonly ITipoTelefoneService _tipoTelefoneService;

        public TiposTelefonesController(ITipoTelefoneService tipoTelefoneService)
        {
            _tipoTelefoneService = tipoTelefoneService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var tiposTelefones = await _tipoTelefoneService.ObterTiposTelefonesAsync();
            return View(tiposTelefones);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TipoTelefoneDTO tipoTelefoneDTO)
        {
            if (ModelState.IsValid)
            {
                await _tipoTelefoneService.AdicionarTipoTelefoneAsync(tipoTelefoneDTO);
                return RedirectToAction(nameof(Index));
            }

            return View(tipoTelefoneDTO);
        }
    }
}
