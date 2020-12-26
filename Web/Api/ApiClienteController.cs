using Microsoft.AspNetCore.Mvc;

using Almeida.Web.Api.Interface;
using Almeida.Core.Interfaces;
using Almeida.Core.Entities;
using Almeida.Web.Models;

namespace Almeida.Web.Api
{
    [Route("api/")]
    [ApiController]
    public class ApiClienteController : ApiController, IControllerBase<ClienteModel>
    {
       readonly IRepository<Cliente> _repository;

        public ApiClienteController(IRepository<Cliente> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Api Cliente = Exclusão cliente
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpDelete("clientes")]
        public IActionResult Delete([FromBody] ClienteModel obj)
        {
            var cliente = obj;
            var i = _repository.Delete(cliente);
            return Ok(cliente);
        }

        /// <summary>
        /// Api Cliente = Retorna Lista de clientes cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet("clientes")]
        public IActionResult Get()
        {
            var ls = _repository.Get();
            return Ok(ls);
        }

        /// <summary>
        /// Api Cliente = Retorna cliente por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("clientes/{id}")]
        public IActionResult GetById(int id)
        {
            var cliente = _repository.GetById(id);
            return Ok(cliente);
        }

        [HttpPost("clientes")]
        public IActionResult Set([FromBody] ClienteModel obj)
        {
            var i = _repository.Set(obj);
            return Ok(obj);
        }
    }
}
