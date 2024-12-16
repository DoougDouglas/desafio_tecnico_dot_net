using EclipseWorks.DesafioTecnico.Domain.Projetos;
using EclipseWorks.DesafioTecnico.Domain.Tarefas.Commands;
using EclipseWorks.DesafioTecnico.Domain.Tarefas.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EclipseWorks.DesafioTecnico.Domain.Tarefas
{
    public class Tarefa : ExclusaoLogica
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }

        public DateTime DataVencimento { get; private set; }
        public StatusTarefaEnum Status { get; private set; } = StatusTarefaEnum.Pendente;
        public PrioridadeTarefaEnum Prioridade { get; private set; }

        public Guid IdProjeto { get; private set; }
        public Projeto Projeto { get; set; }

        public List<ComentarioTarefa> Comentarios { get; init; } = [];
        public List<HistoricoTarefa> HistoricoAtualizacoesTarefa { get; init; } = [];

        public void AdicionarInformacoes(AdicionarTarefaCommand command)
        {
            IdProjeto = command.IdProjeto;

            Titulo = command.Titulo;
            Status = command.Status;
            Prioridade = command.Prioridade;
            Descricao = command.Descricao;
            DataVencimento = command.DataVencimento;
        }

        public void AtualizarInformacoes(AtualizarTarefaCommand command)
        {
            Titulo = command.Titulo;
            Status = command.Status;
            Descricao = command.Descricao;
            DataVencimento = command.DataVencimento;
        }
    }
}
