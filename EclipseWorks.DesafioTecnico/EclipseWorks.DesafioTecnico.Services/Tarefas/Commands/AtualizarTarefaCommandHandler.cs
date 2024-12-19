using EclipseWorks.DesafioTecnico.Domain;
using EclipseWorks.DesafioTecnico.Domain.Tarefas.Commands;
using EclipseWorks.DesafioTecnico.Domain.Tarefas.Repositories;
using EclipseWorks.DesafioTecnico.Repository.Context;
using EclipseWorks.DesafioTecnico.Services.Validators.Tarefas;
using MediatR;

namespace EclipseWorks.DesafioTecnico.Services.Tarefas.Commands
{
    public class AtualizarTarefaCommandHandler(IDomainNotificationAppService domainNotificationAppService,
                                           AtualizarTarefaValidator validator,
                                           ITarefaRepository tarefaRepository, IUser currentUser, ApplicationDbContext context) : IRequestHandler<AtualizarTarefaCommand>
    {
        private readonly AtualizarTarefaValidator _validator = validator;
        private readonly ITarefaRepository _tarefaRepository = tarefaRepository;
        private readonly IDomainNotificationAppService _domainNotificationAppService = domainNotificationAppService;
        private readonly IUser _currentUser = currentUser;
        private readonly ApplicationDbContext _context = context;

        public async Task Handle(AtualizarTarefaCommand request, CancellationToken cancellationToken)
        {
            if (!await _validator.OperacaoValida(request))
            {
                _domainNotificationAppService.Add(_validator.CriticasNegocio);
                return;
            }

            var tarefa = await _tarefaRepository.RecuperarPorIdAsync(request.IdProjeto, request.IdTarefa);
            tarefa.AtualizarInformacoes(request);

            var teste = new AdicionarHistoricoTarefaCommandHandler(_currentUser, _context);
            await _tarefaRepository.Atualizar(tarefa);
            await teste.Handle(new AdicionarHistoricoTarefaCommand { Comentario = "Atualização", DadosAlterados = request.ToString(), IdTarefa = request.IdTarefa }, cancellationToken);
        }
    }
}
