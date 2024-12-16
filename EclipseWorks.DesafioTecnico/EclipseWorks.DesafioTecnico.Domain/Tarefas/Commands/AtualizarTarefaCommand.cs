using EclipseWorks.DesafioTecnico.Domain.Tarefas.Enum;
using MediatR;

namespace EclipseWorks.DesafioTecnico.Domain.Tarefas.Commands;

public record AtualizarTarefaInputModel
{
    public string Titulo { get; init; }
    public string Descricao { get; init; }
    public DateTime DataVencimento { get; init; }
    public StatusTarefaEnum Status { get; init; }
}

public sealed record AtualizarTarefaCommand(Guid IdProjeto, Guid IdTarefa) : AtualizarTarefaInputModel, IRequest { }