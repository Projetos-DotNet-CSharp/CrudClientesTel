using CrudCT.Application.DTOs;
using CrudCT.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClienteDTO clienteDTO)
        {
            //clienteDTO.Telefones ??= new List<TelefoneDTO>();
            //clienteDTO.Telefones.Add(new TelefoneDTO
            //{
            //    NumeroTelefone = "8196987485",
            //    TipoTelefoneId = 1, 
            //    Operadora = "Claro",
            //    Ativo = true
            //});

            if (ModelState.IsValid)
            {
                await _clienteService.AdicionarClienteAsync(clienteDTO);
                return RedirectToAction(nameof(Index));
            }
            
            return View(clienteDTO);
        }
    }
}
