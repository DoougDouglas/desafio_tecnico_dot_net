using EclipseWorks.DesafioTecnico.Domain.Projetos;
using EclipseWorks.DesafioTecnico.Domain.Projetos.Repositories;
using EclipseWorks.DesafioTecnico.Domain.Tarefas.Enum;
using EclipseWorks.DesafioTecnico.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace EclipseWorks.DesafioTecnico.Repository.Projetos
{
    public class ProjetoRepository(ApplicationDbContext context) : IProjetoRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<bool> PossuiTarefasPendentesAsync(Guid idProjeto)
        {
            return await _context.Tarefas
                .Where(t => t.IdProjeto == idProjeto && t.Status == StatusTarefaEnum.Pendente)
                .AnyAsync();
        }

        public async Task<IEnumerable<Projeto>> RecuperarTodosPorUsuario(Guid idUsuario) => await _context.Projetos
            .AsNoTracking()
            .Where(a => a.IdUsuario == idUsuario && !a.isExcluido)
            .ToListAsync();

        public async Task AdicionarAsync(Projeto projeto)
        {
            _context.Add(projeto);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Projeto projeto)
        {
            _context.Update(projeto);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(Guid idProjeto)
        {
            var entidade = _context.Projetos.Find(idProjeto);
            entidade.isExcluido = true;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ProjetoExisteAsync(Guid idProjeto)
        {
            return await _context.Projetos.AnyAsync(a => a.Id == idProjeto && !a.isExcluido);
        }

        public async Task<int> RecuperarTotalTarefasProjetoAsync(Guid IdProjeto)
        {
            return await _context.Tarefas.CountAsync(a => a.IdProjeto == IdProjeto && !a.isExcluido);
        }
    }
}
