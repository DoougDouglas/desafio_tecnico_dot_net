namespace EclipseWorks.DesafioTecnico.Domain.Projetos.Repositories
{
    public interface IProjetoRepository
    {
        Task<bool> ProjetoExisteAsync(Guid idProjeto);
        Task<int> RecuperarTotalTarefasProjetoAsync(Guid IdProjeto);
        Task<bool> PossuiTarefasPendentesAsync(Guid idProjeto);
        Task AdicionarAsync(Projeto projeto);
        Task AtualizarAsync(Projeto projeto);
        Task ExcluirAsync(Guid idProjeto);
        Task<IEnumerable<Projeto>> RecuperarTodosPorUsuario(Guid idUsuario);
    }
}
