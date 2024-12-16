using EclipseWorks.DesafioTecnico.Domain.Tarefas.Enum;
using MediatR;

namespace EclipseWorks.DesafioTecnico.Domain.Tarefas.Commands;

public record AdicionarTarefaInputModel
{
    public string Titulo { get; init; }
    public string Descricao { get; init; }
    public DateTime DataVencimento { get; init; }
    public StatusTarefaEnum Status { get; init; }
    public PrioridadeTarefaEnum Prioridade { get; init; }
}

public sealed record AdicionarTarefaCommand(Guid IdProjeto) : AdicionarTarefaInputModel, IRequest { }