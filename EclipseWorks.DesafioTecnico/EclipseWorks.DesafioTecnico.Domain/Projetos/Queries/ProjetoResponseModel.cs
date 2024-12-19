using EclipseWorks.DesafioTecnico.Domain.Tarefas.Queries;

namespace EclipseWorks.DesafioTecnico.Domain.Projetos.Queries
{
    public sealed record ProjetoResponseModel
    {
        public ProjetoResponseModel(Projeto projeto)
        {
            if (projeto == null) return;

            Id = projeto.Id;
            Nome = projeto.Nome;
            Tarefas = projeto.Tarefas?.Select(tarefa => new TarefaResponseModel(tarefa));
        }

        public Guid Id { get; private init; }
        public string Nome { get; private set; }
        public IEnumerable<TarefaResponseModel> Tarefas { get; private set; }
    }
}
