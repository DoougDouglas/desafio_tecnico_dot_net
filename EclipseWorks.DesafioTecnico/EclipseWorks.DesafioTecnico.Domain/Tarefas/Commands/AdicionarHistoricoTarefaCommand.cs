using MediatR;

namespace EclipseWorks.DesafioTecnico.Domain.Tarefas.Commands;

public class AdicionarHistoricoTarefaCommand : IRequest
{   
    public Guid IdTarefa { get; init; }
    public string DadosAlterados { get; init; }
    public string Comentario { get; init; }
}
