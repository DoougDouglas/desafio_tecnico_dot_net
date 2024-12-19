namespace EclipseWorks.DesafioTecnico.Domain.Tarefas.Repositories
{
    public interface ITarefaRepository
    {
        Task AdicionarComentario(ComentarioTarefa comentarioTarefa);
        Task<bool> TarefaExiste(Guid idProjeto, Guid idTarefa);
        Task Adicionar(Tarefa tarefa);
        Task Atualizar(Tarefa tarefa);
        Task Excluir(Guid idProjeto, Guid idTarefa);
        Task<Tarefa> RecuperarPorIdAsync(Guid idProjeto, Guid idTarefa);
        Task<IEnumerable<Tarefa>> RecuperarTodas(Guid idProjeto);

        Task<int> RecuperarQuantidadePorProjeto(Guid idProjeto);
    }
}
