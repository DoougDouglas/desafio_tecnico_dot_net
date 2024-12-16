using EclipseWorks.DesafioTecnico.Domain.Projetos.Commands;
using EclipseWorks.DesafioTecnico.Domain.Tarefas.Commands;
using Microsoft.AspNetCore.Mvc;

namespace EclipseWorks.DesafioTecnico.Api.Controllers
{
    [Route("api/projetos/{idProjeto:guid}/tarefas")]
    public class TarefaController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromRoute] Guid idProjeto)
        {
            return Ok("");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AdicionarTarefaInputModel inputModel, [FromRoute] Guid idProjeto)
        {
            //await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{idTarefa:guid}")]
        public async Task<IActionResult> Put([FromBody] AtualizarTarefaInputModel tarefaInputModel, [FromRoute] Guid idProjeto, [FromRoute] Guid idTarefa)
        {
            var command = new AtualizarTarefaCommand(idProjeto, idTarefa)
            {
                DataVencimento = tarefaInputModel.DataVencimento,
                Descricao = tarefaInputModel.Descricao,
                Status = tarefaInputModel.Status,
                Titulo = tarefaInputModel.Titulo,
            };

            //await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{idTarefa:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid idProjeto, [FromRoute] Guid idTarefa)
        {
            //await _mediator.Send(command);
            return NoContent();
        }

        [HttpPost("{idTarefa:guid}/comentarios")]
        public async Task<IActionResult> PostComentarios([FromBody] AdicionarComentarioTarefaInputModel comentarioInputModel, [FromRoute] Guid idProjeto, [FromRoute] Guid idTarefa)
        {
            var command = new AdicionarComentarioTarefaCommand(idProjeto, idTarefa)
            {
                Comentario = comentarioInputModel.Comentario,
            };

            //await _mediator.Send(command);
            return NoContent();
        }
    }
}
