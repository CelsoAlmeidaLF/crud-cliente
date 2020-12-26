using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Almeida.Web.Api
{
    [Route("api/")]
    [ApiController]
    public class MetaController : ControllerBase
    {
        [HttpGet("info/")]
        public IActionResult Get()
        {
            var assembly = typeof(Startup).Assembly;
            
            var creationDate = System.IO.File.GetCreationTime(assembly.Location);
            var version = FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;
            
            return Ok($"Version: {version}, Last Updated: {creationDate}");
        }
    }
}