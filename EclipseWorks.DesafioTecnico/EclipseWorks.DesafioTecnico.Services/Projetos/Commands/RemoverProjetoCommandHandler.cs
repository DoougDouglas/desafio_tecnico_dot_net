using EclipseWorks.DesafioTecnico.Domain.Projetos.Commands;
using EclipseWorks.DesafioTecnico.Domain.Projetos.Repositories;
using EclipseWorks.DesafioTecnico.Services.Validators.Projetos;
using MediatR;
using System.Data;

namespace EclipseWorks.DesafioTecnico.Services.Projetos.Commands
{
    public class RemoverProjetoCommandHandler(IDomainNotificationAppService domainNotificationAppService,
                                          IProjetoRepository repository,
                                          RemoverProjetoValidator validator) : IRequestHandler<RemoverProjetoCommand>
    {
        private readonly IProjetoRepository _repository = repository;
        private readonly RemoverProjetoValidator _validator = validator;
        private readonly IDomainNotificationAppService _domainNotificationAppService = domainNotificationAppService;

        public async Task Handle(RemoverProjetoCommand request, CancellationToken cancellationToken)
        {
            if (!await _validator.OperacaoValida(request))
            {
                throw new Exception(_validator.CriticasNegocio[0]);
                _domainNotificationAppService.Add(_validator.CriticasNegocio);
                return;
            }

            await _repository.ExcluirAsync(request.IdProjeto);
        }
    }
}
