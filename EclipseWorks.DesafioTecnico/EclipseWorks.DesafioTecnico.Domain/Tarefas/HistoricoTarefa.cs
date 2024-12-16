using EclipseWorks.DesafioTecnico.Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EclipseWorks.DesafioTecnico.Domain.Tarefas
{
    public class HistoricoTarefa : EntidadeBase
    {
        public Guid IdUsuario { get; init; }
        public Usuario Usuario { get; init; }
        public Guid IdTarefa { get; init; }
        public Tarefa Tarefa { get; init; }
        public string DadosAlterados { get; init; }
        public string Comentario { get; init; }
    }
}