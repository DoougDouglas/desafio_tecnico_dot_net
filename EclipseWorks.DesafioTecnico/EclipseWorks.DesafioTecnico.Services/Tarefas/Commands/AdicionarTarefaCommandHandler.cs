using EclipseWorks.DesafioTecnico.Domain.Tarefas;
using EclipseWorks.DesafioTecnico.Domain.Tarefas.Commands;
using EclipseWorks.DesafioTecnico.Domain.Tarefas.Repositories;
using EclipseWorks.DesafioTecnico.Services.Validators.Tarefas;
using MediatR;

namespace EclipseWorks.DesafioTecnico.Services.Tarefas.Commands
{
    public class AdicionarTarefaCommandHandler(IDomainNotificationAppService domainNotificationAppService,
    ITarefaRepository tarefaRepository,
    AdicionarTarefaValidator validator) : IRequestHandler<AdicionarTarefaCommand>
    {
        private readonly ITarefaRepository _tarefaRepository = tarefaRepository;
        private readonly IDomainNotificationAppService _domainNotificationAppService = domainNotificationAppService;
        private readonly AdicionarTarefaValidator _validator = validator;

        public async Task Handle(AdicionarTarefaCommand request, CancellationToken cancellationToken)
        {
            if (!await _validator.OperacaoValida(request))
            {
                _domainNotificationAppService.Add(_validator.CriticasNegocio);
                return;
            }
            if (await _tarefaRepository.RecuperarQuantidadePorProjeto(request.IdProjeto) > 20)
                throw new Exception("Limite máximo de tarefas atingido!");

            var tarefa = new Tarefa();
            tarefa.AdicionarInformacoes(request);

            await _tarefaRepository.Adicionar(tarefa);
        }
    }
}
