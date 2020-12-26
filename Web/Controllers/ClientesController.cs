using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Collections.Generic;

using Almeida.Core.Interfaces;
using Almeida.Core.Entities;
using Almeida.Web.Models;

namespace Almeida.Web.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IRepository<Cliente> _repository;
        private readonly ILogger<HomeController> _logger;

        public ClientesController(ILogger<HomeController> logger, IRepository<Cliente> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("Clientes")]
        public IActionResult Index()
        {
            IEnumerable<Cliente> list = _repository.Get();
            return View(list);
        }

        [Route("Clientes/Delete/{id}")]
        public IActionResult Deletar(int id)
        {
            var cliente = _repository.GetById(id);
            ClienteModel mod = new ClienteModel(cliente);
            var i = _repository.Delete(mod);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Clientes/Edit/{id}")]
        public IActionResult Editar(int id)
        {
            var cliente = _repository.GetById(id);
            ClienteModel mod = new ClienteModel(cliente);
            return View(mod);
        }

        [HttpPost("Clientes/Edit/{id}")]
        public IActionResult Editar(ClienteModel cliente)
        {
            var clt = ClienteModel.Get(cliente);
            var i = _repository.Set(clt);
            return RedirectToAction(nameof(Index));
        }

        [Route("Clientes/Add")]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost("Clientes/Add")]
        public IActionResult Cadastrar(ClienteModel clientes)
        {
            Cliente cliente = ClienteModel.Get(clientes);
            var id = _repository.Set(cliente);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
