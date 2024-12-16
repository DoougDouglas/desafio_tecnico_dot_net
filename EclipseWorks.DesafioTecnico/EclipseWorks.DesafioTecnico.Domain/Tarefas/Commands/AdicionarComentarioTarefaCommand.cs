using MediatR;

namespace EclipseWorks.DesafioTecnico.Domain.Tarefas.Commands;

public record AdicionarComentarioTarefaInputModel
{
    public string Comentario { get; init; }        
}

public sealed record AdicionarComentarioTarefaCommand(Guid IdProjeto, Guid IdTarefa) : AdicionarComentarioTarefaInputModel, IRequest { }