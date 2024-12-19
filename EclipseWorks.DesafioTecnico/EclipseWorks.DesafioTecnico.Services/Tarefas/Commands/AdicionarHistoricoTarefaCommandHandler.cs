using EclipseWorks.DesafioTecnico.Domain;
using EclipseWorks.DesafioTecnico.Domain.Tarefas;
using EclipseWorks.DesafioTecnico.Domain.Tarefas.Commands;
using EclipseWorks.DesafioTecnico.Repository.Context;
using MediatR;

namespace EclipseWorks.DesafioTecnico.Services.Tarefas.Commands
{
    public class AdicionarHistoricoTarefaCommandHandler(IUser currentUser, ApplicationDbContext context) : IRequestHandler<AdicionarHistoricoTarefaCommand>
    {
        private readonly IUser _currentUser = currentUser;
        private readonly ApplicationDbContext _context = context;

        public async Task Handle(AdicionarHistoricoTarefaCommand request, CancellationToken cancellationToken)
        {
            var historicoTarefa = new HistoricoTarefa
            {
                IdUsuario = _currentUser.Id,
                IdTarefa = request.IdTarefa,
                Comentario = request.Comentario,
                DadosAlterados = request.DadosAlterados
            };

            _context.HistoricoTarefas.Add(historicoTarefa);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
