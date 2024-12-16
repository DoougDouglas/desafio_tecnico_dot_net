using MediatR;

namespace EclipseWorks.DesafioTecnico.Domain.Projetos.Commands
{
    public sealed record AdicionarProjetoCommand(string nome) : IRequest { }
}