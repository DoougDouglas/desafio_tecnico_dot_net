using EclipseWorks.DesafioTecnico.Domain.Tarefas.Commands;
using EclipseWorks.DesafioTecnico.Domain.Tarefas.Repositories;
using EclipseWorks.DesafioTecnico.Services.Validators.Tarefas;
using MediatR;

namespace EclipseWorks.DesafioTecnico.Services.Tarefas.Commands
{
    public class RemoverTarefaCommandHandler(RemoverTarefaValidator validator,
                                          IDomainNotificationAppService domainNotificationAppService,
                                          ITarefaRepository tarefaRepository) : IRequestHandler<RemoverTarefaCommand>
    {
        private readonly RemoverTarefaValidator _validator = validator;
        private readonly ITarefaRepository _tarefaRepository = tarefaRepository;
        private readonly IDomainNotificationAppService _domainNotificationAppService = domainNotificationAppService;

        public async Task Handle(RemoverTarefaCommand request, CancellationToken cancellationToken)
        {
            if (!await _validator.OperacaoValida(request))
            {
                _domainNotificationAppService.Add(_validator.CriticasNegocio);
                return;
            }

            await _tarefaRepository.Excluir(request.IdProjeto, request.IdTarefa);
        }
    }
}
