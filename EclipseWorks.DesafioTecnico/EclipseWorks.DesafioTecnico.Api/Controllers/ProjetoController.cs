using EclipseWorks.DesafioTecnico.Domain;
using EclipseWorks.DesafioTecnico.Domain.Exceptions;
using EclipseWorks.DesafioTecnico.Domain.Projetos.Commands;
using EclipseWorks.DesafioTecnico.Domain.Projetos.Queries;
using EclipseWorks.DesafioTecnico.Domain.Projetos.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EclipseWorks.DesafioTecnico.Api.Controllers
{
    [Route("api/projetos")]
    public class ProjetoController : Controller
    {

        private readonly IMediator _mediator;
        private readonly IUser _usuarioLogado;
        private readonly IProjetoRepository _projetoRepository;

        public ProjetoController(IMediator mediator, IUser usuarioLogado, IProjetoRepository projetoRepository)
        {
            _mediator = mediator;
            _usuarioLogado = usuarioLogado;
            _projetoRepository = projetoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projetos = await _projetoRepository.RecuperarTodosPorUsuario(_usuarioLogado.Id);

            NotFoundException.LancarExcecaoSeNullOuVazio(projetos);

            var response = projetos?.Select(projeto => new ProjetoResponseModel(projeto));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AdicionarProjetoCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] RemoverProjetoCommand command)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
