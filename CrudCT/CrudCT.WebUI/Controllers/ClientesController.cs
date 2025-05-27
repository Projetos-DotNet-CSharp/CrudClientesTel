using CrudCT.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CrudCT.WebUI.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteService _clienteService;
        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clientes = await _clienteService.ObterClientesAsync();
            return View(clientes);
        }
    }
}
