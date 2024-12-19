using EclipseWorks.DesafioTecnico.Domain;
using EclipseWorks.DesafioTecnico.Domain.Projetos;
using EclipseWorks.DesafioTecnico.Domain.Projetos.Commands;
using EclipseWorks.DesafioTecnico.Domain.Projetos.Repositories;
using EclipseWorks.DesafioTecnico.Services.Validators.Projetos;
using MediatR;

namespace EclipseWorks.DesafioTecnico.Services.Projetos.Commands
{
    public class AdicionarProjetoCommandHandler : IRequestHandler<AdicionarProjetoCommand>
    {
        private readonly IUser _usuarioLogado;
        private readonly IProjetoRepository _repository;
        private readonly IDomainNotificationAppService _domainNotificationAppService;
        private readonly AdicionarProjetoValidator _validator;

        public AdicionarProjetoCommandHandler(IDomainNotificationAppService domainNotificationAppService, IProjetoRepository repository, IUser usuarioLogado, AdicionarProjetoValidator validator)
        {
            _repository = repository;
            _domainNotificationAppService = domainNotificationAppService;
            _usuarioLogado = usuarioLogado;
            _validator = validator;
        }

        public async Task Handle(AdicionarProjetoCommand request, CancellationToken cancellationToken)
        {
            if (!_validator.OperacaoValida(request))
            {
                _domainNotificationAppService.Add(_validator.CriticasNegocio);
                return;
            }

            var projeto = new Projeto
            {
                Nome = request.Nome,
                IdUsuario = _usuarioLogado.Id
            };

            await _repository.AdicionarAsync(projeto);
        }
    }
}
