using EclipseWorks.DesafioTecnico.Domain.Tarefas.Enum;

namespace EclipseWorks.DesafioTecnico.Domain.Tarefas.Queries
{
    public sealed record TarefaResponseModel
    {
        public TarefaResponseModel(Tarefa tarefa)
        {
            if (tarefa == null) return;

            Id = tarefa.Id;
            Titulo = tarefa.Titulo;
            Descricao = tarefa.Descricao;
            DataVencimento = tarefa.DataVencimento;
            Status = tarefa.Status;
            Prioridade = tarefa.Prioridade;

            if (tarefa.Comentarios is not null)
            {
                Comentarios = tarefa.Comentarios.Select(comentario => new ComentarioResponseModel(comentario.IdUsuario, comentario.Comentario));
            }
        }

        public Guid Id;

        public string Titulo;
        public string Descricao;

        public DateTime DataVencimento;
        public StatusTarefaEnum Status;
        public PrioridadeTarefaEnum Prioridade;

        public string DescricaoStatus => Status.ToString();
        public string DescricaoPrioridade => Prioridade.ToString();
        public IEnumerable<ComentarioResponseModel> Comentarios { get; init; }
    }

    public sealed record ComentarioResponseModel
    {
        public ComentarioResponseModel(Guid idUsuario, string comentario)
        {
            IdUsuario = idUsuario;
            Comentario = comentario;
        }

        public Guid IdUsuario { get; init; }
        public string Comentario { get; init; }
    }
}
