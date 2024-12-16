using EclipseWorks.DesafioTecnico.Domain.Projetos;
using EclipseWorks.DesafioTecnico.Domain.Tarefas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EclipseWorks.DesafioTecnico.Domain.Usuarios
{
    public class Usuario(string nome, string email) : EntidadeBase
    {
        public string Nome { get; init; } = nome;
        public string Email { get; init; } = email;

        public List<Projeto> Projetos { get; init; } = [];
        public List<ComentarioTarefa> Comentarios { get; init; } = [];
        public List<HistoricoTarefa> HistoricoAtualizacoesTarefa { get; set; } = [];
    }
}
