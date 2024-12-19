using EclipseWorks.DesafioTecnico.Domain.Exceptions;
using EclipseWorks.DesafioTecnico.Domain.Projetos.Commands;
using EclipseWorks.DesafioTecnico.Domain.Tarefas.Commands;
using EclipseWorks.DesafioTecnico.Domain.Tarefas.Queries;
using EclipseWorks.DesafioTecnico.Domain.Tarefas.Repositories;
using EclipseWorks.DesafioTecnico.Repository.Tarefas;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EclipseWorks.DesafioTecnico.Api.Controllers
{
    [Route("api/projetos/{idProjeto:guid}/tarefas")]
    public class TarefaController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaController(IMediator mediator, ITarefaRepository tarefaRepository)
        {
            _mediator = mediator;
            _tarefaRepository = tarefaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromRoute] Guid idProjeto)
        {
            var tarefas = await _tarefaRepository.RecuperarTodas(idProjeto);

            NotFoundException.LancarExcecaoSeNullOuVazio(tarefas);

            var response = tarefas?.Select(tarefa => new TarefaResponseModel(tarefa));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AdicionarTarefaInputModel inputModel, [FromRoute] Guid idProjeto)
        {
            var command = new AdicionarTarefaCommand(idProjeto)
            {
                DataVencimento = inputModel.DataVencimento,
                Descricao = inputModel.Descricao,
                Status = inputModel.Status,
                Titulo = inputModel.Titulo,
                Prioridade = inputModel.Prioridade
            };

            await _mediator.Send(command);
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

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{idTarefa:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid idProjeto, [FromRoute] Guid idTarefa)
        {
            var command = new RemoverTarefaCommand(idProjeto, idTarefa);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPost("{idTarefa:guid}/comentarios")]
        public async Task<IActionResult> PostComentarios([FromBody] AdicionarComentarioTarefaInputModel comentarioInputModel, [FromRoute] Guid idProjeto, [FromRoute] Guid idTarefa)
        {
            var command = new AdicionarComentarioTarefaCommand(idProjeto, idTarefa)
            {
                Comentario = comentarioInputModel.Comentario,
            };

            await _mediator.Send(command);
            return NoContent();
        }
    }
}
