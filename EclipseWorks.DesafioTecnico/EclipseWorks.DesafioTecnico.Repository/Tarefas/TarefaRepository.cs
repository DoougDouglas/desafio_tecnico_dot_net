using EclipseWorks.DesafioTecnico.Domain.Tarefas;
using EclipseWorks.DesafioTecnico.Domain.Tarefas.Repositories;
using EclipseWorks.DesafioTecnico.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace EclipseWorks.DesafioTecnico.Repository.Tarefas
{
    public class TarefaRepository(ApplicationDbContext context) : ITarefaRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task Adicionar(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Tarefa tarefa)
        {
            await _context.SaveChangesAsync();
        }

        public async Task AdicionarComentario(ComentarioTarefa comentarioTarefa)
        {
            _context.Comentarios.Add(comentarioTarefa);
            await _context.SaveChangesAsync();
        }

        public async Task<Tarefa> RecuperarPorIdAsync(Guid idProjeto, Guid idTarefa) =>
            await _context.Tarefas
            .Include(a => a.Comentarios)
            .Include(a => a.HistoricoAtualizacoesTarefa)
            .FirstOrDefaultAsync(a => a.IdProjeto == idProjeto && a.Id == idTarefa && !a.isExcluido && !a.Projeto.isExcluido);

        public async Task<IEnumerable<Tarefa>> RecuperarTodas(Guid idProjeto) => await _context.Tarefas
            .AsNoTracking()
            .Include(tarefa => tarefa.Comentarios)
            .Where(tarefa => tarefa.IdProjeto == idProjeto && !tarefa.Projeto.isExcluido && !tarefa.isExcluido)
            .ToListAsync();

        public async Task<IEnumerable<int>> RecuperarQuantidadePOrProjeto(Guid idProjeto) => await _context.Tarefas
           .AsNoTracking()
           .Where(tarefa => tarefa.IdProjeto == idProjeto && !tarefa.Projeto.isExcluido && !tarefa.isExcluido)
           .CountAsync();

        public async Task Excluir(Guid idProjeto, Guid idTarefa)
        {
            var entidade = await RecuperarPorIdAsync(idProjeto, idTarefa);
            entidade.isExcluido = true;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> TarefaExiste(Guid idProjeto, Guid idTarefa) => await _context.Tarefas.AnyAsync(tarefa => tarefa.IdProjeto == idProjeto
                                                                                                                 && !tarefa.Projeto.isExcluido
                                                                                                                 && tarefa.Id == idTarefa
                                                                                                                 && !tarefa.isExcluido);
    }
}
