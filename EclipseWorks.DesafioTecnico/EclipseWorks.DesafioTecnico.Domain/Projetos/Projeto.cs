using EclipseWorks.DesafioTecnico.Domain.Tarefas;
using EclipseWorks.DesafioTecnico.Domain.Usuarios;

namespace EclipseWorks.DesafioTecnico.Domain.Projetos
{
    public class Projeto : ExclusaoLogica
    {
        public string Nome { get; init; }

        public Usuario Usuario { get; init; }
        public Guid IdUsuario { get; init; }

        public List<Tarefa> Tarefas { get; init; } = [];
    }
}
