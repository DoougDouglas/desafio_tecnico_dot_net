using EclipseWorks.DesafioTecnico.Domain;
using EclipseWorks.DesafioTecnico.Domain.Tarefas;
using EclipseWorks.DesafioTecnico.Domain.Tarefas.Commands;
using EclipseWorks.DesafioTecnico.Domain.Tarefas.Repositories;
using EclipseWorks.DesafioTecnico.Repository.Context;
using EclipseWorks.DesafioTecnico.Services.Validators.Tarefas;
using MediatR;

namespace EclipseWorks.DesafioTecnico.Services.Tarefas.Commands
{
    public class AdicionarComentarioTarefaCommandHandler(AdicionarComentarioTarefaValidator validator,
                                                     IDomainNotificationAppService domainNotificationAppService,
                                                     ITarefaRepository tarefaRepository,
                                                     IUser usuario, ApplicationDbContext context) : IRequestHandler<AdicionarComentarioTarefaCommand>
    {
        private readonly IUser _usuario = usuario;
        private readonly ITarefaRepository _tarefaRepository = tarefaRepository;
        private readonly AdicionarComentarioTarefaValidator _validator = validator;
        private readonly IDomainNotificationAppService _domainNotificationAppService = domainNotificationAppService;
        private readonly ApplicationDbContext _context = context;

        public async Task Handle(AdicionarComentarioTarefaCommand request, CancellationToken cancellationToken)
        {
            if (!await _validator.OperacaoValida(request))
            {
                _domainNotificationAppService.Add(_validator.CriticasNegocio);
                return;
            }

            var comentario = new ComentarioTarefa
            {
                IdUsuario = _usuario.Id,
                IdTarefa = request.IdTarefa,
                Comentario = request.Comentario
            };

            await _tarefaRepository.AdicionarComentario(comentario);

            var teste = new AdicionarHistoricoTarefaCommandHandler(_usuario, _context);
            await teste.Handle(new AdicionarHistoricoTarefaCommand { Comentario = request.Comentario, DadosAlterados = request.ToString(), IdTarefa = request.IdTarefa }, cancellationToken);

        }
    }
}