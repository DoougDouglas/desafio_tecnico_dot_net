using EclipseWorks.DesafioTecnico.Domain.Projetos.Commands;
using Microsoft.AspNetCore.Mvc;

namespace EclipseWorks.DesafioTecnico.Api.Controllers
{
    [Route("api/projetos")]
    public class ProjetoController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok("");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AdicionarProjetoCommand command)
        {
            //await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] RemoverProjetoCommand command)
        {
            //await _mediator.Send(command);
            return NoContent();
        }
    }
}
