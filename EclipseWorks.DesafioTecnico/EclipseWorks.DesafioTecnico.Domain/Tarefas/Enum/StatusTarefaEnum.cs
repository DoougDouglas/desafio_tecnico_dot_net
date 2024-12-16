using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EclipseWorks.DesafioTecnico.Domain.Tarefas.Enum
{
    public enum StatusTarefaEnum
    {
        [Description("Pendente")]
        Pendente = 0,

        [Description("Em andamento")]
        EmAndamento = 1,

        [Description("Concluído")]
        Concluido = 2
    }
}
