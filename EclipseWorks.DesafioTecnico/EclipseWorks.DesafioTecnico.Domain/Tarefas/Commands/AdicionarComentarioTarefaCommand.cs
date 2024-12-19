using MediatR;

namespace EclipseWorks.DesafioTecnico.Domain.Tarefas.Commands;

public record AdicionarComentarioTarefaInputModel
{
    public string Comentario { get; init; }

    public override string ToString()
    {
        return $"Comentario: {Comentario}";
    }
}

public sealed record AdicionarComentarioTarefaCommand(Guid IdProjeto, Guid IdTarefa) : AdicionarComentarioTarefaInputModel, IRequest { }