using CrudCT.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CrudCT.WebUI.Controllers
{
    public class TelefonesController : Controller
    {
        private readonly ITelefoneService _telefoneService;
        public TelefonesController(ITelefoneService telefoneService)
        {
            _telefoneService = telefoneService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var telefones = await _telefoneService.ObterTelefonesAsync();
            return View(telefones);
        }
    }
}
