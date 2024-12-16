using MediatR;

namespace EclipseWorks.DesafioTecnico.Domain.Projetos.Commands
{
    public sealed record RemoverProjetoCommand(Guid IdProjeto) : IRequest { }
}