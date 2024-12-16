using MediatR;

namespace EclipseWorks.DesafioTecnico.Domain.Tarefas.Commands;

public sealed record RemoverTarefaCommand(Guid IdProjeto, Guid IdTarefa) : IRequest { }