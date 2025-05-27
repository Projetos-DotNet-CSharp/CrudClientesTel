using CrudCT.Application.Interfaces;
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
    }
}
