using Microsoft.AspNetCore.Mvc;

namespace Almeida.Web.Api.Interface
{
    public interface IControllerBase<T>
    {
        public IActionResult Get();
        public IActionResult GetById(int id);
        public IActionResult Set([FromBody] T obj);
        public IActionResult Delete([FromBody] T obj);
    }
}
