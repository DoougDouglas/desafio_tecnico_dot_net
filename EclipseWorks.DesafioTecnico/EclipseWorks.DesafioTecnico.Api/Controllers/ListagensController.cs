using EclipseWorks.DesafioTecnico.Domain.Exceptions;
using EclipseWorks.DesafioTecnico.Domain.Extensions;
using EclipseWorks.DesafioTecnico.Domain.Projetos.Queries;
using Microsoft.AspNetCore.Mvc;

namespace EclipseWorks.DesafioTecnico.Api.Controllers
{
    [Route("api/listagens")]
    public class ListagensController : Controller
    {
        [HttpGet]
        [Route("Litar-Prioridade-Tarefa")]
        public async Task<IActionResult> LitarPrioridadeTarefaEnum()
        {
            var listagem = ListagemEnumExtensions.LitarPrioridadeTarefaEnum();

            NotFoundException.LancarExcecaoSeNullOuVazio(listagem);
            return Ok(listagem);
        }

        [HttpGet]
        [Route("Litar-Status-Tarefa")]
        public async Task<IActionResult> GetLitarStatusTarefaEnum()
        {
            var listagem = ListagemEnumExtensions.LitarStatusTarefaEnum();

            NotFoundException.LancarExcecaoSeNullOuVazio(listagem);
            return Ok(listagem);
        }
    }
}
